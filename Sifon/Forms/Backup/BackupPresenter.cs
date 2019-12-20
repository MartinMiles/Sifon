using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Forms.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Statics;

namespace Sifon.Forms.Backup
{
    internal class BackupPresenter : BaseBackupRestorePresenter
    {
        private readonly IBackupView _view;
        private  ScriptWrapper<string> _scriptWrapper;

        private bool sitesReady = false;
        private bool daytabasesReady = false;

        internal BackupPresenter(IBackupView backupView) : base(backupView)
        {
            _view = backupView;
            _view.FormLoaded += Loaded;
            _view.InstanceChanged += async (s, e) => { await InstanceChanged(s, e as EventArgs<string>); };
            _view.ValidateBeforeClose += ValidateBeforeClose;
            _view.BeforeFormClosing += ClosingForm;
        }

        private async void Loaded(object sender, EventArgs e)
        {
            _view.ToggleControls(false);
            _view.EnableDisableMainButton(false);
            
            var instances = await _siteProvider.GetSitecoreSites();
            _view.PopulateInstancesDropdown(instances);

            _view.ToggleControls(true);
        }

        private async Task InstanceChanged(object sender, EventArgs<string> e)
        {
            _view.EnableDisableMainButton(false);

            _view.ToggleControls(false);

            var bindings = await _siteProvider.GetBindings(e.Value);
            _view.PopulateHostnamesListboxForSite(bindings);

            var xconnectFolder = await _siteProvider.GetXconnect(e.Value);
            var idsFolder = await _siteProvider.GetIDS(e.Value);
            var commerceSites = await _siteProvider.GetCommerceSites(e.Value);

            _view.SetXConnctAndIdentity(xconnectFolder, idsFolder, commerceSites.Select(s => new KeyValuePair<string, string>(s, s)));
            _view.SetCheckboxes(true, xconnectFolder.NotEmpty(), idsFolder.NotEmpty(), commerceSites.Any());

            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.RetrieveDatabases);

            var parameters = new Dictionary<string, dynamic>
            {
                { Settings.Parameters.ServerInstance, _profileService.SelectedProfileSql.SqlServer},
                { Settings.Parameters.InstancePrefix, _profileService.SelectedProfile.Prefix}
            };

            _scriptWrapper = new ScriptWrapper<string>(SelectedProfile, _view, d => d.ToString());
            await _scriptWrapper.Run(script, parameters);

            if (commerceSites.Any())
            {
                var commerceDatabases = await _siteProvider.GetCommerceDatabases(commerceSites.Last());
                _scriptWrapper.Results.AddRange(commerceDatabases.Results);
            }

            _view.PopulateDatabasesListboxForSite(_scriptWrapper.Results, _scriptWrapper.Errors.Select(ex=>ex.Message));

            _view.ToggleControls(true);
            _view.EnableDisableMainButton(true);
            _view.EnableDisableMainButton(null);
        }

        private void ClosingForm(object sender, EventArgs e)
        {
            _scriptWrapper?.Finish();
        }
    }
}
