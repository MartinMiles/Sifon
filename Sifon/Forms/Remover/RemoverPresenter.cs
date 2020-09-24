using System;
using System.Collections.Generic;
using System.Linq;
using Sifon.Abstractions.PowerShell;
using Sifon.Forms.Backup;
using Sifon.Forms.Base;
using Sifon.Shared.Events;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;

namespace Sifon.Forms.Remover
{
    internal class RemoverPresenter : BaseBackupRestorePresenter
    {
        private readonly IRemoverView _view;
        private readonly ScriptWrapper<string> _scriptWrapper;

        private IEnumerable<KeyValuePair<string, string>> commerceSites;

        internal RemoverPresenter(IRemoverView removerView) : base(removerView)
        {
            _view = removerView;

            _view.FormLoaded += Loaded;
            _view.InstanceChanged += InstanceChanged;
            _view.DatabaseFilterChanged += DatabaseFilterChanged;
            _view.BeforeFormClosing += ClosingForm;

            _scriptWrapper = new ScriptWrapper<string>(new ProfilesProvider().SelectedProfile, _view, d => d.ToString());
            _scriptWrapper.Complete += Complete;
        }

        private void Complete(IScriptRunner sender)
        {
            _view.FinishUI();
        }

        private async void Loaded(object sender, EventArgs e)
        {
            var instances = await _siteProvider.GetSitecoreSites();
            _view.PopulateInstancesDropdown(instances);
        }

        private void DatabaseFilterChanged(object sender, EventArgs<string> e)
        {
            UpdateDatabasesListbox(e.Value);
        }

        private async void UpdateDatabasesListbox(string filterValue)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                {"ServerInstance", _profileService.SelectedProfileSql.SqlServer},
                { "InstancePrefix", filterValue }
            };

            _view.ToggleControls(false);

            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.RetrieveDatabases);
            await _scriptWrapper.Run(script, parameters);

            if (commerceSites.Any())
            {
                var commerceDatabases = await _siteProvider.GetCommerceDatabases(commerceSites.Select(i => i.Key).Last());
                _scriptWrapper.Results.AddRange(commerceDatabases.Results);
            }

            _view.PopulateDatabasesListboxForSite(_scriptWrapper.Results.Where(d => !Settings.Databases.ForbiddenDatabases.Contains(d)), _scriptWrapper.Errors.Select(ex => ex.Message));

            _view.ToggleControls(true);
        }

        private async void InstanceChanged(object sender, EventArgs<string> e)
        {
            //var folderPath = await _siteProvider.GetSitePath(e.Value);
            //var xconnectFolder = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetXconnect(e.Value);
            //var idsFolder = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetIDS(e.Value);
            //var horizonFolder = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetHorizon(e.Value);
            //var publishingFolder = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetPublishingService(e.Value);

            commerceSites = (await _siteProvider.GetCommerceSites(e.Value)).Select(s => new KeyValuePair<string, string>(s, s));

            var model = new BackupViewModel();
            model.Sitecore = await _siteProvider.GetSitePath(e.Value);
            model.XConnect = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetXconnect(e.Value);
            model.Identity = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetIDS(e.Value);
            model.Horizon = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetHorizon(e.Value);
            model.Publishing = e.Value == Settings.ManualEntry ? String.Empty : await _siteProvider.GetPublishingService(e.Value);
            model.CommerceSites = commerceSites;

            _view.SetWebfoldersAndCheckboxes(model);

            string databaseSearchPrefix = e.Value == Settings.ManualEntry ? String.Empty : _profileService.SelectedProfile.Prefix;
            UpdateDatabasesListbox(databaseSearchPrefix);
        }

        private void ClosingForm(object sender, EventArgs e)
        {
            _scriptWrapper?.Finish();
        }
    }
}
