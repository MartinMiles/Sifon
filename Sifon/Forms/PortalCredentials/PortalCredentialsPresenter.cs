using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Events;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.PortalCredentials
{
    public class PortalCredentialsPresenter
    {
        private readonly IPortalCredentialsView _view;
        private readonly SettingsProvider _settingsProvider;

        private readonly ProfilesProvider _profilesService;
        private readonly ScriptWrapper<PSObject> _scriptWrapper;
        private readonly RemoteScriptCopier _remoteScriptCopier;

        public PortalCredentialsPresenter(IPortalCredentialsView view)
        {
            _view = view;
            _settingsProvider = new SettingsProvider();

            _view.FormLoad += FormLoad;
            _view.TestClicked += TestClicked;
            _view.ValuesChanged += ValuesChanged;

            _profilesService = new ProfilesProvider();
            _remoteScriptCopier = new RemoteScriptCopier(_profilesService.SelectedProfile, _view);
            _scriptWrapper = new ScriptWrapper<PSObject>(new ProfilesProvider().SelectedProfile, _view, d => d);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            var entity = _settingsProvider.Read();

            _view.SetTextboxValues(entity);
            // get data and set view
        }

        private void ValuesChanged(object sender, EventArgs<ISettingRecord> e)
        {
            _settingsProvider.Save(e.Value);
        }

        private async void TestClicked(object sender, EventArgs<ISettingRecord> e)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                { "PortalUsername", e.Value.PortalUsername},
                { "PortalPassword", e.Value.PortalPassword}
            };

            _view.ToggleControls(false);

            var script = await _remoteScriptCopier.CopyIfRemote(Settings.Scripts.TestPortalCredentials);
            await _scriptWrapper.Run(script, parameters);

            ValidateResult(_scriptWrapper.Results, _scriptWrapper.Errors.Select(ex => ex.Message));

            _view.ToggleControls(true);
        }

        private void ValidateResult(IEnumerable<PSObject> results, IEnumerable<string> errors)
        {
            if (!results.Any())
            {
                _view.ShowError(Messages.ProfileCredentials.Caption, Messages.ProfileCredentials.Errors.NoResults);
                return;
            }

            if (Convert.ToBoolean(results.Last().ToString()))
            {
                _view.ShowInfo(Messages.ProfileCredentials.Caption, Messages.ProfileCredentials.Success);
            }
            else
            {
                _view.ShowError(Messages.ProfileCredentials.Caption, Messages.ProfileCredentials.Errors.IncorrectCredentials);
            }

            if (errors.Any())
            {
                _view.ShowError(Messages.ProfileCredentials.Caption, errors.First());
            }
        }
    }
}
