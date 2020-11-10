using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;
using Sifon.Code.Statics;
using Sifon.Statics;
using Sifon.Code.Model.Fake;

namespace Sifon.Forms.SqlSettings
{
    internal class SqlSettingsPresenter
    {
        private readonly ISqlSettingsView _view;
        private readonly ISqlServerRecordProvider _sqlService;
        private readonly IProfilesProvider _profilesProvider;
        private readonly IScriptWrapper<PSObject> _scriptWrapper;

        internal SqlSettingsPresenter(ISqlSettingsView sqlSettingsView)
        {
            _view = sqlSettingsView;
            _sqlService = Create.New<ISqlServerRecordProvider>();
            _profilesProvider = Create.New<IProfilesProvider>();

            _view.FormLoad += FormLoad;
            _view.TestClicked += TestClicked;
            _view.SelectedRecordChanged += SelectedRecordChanged;
            _view.SqlRecordAdded += SqlRecordAdded;
            _view.SqlRecordRenamed += SqlRecordRenamed;
            _view.SqlRecordDeleted += SqlRecordDeleted;
            _view.ClosingForm += ClosingForm;

            _scriptWrapper = Create.WithParam(_view, d => d);
        }

        private IEnumerable<string> ServerRecords => _sqlService.Read().Select(s => s.RecordName);

        private void FormLoad(object sender, EventArgs e)
        {
            _view.PopulateServersDropdown(ServerRecords, _profilesProvider.SelectedProfile.SqlServer);
            _view.ToggleRemoteWarning(_profilesProvider.SelectedProfile.RemotingEnabled);
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
            _view.ToggleControls(false);

            var parameters = new Dictionary<string, dynamic> {{ Settings.Parameters.ServerInstance, e.Value.SqlServer }};
            var credentials = new PSCredential(e.Value.SqlAdminUsername, e.Value.SqlAdminPassword.ToSecureString());
            parameters.Add(Settings.Parameters.SqlCredentials, credentials);
            
            await _scriptWrapper.Run(Modules.Functions.TestSqlServerConnection, parameters);

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

            if (ValidateQueryTime(results.Last()))
            {
                _view.ShowInfo(Messages.SqlSettings.Caption, Messages.General.Success);
            }

            if (errors.Any())
            {
                _view.ShowError(Messages.SqlSettings.Caption, errors.First());
            }
        }

        private bool ValidateQueryTime(PSObject psObject)
        {
            var queryTime = psObject.Convert<QueryTime>();
            if (queryTime != null && queryTime.TimeOfQuery != DateTime.MinValue)
            {
                return true;
            }

            return false;
        }

        private void SqlRecordAdded(object sender, EventArgs<ISqlServerRecord> e)
        {
            _sqlService.Add(e.Value);
            _sqlService.Save();

            _profilesProvider.AssignSqlServer(e.Value.RecordName);
            _profilesProvider.Save();

            _view.CloseDialog();
        }

        private void SqlRecordRenamed(object sender, EventArgs<Tuple<string, ISqlServerRecord>> e)
        {
            _sqlService.UpdateSelected(e.Value.Item1, e.Value.Item2);
            _sqlService.Save();

            _profilesProvider.AssignSqlServer(e.Value.Item1);
            _profilesProvider.Save();

            _view.CloseDialog();
        }

        private void SqlRecordDeleted(object sender, EventArgs<string> e)
        {
            _sqlService.Delete(e.Value);
            _sqlService.Save();

            _profilesProvider.AssignSqlServer(String.Empty);
            _profilesProvider.Save();

            _view.PopulateServersDropdown(ServerRecords, _profilesProvider.SelectedProfile.SqlServer);
        }
        private void ClosingForm(object sender, EventArgs e)
        {
            _scriptWrapper.Finish();
        }
    }
}
