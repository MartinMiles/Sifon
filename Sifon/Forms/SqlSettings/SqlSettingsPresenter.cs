using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Code.Helpers;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.SqlSettings
{
    public class SqlSettingsPresenter
    {
        private readonly ISqlSettingsView _view;
        private readonly SqlServerRecordProvider _sqlService;
        private readonly ProfilesProvider _profilesService;
        private readonly ScriptWrapper<PSObject> _scriptWrapper;
        private readonly RemoteScriptCopier _remoteScriptCopier;
        private readonly FakesHelper _fakesHelper;

        public SqlSettingsPresenter(ISqlSettingsView sqlSettingsView)
        {
            _view = sqlSettingsView;
            _fakesHelper = new FakesHelper();
            _sqlService = new SqlServerRecordProvider();
            _profilesService = new ProfilesProvider();

            _view.FormLoad += FormLoad;
            _view.TestClicked += TestClicked;
            _view.SelectedRecordChanged += SelectedRecordChanged;
            _view.SqlRecordAdded += SqlRecordAdded;
            _view.SqlRecordRenamed += SqlRecordRenamed;
            _view.SqlRecordDeleted += SqlRecordDeleted;
            _view.ClosingForm += ClosingForm;

            _remoteScriptCopier = new RemoteScriptCopier(_profilesService.SelectedProfile, _view);
            _scriptWrapper = new ScriptWrapper<PSObject>(new ProfilesProvider().SelectedProfile, _view, d => d);
        }

        private IEnumerable<string> ServerRecords => _sqlService.Read().Select(s => s.RecordName);

        private void FormLoad(object sender, EventArgs e)
        {
            _view.PopulateServersDropdown(ServerRecords, _profilesService.SelectedProfile.SqlServer);
        }

        private void SelectedRecordChanged(object sender, EventArgs<string> e)
        {
            var serverRecord = _sqlService.GetByName(e.Value);

            _view.SetSqlServerName(serverRecord.RecordName);
            _view.SetSqlInstance(serverRecord.SqlServer);
            _view.SetSqlUsername(serverRecord.SqlAdminUsername);
            _view.SetSqlPassword(serverRecord.SqlAdminPassword);
        }

        private async void TestClicked(object sender, EventArgs<ISqlServerRecord> e)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "ServerInstance", e.Value.SqlServer },
                { "Username", e.Value.SqlAdminUsername},
                { "Password", e.Value.SqlAdminPassword}
            };

            _view.ToggleControls(false);

            var script = await _remoteScriptCopier.CopyIfRemote(Settings.Scripts.TestSqlServerConnection);
            await _scriptWrapper.Run(script, parameters);

            ValidateResult(_scriptWrapper.Results, _scriptWrapper.Errors.Select(ex => ex.Message));

            _view.ToggleControls(true);
        }

        private void ValidateResult(IEnumerable<PSObject> results, IEnumerable<string> errors)
        {
            if (!results.Any())
            {
                _view.ShowError(Messages.SqlSettings.Caption, Messages.SqlSettings.Errors.NoResults);
                return;
            }

            if (_fakesHelper.ValidateQueryTime(results.Last()))
            {
                _view.ShowInfo(Messages.SqlSettings.Caption, Messages.General.Success);
            }

            if (errors.Any())
            {
                _view.ShowError(Messages.SqlSettings.Caption, errors.First());
            }
        }

        private void SqlRecordAdded(object sender, EventArgs<ISqlServerRecord> e)
        {
            _sqlService.Add(e.Value);
            _sqlService.Save();

            _profilesService.AssignSqlServer(e.Value.RecordName);
            _profilesService.Save();

            _view.CloseDialog();
        }

        private void SqlRecordRenamed(object sender, EventArgs<Tuple<string, ISqlServerRecord>> e)
        {
            _sqlService.UpdateSelected(e.Value.Item1, e.Value.Item2);
            _sqlService.Save();

            _profilesService.AssignSqlServer(e.Value.Item1);
            _profilesService.Save();

            _view.CloseDialog();
        }

        private void SqlRecordDeleted(object sender, EventArgs<string> e)
        {
            _sqlService.Delete(e.Value);
            _sqlService.Save();

            _profilesService.AssignSqlServer(String.Empty);
            _profilesService.Save();

            _view.PopulateServersDropdown(ServerRecords, _profilesService.SelectedProfile.SqlServer);
        }
        private void ClosingForm(object sender, EventArgs e)
        {
            _scriptWrapper.Finish();
        }
    }
}
