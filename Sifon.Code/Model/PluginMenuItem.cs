using System.Collections.Generic;
using System.Linq;

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


        public void Combine(PluginMenuItem second)
        {
            this.Children.AddRange(second.Children);
            Dedupe(this);

            this.Scripts = this.Scripts.Union(second.Scripts)
                .ToDictionary(k => k.Key, v => v.Value);

            //return first;
        }

        private void Dedupe(PluginMenuItem pmi)
        {
            var g = pmi.Children.GroupBy(p => p.DirectoryName);

            foreach (var grp in g)
            {
                if (grp.Count() > 1)
                {
                    var zeroItem = grp.ElementAt(0);

                    for (int i = 1; i < grp.Count(); i++)
                    {
                        zeroItem.Combine(grp.ElementAt(i));
                        pmi.Children.Remove(grp.ElementAt(i));
                    }
                }
            }
        }
    }
}
