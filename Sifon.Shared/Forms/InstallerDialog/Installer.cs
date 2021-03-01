using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;
using Sifon.Code.VersionSelector;
using Sifon.Shared.Code.Downloader;
using Sifon.Shared.Forms.Base;
using Sifon.Shared.Forms.FolderBrowserDialog;
using Sifon.Shared.UserControls.ThreadSafeFilePicker;

namespace Sifon.Shared.Forms.InstallerDialog
{
    public partial class Installer : BaseDialog
    {
        public Installer()
        {
            InitializeComponent();
        }

        public dynamic Install(/*IProfile profile, string json*/)
        {
            StartPosition = FormStartPosition.CenterParent;

            if (ShowDialog() == DialogResult.OK)
            {
                var test = new
                {
                    DownloadFile = SelectedVersion.Key,
                    DownloadHash = SelectedVersion.Value,

                    RemotingEnabled = false,
                    RemotingHost = textHostname.Text.Trim(),
                    RemotingUsername = textUsername.Text.Trim(),
                    RemotingPassword = textPassword.Text.Trim(),

                    SitePhysicalRoot = textDestinationFolder.Text.Trim(),
                    LicenseFile = licenseTextbox.Text.Trim(),
                    SitecoreAdminPassword = adminPasswordText.Text.Trim(),

                    SqlServer = sqlServerText.Text.Trim(),
                    SqlAdminUser = sqlServerUsernameText.Text.Trim(),
                    SqlAdminPassword = sqlServerPasswordText.Text.Trim(),

                    Prefix = prefixText.Text.Trim(),
                    SitecoreSiteName = sitecoreSiteText.Text.Trim(),
                    XConnectSiteName = xconnectText.Text.Trim(),
                    IdentityServerSiteName = identityServerText.Text.Trim(),

                    SolrUrl = solrUrlText.Text.Trim(),
                    SolrService = solrServiceText.Text.Trim(),
                    SolrRoot = solrRootFolderText.Text.Trim(),

                    InstallPrerequisites = installPrerequisites.Checked,
                    CreateProfile = createSifonProfile.Checked
                };

                return test;
            }

            return null;
        }

        private KeyValuePair<string, string> SelectedVersion
        {
            get
            {
                var resources = new Dictionary<string, string>
                {
                    {"Sitecore 10.0.0 rev. 004346 (WDP XP0 packages).zip", "DCD3DC6E7C544C3685EC41DD781D3187"},
                    {"Sitecore 10.0.1 rev. 004842 (WDP XP0 packages).zip", "9486629B50A847A5B62D59474CBAC53C"},
                    {"Sitecore 10.1.0 rev. 005207 (WDP XP0 packages).zip", "7F9D170F0A4B4B598323629A7B7122EA"}
                };

                var selectedVersion = comboVersions.SelectedItem as KernelHash;
                return resources.FirstOrDefault(r => r.Key.StartsWith(selectedVersion.Product));

            }
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            PopulateDropbox();
            AddPassiveValidationHandlers();
        }

        private void PopulateDropbox()
        {
            comboVersions.Items.Clear();
            comboVersions.DataSource = Settings.Hashes.Where(h => h.Product.StartsWith("Sitecore 10")).ToList();
            comboVersions.DisplayMember = "Product";
            comboVersions.ValueMember = "Version";
        }

        private void install_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonTestRemoting_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: Fake profile
            var profile = Create.New<IProfilesProvider>().CreateLocal();

            var browser = new FolderBrowser(profile, true) { StartPosition = FormStartPosition.CenterParent };
            if (browser.ShowDialog() == DialogResult.OK)
            {
                textDestinationFolder.Text = browser.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //TODO: Fake profile
            var profile = Create.New<IProfilesProvider>().CreateLocal();

            var browser = new FolderBrowser(profile, true) { StartPosition = FormStartPosition.CenterParent };
            if (browser.ShowDialog() == DialogResult.OK)
            {
                solrRootFolderText.Text = browser.SelectedPath;
            }
        }

        private void licenseFileButton_Click(object sender, EventArgs e)
        {
            var dlg = new ThreadSafeOpenPicker
            {
                //Filter = Filters,
                DefaultExt = "xml",
                StartupLocation = new Point(Location.X, Location.Y)
            };

            var res = dlg.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            licenseTextbox.Text = dlg.FilePath.Trim();
            //FilePath = dlg.FilePath.Trim();

            //if (Validation != null)
            //{
            //    string validationResult = Validation(pathTextbox.Text);

            //    buttonInstall.Enabled = string.IsNullOrWhiteSpace(validationResult);

            //    if (!buttonInstall.Enabled)
            //    {
            //        MessageBox.Show(validationResult, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        buttonInstall.Focus();
            //    }
            //}
        }

        private void SetDefaults_Click(object sender, EventArgs e)
        {
            var last = comboVersions.Items.Count - 1;
            comboVersions.SelectedIndex = last;

            textDestinationFolder.Text = @"C:\inetpub\wwwroot";
            licenseTextbox.Text = @"license.xml";
            adminPasswordText.Text = "b";

            prefixText.Text = "xp";
            sitecoreSiteText.Text = $"{prefixText.Text}.dev.local";
            xconnectText.Text = $"{prefixText.Text}.xconnect";
            identityServerText.Text = $"{prefixText.Text}.identityserver";

            solrUrlText.Text = "https://localhost:8840/solr";
            solrServiceText.Text = "solr-8.4.0";
            solrRootFolderText.Text = @"c:\Solr\solr-8.4.0";

            sqlServerText.Text = "(local)";
            sqlServerUsernameText.Text = "sa";
            sqlServerPasswordText.Text = "SA_PASSWORD";

        }

        private void checkBoxRemote_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRemotingControls();
        }

        private void ToggleRemotingControls()
        {
            textHostname.Enabled = checkBoxRemote.Checked;
            textUsername.Enabled = checkBoxRemote.Checked;
            textPassword.Enabled = checkBoxRemote.Checked;
            linkRevealRemoting.Enabled = checkBoxRemote.Checked;
            buttonTestRemoting.Enabled = checkBoxRemote.Checked;
        }

        #region Reveal / Hide

        public const string RevealLabel = "reveal";
        public const string HideLabel = "hide";

        private void linkReveal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPassword(sender, textPassword);
        }

        private void revealSitecoreAdminPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPassword(sender, adminPasswordText);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPassword(sender, sqlServerPasswordText);
        }

        private void RevealPassword(object sender, TextBox textBox)
        {
            var label = (LinkLabel)sender;
            bool reveal = label.Text.Contains(RevealLabel);

            textBox.PasswordChar = reveal ? new char() : '*';
            label.Text = reveal ? $"({HideLabel})" : $"({RevealLabel})";

            //label.Location = new Point(reveal ? 244 : 235, label.Location.Y);
            label.Location = new Point(label.Location.X + (reveal ? 9: -9), label.Location.Y);
        }

        #endregion

        #region Drag / Drop

        private void licenseTextbox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                licenseTextbox.Text = file;
            }
        }

        private void licenseTextbox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        #endregion
    }
}
