using System;
using System.Windows.Forms;
using Sifon.Abstractions.Plugins;
using Sifon.Abstractions.Profiles;

namespace Sifon.Plugins.Example.MinimalPlugin
{
    public class MinimalPlugin : BasePlugin, IPlugin
    {
        public MinimalPlugin(IProfile profile) : base(profile)
        {
        }

        public string Name => "Sample plugin";

        public override void Execute()
        {
            MessageBox.Show("Plugin perfectly works", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
