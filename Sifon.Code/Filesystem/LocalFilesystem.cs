using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Filesystem;
using Sifon.Code.Helpers;
using Sifon.Code.VersionSelector;

namespace Sifon.Code.Filesystem
{
    public class LocalFilesystem : IFilesystem
    {
        public async Task<bool> DirectoryExists(string siteName)
        {
            return await TaskHelper<bool>.AsyncPattern(Directory.Exists, siteName);
        }

        public Dictionary<string, string> GetFiles(string selectedFolder, string wildcard)
        {
            return Directory.GetFiles(selectedFolder, $"*{wildcard}")
                .ToDictionary(f=>new FileInfo(f).FullName, f=>new FileInfo(f).Name);
        }

        public Dictionary<string, string> GetDirectories(string parentNodeFullPath)
        {
            return Directory.GetDirectories(parentNodeFullPath)
                .ToDictionary(k => new FileInfo(k).FullName, v => new FileInfo(v).Name);
        }

        public async Task<Dictionary<string, DriveType>> GetDrives()
        {
            return await TaskHelper<Dictionary<string, DriveType>>.AsyncPattern(GetDrivesSync);
        }

        public Dictionary<string, DriveType> GetDrivesSync()
        {
            return DriveInfo.GetDrives().ToDictionary(k => k.Name, v => v.DriveType);
        }

        public async Task<string> GetDirectoryName(string directoryPath)
        {
            return await TaskHelper<string>.AsyncPattern(GetDirectoryNameSync, directoryPath);
        }

        public string GetDirectoryNameSync(string nodeFullPath)
        {
            return new DirectoryInfo(nodeFullPath).Name;
        }
        
        public async Task<bool> CreateDirectory(string directoryPath)
        {
            return await TaskHelper<bool>.AsyncPattern(CreateDirectorySync, directoryPath);
        }

        public bool CreateDirectorySync(string directoryPath)
        {
            try
            {
                Directory.CreateDirectory(directoryPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDirectory(string directory)
        {
            return await TaskHelper<bool>.AsyncPattern(DeleteDirectorySync, directory);
        }

        public async Task<bool> DeleteFile(string directory)
        {
            return await TaskHelper<bool>.AsyncPattern(DeleteFileSync, directory);
        }

        public bool DeleteFileSync(string file)
        {
            try
            {
                File.Delete(file);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDirectorySync(string directory)
        {
            try
            {
                Directory.Delete(directory);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RenameDirectory(string oldFileFullPath, string newFullPath)
        {
            return await TaskHelper<bool>.AsyncPattern(RenameDirectorySync, oldFileFullPath, newFullPath);
        }

        public bool RenameDirectorySync(string oldFileFullPath, string newFullPath)
        {
            try
            {
                Directory.Move(oldFileFullPath, newFullPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetHashMd5(string kernelPath)
        {
            var hashProvider = new HashProvider();
            return await TaskHelper<string>.AsyncPattern(hashProvider.CalculateMD5, kernelPath);
        }

        public async Task<string> ReadTextFile(string filePath)
        {
            await Task.CompletedTask;

            if (!File.Exists(filePath)) return null;

            return File.ReadAllText(filePath);
        }

        public async Task SaveTextFile(string filePath, string content)
        {
            await Task.CompletedTask;

        }
    }
}