using System.Threading.Tasks;

namespace Sifon.Shared.BackupInfo
{
    public interface IBackupInfoExtractor
    {
        Task<bool> SaveToFile(BackupInfo backupInfo);

        Task<BackupInfo> GetFromArchive(string file);
    }
}
