using System.Collections.Generic;

namespace Sifon.Code.Model
{
    public class PluginMenuItem
    {
        public PluginMenuItem()
        {
            Children = new List<PluginMenuItem>();
        }

        public string DirectoryName { get; set; }
        public string DirectoryFullPath { get; set; }
        public Dictionary<string, string> Plugins { get; set; }
        public Dictionary<string, string> Scripts { get; set; }

        public List<PluginMenuItem> Children { get; set; }

        public override string ToString()
        {
            return DirectoryName;
        }
    }
}
