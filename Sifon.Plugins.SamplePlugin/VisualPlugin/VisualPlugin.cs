using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Abstractions.Plugins;
using Sifon.Abstractions.Profiles;

namespace Sifon.Plugins.Example.VisualPlugin
{
    public class VisualPlugin : BasePlugin, IPlugin
    {
        public string Name => "Visual plugin";

        public VisualPlugin(IProfile profile) : base(profile)
        {
        }

        public override void Execute()
        {
            var backupForm = new AdvancedPluginForm
            {
                StartPosition = FormStartPosition.CenterParent,
                Parameters = new Dictionary<string, string>
                {
                    {"Name", Profile.ProfileName},
                    {"Webroot", Profile.Webroot},
                    {"Website", Profile.Website},
                    {"Solr", Profile.Solr},
                    {"SqlServer Name", Profile.SqlServerRecord.RecordName},
                    {"SqlServer Instance", Profile.SqlServerRecord.SqlServer},
                    {"SqlServer Username", Profile.SqlServerRecord.SqlAdminUsername},
                    {"SqlServer Password", Profile.SqlServerRecord.SqlAdminPassword}
                }
            };

            if (backupForm.ShowDialog() == DialogResult.OK)
            {
            }
        }
    }
}