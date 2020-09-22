using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Sifon.Abstractions.Encryption;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Encryption;
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

        private readonly ScriptWrapper<PSObject> _scriptWrapper;
        private readonly RemoteScriptCopier _remoteScriptCopier;
        private readonly IEncryptor _encryptor;

        public PortalCredentialsPresenter(IPortalCredentialsView view)
        {
            _view = view;
            _settingsProvider = new SettingsProvider();

            _view.FormLoad += FormLoad;
            _view.TestClicked += TestClicked;
            _view.ValuesChanged += ValuesChanged;

            var selectedProfile = new ProfilesProvider().SelectedProfile;
            _remoteScriptCopier = new RemoteScriptCopier(selectedProfile, _view);
            _scriptWrapper = new ScriptWrapper<PSObject>(selectedProfile, _view, d => d);

            _encryptor = new Encryptor();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            var entity = _settingsProvider.Read();

            if (!string.IsNullOrWhiteSpace(entity.PortalPassword))
            {
                entity.PortalPassword = _encryptor.Decrypt(entity.PortalPassword);
            }

            _view.SetTextboxValues(entity);
        }

        private void ValuesChanged(object sender, EventArgs<ISettingRecord> e)
        {
            e.Value.PortalPassword = _encryptor.Encrypt(e.Value.PortalPassword);
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
