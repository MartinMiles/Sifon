using System.ComponentModel;
using Sifon.Abstractions.Profiles;

namespace Sifon.Code.BackupInfo
{
    public class BackupInfoExtractorFactory
    {
        private readonly IProfile _profile;
        private readonly ISynchronizeInvoke _invoke;

        public BackupInfoExtractorFactory(IProfile profile, ISynchronizeInvoke invoke)
        {
            _profile = profile;
            _invoke = invoke;
        }

        public IBackupInfoExtractor Create()
        {
            return _profile.RemotingEnabled ? (IBackupInfoExtractor) new PowershellBackupInfoExtractor(_profile, _invoke) : new LocalBackupInfoExtractor();
        }
    }
}
