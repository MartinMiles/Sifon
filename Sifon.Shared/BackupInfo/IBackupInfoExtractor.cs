using System.Threading.Tasks;

namespace Sifon.Code.BackupInfo
{
    public interface IBackupInfoExtractor
    {
        Task<bool> SaveToFile(BackupInfo backupInfo);

        Task<BackupInfo> GetFromArchive(string file);
    }
}
