using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Extensions;
using Sifon.Shared.Model.Profiles;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;

namespace Sifon.Shared.PowerShell
{
    public class RemoteScriptCopier
    {
        private readonly IProfile _profile;
        private readonly string _remoteMachine;
        private readonly string _username;
        private readonly string _password;

        private readonly ScriptWrapper<string> _scriptWrapper;

        public RemoteScriptCopier(IProfile profile, ISynchronizeInvoke invoke)
        {
            _profile = profile;
            _remoteMachine = profile.RemoteHost;
            _username = profile.RemoteUsername;
            _password = profile.RemotePassword;

            var fakeLocalProfile = new ProfilesProvider().CreateLocal();
            _scriptWrapper = new ScriptWrapper<string>(fakeLocalProfile, invoke, d => d.ToString());
        }
        
        public string UseProfileFolderIfRemote(string scriptPath)
        {
            return _profile.RemotingEnabled && _profile.RemoteFolder.NotEmpty() 
                ? Path.Combine(_profile.RemoteFolder, Path.GetFileName(scriptPath))
                : scriptPath;
        }

        public async Task<string> CopyIfRemote(string scriptPath)
        {
            if (_profile.RemotingEnabled)
            {
                var parameters = Parameters;
                parameters.Add("Filename", scriptPath);
                await _scriptWrapper.Run(Settings.Scripts.CopyToRemote, parameters);
                return _scriptWrapper.Results.FirstOrDefault();
            }

            return scriptPath;
        }

        public async Task<string> GetRemoteFolder()
        {
            await _scriptWrapper.Run(Settings.Scripts.CopyToRemote, Parameters);
            return _scriptWrapper.Results.FirstOrDefault();
        }

        Dictionary<string, dynamic> Parameters => new Dictionary<string, dynamic>
        {
            {"RemoteHost", _remoteMachine},
            {"Username", _username},
            {"Password", _password},
            {"RemoteDirectory", Settings.RemoteDirectory}
        };
    }
}
