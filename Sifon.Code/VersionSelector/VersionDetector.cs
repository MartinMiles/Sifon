using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Sifon.Abstractions.Filesystem;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.VersionSelector;
using Sifon.Code.Factories;


namespace Sifon.Code.VersionSelector
{
    public class VersionDetector
    {
        private readonly IFilesystem _filesystem;

        public VersionDetector(IProfile profile, ISynchronizeInvoke invoke)
        {
            _filesystem = Create.WithProfile<IFilesystem>(profile, invoke);
        }

        public async Task<IKernelHash> Identify(string kernelPath)
        {
            string hash = await _filesystem.GetHashMd5(kernelPath);
            var kernelHash = Settings.Hashes.FirstOrDefault(h => h.Original == hash) ?? Settings.Hashes.First();
            return kernelHash;
        }
    }
}
