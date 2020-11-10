using System.ComponentModel;
using Sifon.Abstractions.Filesystem;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Filesystem;

namespace Sifon.Code.Factories
{
    // 1. Enforce local filesystem          -  Create.Filesystem.Local()
    // 2. Without profile (take current)    -  Create.Filesystem.WithCurrentProfile(invoker)
    // 3. With specific profile             -  Create.Filesystem.WithSpecificProfile(profile, invoker)

    public static partial class Create
    {
        public static class Filesystem
        {
            public static IFilesystem Local()
            {
                return new LocalFilesystem();
            }

            public static IFilesystem WithSpecificProfile(IProfile profile, ISynchronizeInvoke invoker)
            {
                return GetFilesystem(profile, invoker);
            }

            public static IFilesystem WithCurrentProfile(ISynchronizeInvoke invoker)
            {
                var profile = New<IProfilesProvider>().SelectedProfile;
                return WithSpecificProfile(profile, invoker);
            }

            private static IFilesystem GetFilesystem(IProfile profile, ISynchronizeInvoke invoker)
            {
                return profile.RemotingEnabled
                    ? (IFilesystem)new RemoteFilesystem(profile, invoker)
                    : new LocalFilesystem();
            }
        }
    }
}
