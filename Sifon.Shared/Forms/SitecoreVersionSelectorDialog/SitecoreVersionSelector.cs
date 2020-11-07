using System;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.VersionSelector;
using Sifon.Code.VersionSelector;

namespace Sifon.Shared.Forms.SitecoreVersionSelectorDialog
{
    public partial class SitecoreVersionSelector : Form
    {
        private IProfile _profile;
        public string _kernelPath;
        public IKernelHash _selectedVersion;

        public SitecoreVersionSelector()
        {
            InitializeComponent();
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            PopulateDropbox();

            comboVersions.SelectedIndex = 0;

            EnableControls(false);

            var versionDetector = new VersionDetector(_profile, this);
            var kernelHash = await versionDetector.Identify(_kernelPath);

            if (kernelHash != null)
            {
                comboVersions.SelectedValue = kernelHash.Version;
                versionLabel.Text = versionLabel.Text.Replace(":", " (automatically detected):");
            }

            EnableControls(true);
        }

        public IKernelHash GetVersion(string kernelPath, string caption, string label, string buttonText, IProfile profile)
        {
            _kernelPath = kernelPath;
            _profile = profile;

            buttonSelect.Text = buttonText ?? buttonSelect.Text;
            groupParameters.Text = label;

            StartPosition = FormStartPosition.CenterParent;
            ShowDialog();
            return _selectedVersion;
        }

        private void EnableControls(bool enabled)
        {
            groupParameters.Enabled = enabled;
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
            _selectedVersion = selectedVersion;
        }
    }
}
