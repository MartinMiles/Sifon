using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Sifon.Shared.Forms.PackageVersionSelectorDialog
{
    public partial class PackageVersionSelector : Form
    {
        private IEnumerable<Item> _items;

        public PackageVersionSelector()
        {
            InitializeComponent();
        }

        // An entry point to this control
        public string[][] GetFile(string json)
        {
            StartPosition = FormStartPosition.CenterParent;

            _items = ReadJson(json);

            if (_items != null)
            {
                if (ShowDialog() == DialogResult.OK)
                {
                    return Urls.Select(kvp => new[] { kvp.Key, kvp.Value }).ToArray();
                }
            }

            return null;
        }

        private IEnumerable<Item> ReadJson(string jsonFile)
        {
            if (File.Exists(jsonFile))
            {
                using (var r = new StreamReader(jsonFile))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Item>>(json);
                }
            }

            return null;
        }

        private void PackageVersionSelector_Load(object sender, EventArgs e)
        {
            buttonSelect.Select();
            PopulateInstancesDropdown(_items);
        }

        public void PopulateInstancesDropdown(IEnumerable<Item> items)
        {
            comboVersions.Items.Clear();

            comboVersions.ValueMember = "url";
            comboVersions.DisplayMember = "name";
            comboVersions.DataSource = items;

            if (comboVersions.Items.Count > 0)
            {
                comboVersions.SelectedIndex = 0;
            }

            buttonSelect.Enabled = comboVersions.Items.Count > 0;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private IDictionary<string, string> Urls
        {
            get
            {
                var urls = new Dictionary<string, string>();

                if (comboVersions.SelectedItem != null)
                {
                    var item = comboVersions.SelectedItem as Item;
                    if (item != null)
                    {
                        if (item.dependencies != null)
                        {
                            foreach (var subitem in item.dependencies)
                            {
                                urls.Add(subitem.name, subitem.url);
                            }
                        }

                        urls.Add(item.name, item.url);
                    }
                }

                return urls;
            }
        }
    }

    public class Item
    {
        public string name { get; set; }
        public string url { get; set; }
        public List<Item> dependencies { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
