using System.Threading;
using Sifon.Abstractions.Plugins;
using Sifon.Abstractions.Profiles;

namespace Sifon.Plugins.Example.LongRunningPlugin
{
    public class LongRunningPlugin : BasePlugin, IPlugin
    {
        public LongRunningPlugin(IProfile profile) : base(profile)
        {
        }

        public string Name => "Long running plugin";

        public override void Execute()
        {
            int loop = 100;
            int result = 0;
            
            for (int i = 0; i <= loop; i++)
            {
                Thread.Sleep(100);
                result += i;
                CancellationTokenSource.Token.ThrowIfCancellationRequested();

                Progress.Report(new PluginProgress($"Current activity: {Name.ToLower()}", i, $"Line {i}"));
            }
        }
    }
}
