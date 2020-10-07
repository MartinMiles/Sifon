using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sifon.Code.Helpers;
using Sifon.Code.Statics;

namespace Sifon.Code.BackupInfo
{
    public class LocalBackupInfoExtractor : IBackupInfoExtractor
    {
        public bool SaveToFileSync(BackupInfo backupInfo)
        {
            var doc = new XDocument();
            doc.Add(backupInfo.Serialize());
            doc.Save(Path.Combine(backupInfo.Webroot, Settings.BackupInfoFile));

            return true;
        }

        public BackupInfo GetFromArchiveSync(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (ZipArchive archive = ZipFile.OpenRead(fileName))
                {
                    var entry = archive.GetEntry(Settings.BackupInfoFile);
                    if (entry != null)
                    {
                        entry.ExtractToFile(Settings.CacheFolder.BackupInfo, true);

                        if (File.Exists(Settings.CacheFolder.BackupInfo))
                        {
                            var info = new BackupInfo(Settings.CacheFolder.BackupInfo);
                            File.Delete(Settings.CacheFolder.BackupInfo);

                            return info;
                        }
                    }
                }
            }

            return null;
        }

        public async Task<bool> SaveToFile(BackupInfo backupInfo)
        {
            return await TaskHelper<bool>.AsyncPattern(SaveToFileSync, backupInfo);
        }

        public async Task<BackupInfo> GetFromArchive(string fileName)
        {
            return await TaskHelper<BackupInfo>.AsyncPattern(GetFromArchiveSync, fileName);
        }
    }
}
