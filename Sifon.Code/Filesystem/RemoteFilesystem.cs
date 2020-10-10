using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sifon.Abstractions.Profiles;
using Sifon.Code.PowerShell;
using Sifon.Code.Statics;
using Sifon.Code.Extensions;

namespace Sifon.Code.Filesystem
{
    public class RemoteFilesystem : IFilesystem
    {
        private readonly RemoteScriptCopier _remoteScriptCopier;
        private readonly ScriptWrapper<bool> _scriptWrapperBool;
        private readonly ScriptWrapper<string> _scriptWrapper;
        private readonly ScriptWrapper<Model.Fake.DriveInfo> _scriptWrapperDrive;
        private readonly ScriptWrapper<Model.Fake.DirectoryInfo> _scriptWrapperDirectory;
        
        public RemoteFilesystem(IProfile profile, ISynchronizeInvoke invoke)
        {
            _remoteScriptCopier = new RemoteScriptCopier(profile, invoke);
            _scriptWrapperBool = new ScriptWrapper<bool>(profile, invoke, d => bool.Parse(d.ToString()));
            _scriptWrapper = new ScriptWrapper<string>(profile, invoke, d => d.ToString());
            _scriptWrapperDrive = new ScriptWrapper<Model.Fake.DriveInfo>(profile, invoke, Convert<Model.Fake.DriveInfo>);
            _scriptWrapperDirectory = new ScriptWrapper<Model.Fake.DirectoryInfo>(profile, invoke, Convert<Model.Fake.DirectoryInfo>);
        }

        public async Task<bool> CreateDirectory(string directoryPath)
        {
            var script =  _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.CreateDirectory);
            await _scriptWrapperBool.Run(script, new Dictionary<string, dynamic> { { "Directory", directoryPath } });
            return _scriptWrapperBool.Results.FirstOrDefault();
        }

        public async Task<bool> DeleteDirectory(string directoryPath)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.DeleteDirectory);
            await _scriptWrapperBool.Run(script, new Dictionary<string, dynamic> { { "Directory", directoryPath } });
            return _scriptWrapperBool.Results.FirstOrDefault();
        }

        public async Task<bool> DeleteFile(string file)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.DeleteFile);
            await _scriptWrapperBool.Run(script, new Dictionary<string, dynamic> { { "File", file } });
            return _scriptWrapperBool.Results.FirstOrDefault();
        }


        public async Task<bool> DirectoryExists(string directoryPath)
        {
            string script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.VerifyDirectory);
            await _scriptWrapperBool.Run(script, new Dictionary<string, dynamic> { { "Directory", directoryPath } });
            return _scriptWrapperBool.Results.FirstOrDefault();
        }

        public async Task<bool> RenameDirectory(string oldPath, string newPath)
        {
            var script =  _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.RenameDirectory);
            var parameters = new Dictionary<string, dynamic> {{ "OldPath", oldPath }, { "NewPath", newPath }};
            await _scriptWrapperBool.Run(script, parameters);
            return _scriptWrapperBool.Results.FirstOrDefault();
        }
      
        private T Convert<T>(PSObject psObject)
        {
            var serialized = JsonConvert.SerializeObject(psObject.Properties.ToDictionary(k => k.Name, v => v.Value));
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public async Task<Dictionary<string, DriveType>> GetDrives()
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.GetDrives);
            await _scriptWrapperDrive.Run(script);
            return _scriptWrapperDrive.Results.ToDictionary(d => d.Name, d => d.DriveType);
        }

        public Dictionary<string, string> GetDirectories(string directoryPath)
        {
            IEnumerable<string> fullNames = GetFilesystemObjects(directoryPath, "Directory");

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
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.GetDirectory);
            await _scriptWrapperDirectory.Run(script, new Dictionary<string, dynamic> { { "Directory", directoryPath } });
            return _scriptWrapperDirectory.Results.FirstOrDefault()?.Name;
        }

        private IEnumerable<string> GetFilesystemObjects(string directoryPath, string parameter)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.GetFiles);
            var parameters = new Dictionary<string, dynamic> { { "Type", parameter }, { "Directory", directoryPath } };
            _scriptWrapper.RunSync(script, parameters);
            return _scriptWrapper.Results;
        }

        public async Task<string> GetHashMd5(string KernelPath)
        {
            var script = _remoteScriptCopier.UseProfileFolderIfRemote(Settings.Scripts.Filesystem.GetHashMD5);
            var parameters = new Dictionary<string, dynamic> { { "Filepath", KernelPath } };
            await _scriptWrapper.Run(script, parameters);
            return _scriptWrapper.Results.FirstOrDefault();
        }
    }
}
