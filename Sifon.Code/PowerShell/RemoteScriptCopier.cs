using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;
using Sifon.Code.Factories;

namespace Sifon.Code.PowerShell
{
    internal class RemoteScriptCopier : IRemoteScriptCopier
    {
        private readonly IProfile _profile;
        private readonly string _remoteMachine;
        private readonly string _username;
        private readonly string _password;

        private readonly ScriptWrapper<string> _scriptWrapper;

        internal RemoteScriptCopier(IProfile profile, ISynchronizeInvoke invoke)
        {
            _profile = profile;
            _remoteMachine = profile.RemoteHost;
            _username = profile.RemoteUsername;
            _password = profile.RemotePassword;

            var fakeLocalProfile = Create.New<IProfilesProvider>().CreateLocal();
            _scriptWrapper = new ScriptWrapper<string>(fakeLocalProfile, invoke, d => d?.ToString());
        }
        
        public async Task<string> CopyIfRemote(string scriptPath)
        {
            if (_profile.RemotingEnabled)
            {
                //TODO: Improve remote scripting: Modules.Functions.CopyFileToRemote is called twice - to obtain folder and then to send into
                var remoteFolder = await GetRemoteFolder();
                if (remoteFolder == null) return null;

                var parameters = Parameters;
                parameters.Add("Filename", scriptPath);
                parameters["RemoteDirectory"] = remoteFolder;
                await _scriptWrapper.Run(Modules.Functions.CopyFileToRemote, parameters);
                return _scriptWrapper.Results.FirstOrDefault();
            }

            return scriptPath;
        }

        public async Task<string> GetRemoteFolder()
        {
            await _scriptWrapper.Run(Modules.Functions.CopyFileToRemote, Parameters);
            return _scriptWrapper.Results.FirstOrDefault();
        }

        Dictionary<string, dynamic> Parameters => new Dictionary<string, dynamic>
        {
            {"RemoteHost", _remoteMachine},
            {"Credentials", new PSCredential(_username, _password.ToSecureString())},
            {"RemoteDirectory", Settings.RemoteDirectory}
        };
    }
}
