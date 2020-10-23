using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Events;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;
using Sifon.Statics;

namespace Sifon.Forms.PortalCredentials
{
    internal class PortalCredentialsPresenter
    {
        private readonly IPortalCredentialsView _view;
        private readonly SettingsProvider _settingsProvider;

        private readonly ScriptWrapper<PSObject> _scriptWrapper;

        public PortalCredentialsPresenter(IPortalCredentialsView view)
        {
            _view = view;
            _settingsProvider = new SettingsProvider();

            _view.FormLoaded += FormLoad;
            _view.TestClicked += TestClicked;
            _view.ValuesChanged += ValuesChanged;

            var selectedProfile = new ProfilesProvider().SelectedProfile;
            _scriptWrapper = new ScriptWrapper<PSObject>(selectedProfile, _view, d => d);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            var entity = _settingsProvider.Read();
            _view.SetTextboxValues(entity);
        }

        private void ValuesChanged(object sender, EventArgs<IPortalCredentials> e)
        {
            _settingsProvider.SaveCredentials(e.Value);
        }

        private async void TestClicked(object sender, EventArgs<IPortalCredentials> e)
        {
            var parameters = new Dictionary<string, dynamic>();
            _settingsProvider.TestScriptSettingsParameters(parameters, e.Value.PortalUsername, e.Value.PortalPassword);
           
            _view.ToggleControls(false);

            await _scriptWrapper.Run(Modules.Functions.TestPortalCredentials, parameters);

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
        }
    }
}
