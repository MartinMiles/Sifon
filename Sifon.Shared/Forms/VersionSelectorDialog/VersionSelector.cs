using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.VersionSelector;
using Sifon.Code.VersionSelector;

namespace Sifon.Shared.Forms.VersionSelectorDialog
{
    public partial class VersionSelector : Form
    {
        public string KernelPath { private get; set; }

        private readonly HashProvider _hashProvider;

        public IKernelHash SelectedVersion { get; private set; }

        public VersionSelector()
        {
            InitializeComponent();

            _hashProvider = new HashProvider();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            PopulateDropbox();

            comboVersions.SelectedIndex = 0;

            if (File.Exists(KernelPath))
            {
                var hash = _hashProvider.CalculateMD5(KernelPath);

                var kernelHash = Settings.Hashes.FirstOrDefault(h => h.Original == hash);

                if (kernelHash != null)
                {
                    comboVersions.SelectedValue = kernelHash.Version;
                    versionLabel.Text = versionLabel.Text.Replace(":", " (automatically detected):");
                }
            }
        }

        public IKernelHash GetVersion(string kernelPath, string caption, string label, string buttonText)
        {
            KernelPath = kernelPath;
            buttonSelect.Text = buttonText ?? buttonSelect.Text;
            Text = caption;
            groupParameters.Text = label;

            StartPosition = FormStartPosition.CenterParent;

            if (ShowDialog() == DialogResult.OK)
            {
                return SelectedVersion;
            }

            throw new ArgumentOutOfRangeException();
        }

        private void PopulateDropbox()
        {
            comboVersions.Items.Clear();
            comboVersions.DataSource = Settings.Hashes;
            comboVersions.DisplayMember = "Product";
            comboVersions.ValueMember = "Version";
        }

        private void buttonPatch_Click(object sender, EventArgs e)
        {
            var selectedVersion = comboVersions.SelectedItem as KernelHash;
            SelectedVersion = selectedVersion;
        }
    }
}
