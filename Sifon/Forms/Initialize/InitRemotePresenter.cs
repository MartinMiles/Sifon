using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;
using Sifon.Code.PowerShell;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;

namespace Sifon.Forms.Initialize
{
    internal class InitRemotePresenter
    {
        private readonly InitRemoteView _view;
        private readonly ScriptWrapper<string> _scriptWrapper;
        protected readonly IProfilesProvider __profileProvider;
        private readonly IProfile _profile;
        private readonly Dictionary<string, dynamic> _parameters;

        // fake profile is initially passed: always runs local, also passes credentials
        public InitRemotePresenter(InitRemoteView view, IRemoteSettings remoteSettings)
        {
            _view = view;
            __profileProvider = Create.New<IProfilesProvider>();

            _profile = __profileProvider.CreateLocal();
            _parameters = CreateParameters(remoteSettings);

            _view.FormLoaded += FormLoaded;

            _scriptWrapper = new ScriptWrapper<string>(_profile, _view, d => d?.ToString());
            _scriptWrapper.ProgressReady += ProgressReady;
            _scriptWrapper.ErrorReady += ErrorReady;
        }

        private async void FormLoaded(object sender, EventArgs e)
        {
            await _scriptWrapper.Run(Settings.Scripts.Remote.Initialize, _parameters);

            var result = _scriptWrapper.Results.FirstOrDefault();
            var excp = _scriptWrapper.Errors.FirstOrDefault();
            var errorMessage = excp is PSRemotingTransportException ? excp.Message : String.Empty;

            if (!string.IsNullOrWhiteSpace(result) && result.Contains("|"))
            {
                var folders = result.Split('|');
                _view.ScriptComplete(folders[0], folders[1], errorMessage);
            }
        }

        private void ErrorReady(Exception exception)
        {
            if (exception is PSRemotingTransportException)
            {
                _scriptWrapper.Finish();
            }
        }

        private void ProgressReady(ProgressRecord data)
        {
            if (data.Activity == Settings.Initialize.ProgressActivityName)
            {
                _view.UpdateProgressBar(data.PercentComplete, $"{data.Activity} - {data.StatusDescription}");
            }
        }

        private Dictionary<string, dynamic> CreateParameters(IRemoteSettings remoteSettings)
        {
            return new Dictionary<string, dynamic>
            {
                {"Activity", Settings.Initialize.ProgressActivityName},
                {"RemoteHost", remoteSettings.RemoteHost},
                {"Credentials", new PSCredential(remoteSettings.RemoteUsername, remoteSettings.RemotePassword.ToSecureString())},
                {"RemoteDirectory", Settings.RemoteDirectory},
                {"ModuleFiles", Modules.ToBeCopiedToRemote},
            };
        }
    }
}
