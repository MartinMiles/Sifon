using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sifon.Code.VersionSelector;

namespace Sifon.Code.Forms.VersionSelectorDialog
{
    public partial class VersionSelector : Form
    {
        public string KernelPath { private get; set; }

        private readonly HashProvider _hashProvider;

        public string SelectedVersion { get; private set; }

        public VersionSelector()
        {
            InitializeComponent();

            _hashProvider = new HashProvider();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            PopulateDropbox();

            comboVersions.SelectedIndex = 0;

            if (!File.Exists(KernelPath))
            {
                MessageBox.Show($"File does not exist at path: \n {KernelPath}", "Kernel missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var hash = _hashProvider.CalculateMD5(KernelPath);

                var kernelHash = Settings.Hashes.FirstOrDefault(h => h.Original == hash);

                if (kernelHash != null)
                {
                    comboVersions.SelectedItem = kernelHash.Version;
                    versionLabel.Text = versionLabel.Text.Replace(":", " (automatically detected:");
                }
            }
        }

        private void PopulateDropbox()
        {
            comboVersions.Items.Clear();
            comboVersions.Items.Add("=== not detected ===");

            foreach (var version in Settings.Hashes.Select(h => h.Version))
            {
                comboVersions.Items.Add(version);
            }
        }

        private void buttonPatch_Click(object sender, EventArgs e)
        {
            SelectedVersion = comboVersions.SelectedIndex > 0 ? comboVersions.SelectedItem.ToString() : String.Empty;
        }
    }
}
