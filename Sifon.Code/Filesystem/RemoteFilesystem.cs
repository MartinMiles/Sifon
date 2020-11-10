using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sifon.Abstractions.Filesystem;
using Sifon.Abstractions.Profiles;
using Sifon.Code.PowerShell;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;

namespace Sifon.Code.Filesystem
{
    public class RemoteFilesystem : IFilesystem
    {
        private readonly ScriptWrapper<bool> _scriptWrapperBool;
        private readonly ScriptWrapper<string> _scriptWrapper;
        private readonly ScriptWrapper<Model.Fake.DriveInfo> _scriptWrapperDrive;
        private readonly ScriptWrapper<Model.Fake.DirectoryInfo> _scriptWrapperDirectory;
        
        public RemoteFilesystem(IProfile profile, ISynchronizeInvoke invoke)
        {
            _scriptWrapperBool = new ScriptWrapper<bool>(profile, invoke, d => bool.Parse(d.ToString()));
            _scriptWrapper = new ScriptWrapper<string>(profile, invoke, d => d.ToString());
            _scriptWrapperDrive = new ScriptWrapper<Model.Fake.DriveInfo>(profile, invoke, Convert<Model.Fake.DriveInfo>);
            _scriptWrapperDirectory = new ScriptWrapper<Model.Fake.DirectoryInfo>(profile, invoke, Convert<Model.Fake.DirectoryInfo>);
        }

        public async Task<bool> CreateDirectory(string directoryPath)
        {
            await _scriptWrapperDirectory.Run("New-Item", new Dictionary<string, dynamic> {{ "ItemType", "directory" }, { "Path", directoryPath }});
            return _scriptWrapperDirectory.Results.Any();
        }

        public async Task<bool> DeleteDirectory(string directoryPath)
        {
            await _scriptWrapperBool.Run("Remove-Item", new Dictionary<string, dynamic> {{ "LiteralPath", directoryPath },{"Force",null},{ "Recurse",null}});
            return !_scriptWrapperBool.Errors.Any();
        }

        public async Task<bool> DeleteFile(string file)
        {
            await _scriptWrapperBool.Run("Remove-Item", new Dictionary<string, dynamic> {{ "Path", file },{ "Force", null },{ "Recurse", null }});
            return _scriptWrapperBool.Results.FirstOrDefault();
        }

        public async Task<bool> DirectoryExists(string directoryPath)
        {
            await _scriptWrapperBool.Run("Test-Path", new Dictionary<string, dynamic> { { "Path", directoryPath } });
            return _scriptWrapperBool.Results.FirstOrDefault();
        }

        public async Task<bool> RenameDirectory(string oldPath, string newPath)
        {
            var parameters = new Dictionary<string, dynamic> {{ "path", oldPath }, { "newName", newPath }};
            await _scriptWrapperBool.Run("Rename-Item", parameters);
            return _scriptWrapperBool.Results.FirstOrDefault();
        }
      
        private T Convert<T>(PSObject psObject)
        {
            var serialized = JsonConvert.SerializeObject(psObject.Properties.ToDictionary(k => k.Name, v => v.Value));
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public async Task<Dictionary<string, DriveType>> GetDrives()
        {
            await _scriptWrapperDrive.Run(Modules.Functions.GetDrives);
            return _scriptWrapperDrive.Results.ToDictionary(d => d.Name, d => d.DriveType);
        }

        public Dictionary<string, string> GetDirectories(string directoryPath)
        {
            var fullNames = GetFilesystemObjects(directoryPath, "Directory");

            var dictionary = new Dictionary<string, string>();
            foreach (var fullName in fullNames)
            {
                var info = new DirectoryInfo(fullName);
                dictionary.Add(info.FullName, info.Name);
            }

            return dictionary;
        }

        public Dictionary<string, string> GetFiles(string directoryPath, string extensionFilter = null)
        {
            IEnumerable<string> fullNames = GetFilesystemObjects(directoryPath, "File");

            var dictionary = new Dictionary<string, string>();
            foreach (var fullName in fullNames)
            {
                var info = new FileInfo(fullName);
                if (!extensionFilter.NotEmpty() || info.FullName.EndsWith(extensionFilter, true, CultureInfo.InvariantCulture))
                {
                    dictionary.Add(info.FullName, info.Name);
                }
            }

            return dictionary;
        }

        public async Task<string> GetDirectoryName(string directoryPath)
        {
            await _scriptWrapperDirectory.Run("Get-Item", new Dictionary<string, dynamic> {{ "Path", directoryPath }});
            return _scriptWrapperDirectory.Results.FirstOrDefault()?.Name;
        }

        private IEnumerable<string> GetFilesystemObjects(string directoryPath, string parameter)
        {
            var parameters = new Dictionary<string, dynamic> { { "Type", parameter }, { "Directory", directoryPath } };
            _scriptWrapper.RunSync(Modules.Functions.GetFiles, parameters);
            return _scriptWrapper.Results;
        }

        public async Task<string> GetHashMd5(string kernelPath)
        {
            var parameters = new Dictionary<string, dynamic> { { "Filepath", kernelPath } };
            await _scriptWrapper.Run(Modules.Functions.GetHashMD5, parameters);
            return _scriptWrapper.Results.FirstOrDefault();
        }
    }
}
