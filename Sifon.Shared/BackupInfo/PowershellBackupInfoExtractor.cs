using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.PowerShell;
using Sifon.Shared.Statics;

namespace Sifon.Shared.BackupInfo
{
    public class PowershellBackupInfoExtractor : IBackupInfoExtractor
    {
        private readonly IProfile _profile;
        private readonly ISynchronizeInvoke _invoke;
        private readonly ScriptWrapper<string> _scriptWrapper;
        private readonly RemoteScriptCopier _remoteScriptCopier;

        public PowershellBackupInfoExtractor(IProfile profile, ISynchronizeInvoke invoke)
        {
            _profile = profile;
            _invoke = invoke;

            _remoteScriptCopier = new RemoteScriptCopier(_profile, invoke);
            _scriptWrapper = new ScriptWrapper<string>(_profile, _invoke, d => d.ToString());
        }

        public async Task<bool> SaveToFile(BackupInfo backupInfo)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                {"xml", backupInfo.Serialize().ToString()},
                {"OutputFile", $@"{backupInfo.Webroot}\{Settings.BackupInfoFile}"}
            };

            var script =  _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.SaveBackupInfo);

            await _scriptWrapper.Run(script, parameters);
            return true;
        }

        public async Task<BackupInfo> GetFromArchive(string file)
        {
            var _folderToExtract = await _remoteScriptCopier.GetRemoteFolder();
            var parameters = new Dictionary<string, dynamic>
            {
                {"file", file},
                {"info", Settings.BackupInfoFile},
                {"extractToFile", $@"{_folderToExtract}\{Settings.BackupInfoFile}"}
            };

            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.GetBackupInfo);
            await _scriptWrapper.Run(script, parameters);

            return BackupInfoExtensions.Parse(_scriptWrapper.Results.FirstOrDefault());
        }
    }
}
