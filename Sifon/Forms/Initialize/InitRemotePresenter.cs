using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;

namespace Sifon.Forms.Initialize
{
    public class InitRemotePresenter
    {
        private readonly InitRemoteView _view;
        private readonly ScriptWrapper<string> _scriptWrapper;
        protected readonly ProfilesProvider _profileService;
        private readonly IProfile _profile;
        private readonly Dictionary<string, dynamic> _parameters;

        // fake profile is initially passed: always runs local, also passes credentials
        public InitRemotePresenter(InitRemoteView view, IRemoteSettings remoteSettings)
        {
            _view = view;
            _profileService = new ProfilesProvider();

            _profile = _profileService.CreateLocal();
            _parameters = CreateParameters(remoteSettings);

            _view.FormLoaded += FormLoaded;
            _scriptWrapper = new ScriptWrapper<string>(_profile, _view, d => d?.ToString());
            _scriptWrapper.ProgressReady += ProgressReady;
            _scriptWrapper.ErrorReady += ErrorReady;
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

        private async void FormLoaded(object sender, EventArgs e)
        {
            await _scriptWrapper.Run(Settings.Scripts.InitializeRemote, _parameters);

            var result = _scriptWrapper.Results.FirstOrDefault();
            var excp = _scriptWrapper.Errors.FirstOrDefault();
            var errorMessage = excp is PSRemotingTransportException ? excp.Message : String.Empty;

            _view.ScriptComplete(result, errorMessage);
        }

        private Dictionary<string, dynamic> CreateParameters(IRemoteSettings remoteSettings)
        {
            return new Dictionary<string, dynamic>
            {
                {"Activity", Settings.Initialize.ProgressActivityName},
                {"RemoteHost", remoteSettings.RemoteHostname},
                {"Username", remoteSettings.RemoteUsername},
                {"Password", remoteSettings.RemotePassword},
                {"RemoteDirectory", Settings.RemoteDirectory},
                {"Filenames", FilesToBeCopiedToRemote},
            };
        }

        private string[] FilesToBeCopiedToRemote => new []{
            Settings.Scripts.GetSiteBindings,
            Settings.Scripts.GetBackupInfo,
            Settings.Scripts.GetSitecoreSites,
            Settings.Scripts.RestoreInstance,
            Settings.Scripts.RetrieveDatabases,
            Settings.Scripts.RetrieveSolr,
            Settings.Scripts.SaveBackupInfo,
            Settings.Scripts.GetSitePath,
            Settings.Scripts.TestSolr,
            Settings.Scripts.TestSqlServerConnection,
            Settings.Scripts.GetXconnectFolder,
            Settings.Scripts.GetCommerceSites,
            Settings.Scripts.GetCommerceDatabases,

            Settings.Scripts.Filesystem.RenameDirectory,
            Settings.Scripts.Filesystem.CreateDirectory,
            Settings.Scripts.Filesystem.DeleteDirectory,
            Settings.Scripts.Filesystem.DeleteFile,
            Settings.Scripts.Filesystem.GetDirectory,
            Settings.Scripts.Filesystem.GetDrives,
            Settings.Scripts.Filesystem.GetFiles,
            Settings.Scripts.Filesystem.VerifyDirectory
        };
    }
}
