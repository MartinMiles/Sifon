using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Profiles;
using Sifon.Code.PowerShell;
using Sifon.Code.Statics;

namespace Sifon.Code.BackupInfo
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

            await _scriptWrapper.Run(Modules.Functions.SaveBackupInfo, parameters);
            return true;
        }

        public async Task<BackupInfo> GetFromArchive(string file)
        {
            var folderToExtract = await _remoteScriptCopier.GetRemoteFolder();
            var parameters = new Dictionary<string, dynamic>
            {
                {"file", file},
                {"info", Settings.BackupInfoFile},
                {"extractToFile", $@"{folderToExtract}\{Settings.BackupInfoFile}"}
            };

            await _scriptWrapper.Run(Modules.Functions.ExtractBackupInfo, parameters);

            return BackupInfoExtensions.Parse(_scriptWrapper.Results.FirstOrDefault());
        }
    }
}
