using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sifon.Code.Filesystem
{
    public interface IFilesystem
    {
        Dictionary<string, string> GetDirectories(string parentNodeFullPath);

        Dictionary<string, string> GetFiles(string selectedFolder, string ext);

        Task<Dictionary<string, DriveType>> GetDrives();
        
        Task<string> GetDirectoryName(string nodeFullPath);

        Task<bool> CreateDirectory(string directoryPath);

        Task<bool> DirectoryExists(string selectedFolder);

        Task<bool> RenameDirectory(string oldFileFullPath, string newFullPath);

        Task<bool> DeleteFile(string directory);

        Task<bool> DeleteDirectory(string nodeFullPath);
    }
}
