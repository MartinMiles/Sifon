using System.ComponentModel;
using Sifon.Abstractions.Profiles;

namespace Sifon.Code.Filesystem
{
    public class FilesystemFactory
    {
        private readonly IProfile _profile;
        private readonly ISynchronizeInvoke _invoker;

        public FilesystemFactory(IProfile profile, ISynchronizeInvoke invoker)
        {
            _profile = profile;
            _invoker = invoker;
        }

        public IFilesystem Create()
        {
            return _profile.RemotingEnabled ? (IFilesystem)new RemoteFilesystem(_profile, _invoker) : new LocalFilesystem();
        }
        public IFilesystem CreateLocal()
        {
            return new LocalFilesystem();
        }
    }
}
