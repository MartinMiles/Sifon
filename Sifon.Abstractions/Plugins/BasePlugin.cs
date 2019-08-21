using System;
using System.Threading;
using Sifon.Abstractions.Profiles;

namespace Sifon.Abstractions.Plugins
{
    public abstract class BasePlugin
    {
        protected IProfile Profile;

        protected BasePlugin(IProfile profile)
        {
            Profile = profile ?? throw new NullReferenceException("Parameter passed into a plugin should be IProfile and not null");
        }

        public abstract void Execute();

        public CancellationTokenSource CancellationTokenSource { get; set; }

        public IProgress<PluginProgress> Progress { get; set; }
    }
}
