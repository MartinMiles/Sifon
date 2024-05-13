using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.PowerShell;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Providers;
using Sifon.Code.Factories;
using Sifon.Code.Progress;
using Sifon.Code.VersionSelector;
using Sifon.Forms.Base;
using Sifon.Shared.Forms.FolderBrowserDialog;
using Sifon.Shared.UserControls.ThreadSafeFilePicker;

namespace Sifon.Forms.Install
{
    internal partial class Install : BaseForm, IInstallView, ISqlServerRecord
    {
        public event EventHandler<EventArgs> Loaded = delegate { };

        public event BaseForm.AsyncEventHandler<EventArgs<IRemoteSettings>> TestRemote;
        public event EventHandler<EventArgs<string, IRemoteSettings>> TestSolr = delegate { };
        public event EventHandler<EventArgs<ISqlServerRecord, IRemoteSettings>> TestSqlClicked = delegate { };

        public Install()
        {
            InitializeComponent();
            new InstallPresenter(this);
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            PopulateDropbox();

            AddPassiveValidationHandlersForRemoting();
            AddPassiveValidationHandlersForSQL();
            AddPassiveValidationHandlersForSolr();

            buttonSetDefaults.Select();
        }

        #region Publically exposed properties

        private bool IsXM => SelectedVersion.Name.EndsWith("XM");

        internal dynamic Parameters => new
        {
            Profile = CreateProfileFromRemoteSettings(this),
            DownloadFolder = SelectedVersion.Folder,
            DownloadFile = SelectedVersion.File,
            DownloadHash = SelectedVersion.Hash,

            RemotingEnabled = checkBoxRemote.Checked,
            RemotingHost = textRemoteHostname.Text.Trim(),
            RemotingUsername = textRemoteUsername.Text.Trim(),
            RemotingPassword = textRemotePassword.Text.Trim(),
            RemotingFolder = RemoteFolder,

            SitePhysicalRoot = textDestinationFolder.Text.Trim(),
            LicenseFile = licenseTextbox.Text.Trim(),
            SitecoreAdminPassword = adminPasswordText.Text.Trim(),

            SqlServer = sqlServerText.Text.Trim(),
            SqlAdminUser = sqlServerUsernameText.Text.Trim(),
            SqlAdminPassword = sqlServerPasswordText.Text.Trim(),

            IsXM = IsXM,
            Prefix = prefixText.Text.Trim(),
            SitecoreSiteName = sitecoreSiteText.Text.Trim(),
            XConnectSiteName = xconnectText.Text.Trim(),
            CDSiteName = xconnectText.Text.Trim(),
            IdentityServerSiteName = identityServerText.Text.Trim(),

            SolrUrl = solrUrlText.Text.Trim(),
            SolrService = solrServiceText.Text.Trim(),
            SolrRoot = solrRootFolderText.Text.Trim(),

            InstallPrerequisites = installPrerequisites.Checked,
            CreateProfile = createSifonProfile.Checked
        };

        internal ProgressHook ProgressHook => new ProgressHook(@"\[\-*\s(.*)\s\-*\]")
        {
            Replacements = new Dictionary<string, int>
            {
                {"[------------------- GeneratePasswords : SetVariable -------------------------]", 15},
                {"[---------- IdentityServer_CreatePaths : EnsurePath --------------------------]", 16},
                {"[----------- IdentityServer_InstallWDP : WebDeploy ---------------------------]", 17},
                {"[--------- IdentityServer_StartWebsite : ManageWebsite -----------------------]", 18},
                {"[----------- XConnectXP0_CreateWebsite : Website---------------------------- -]", 23},
                {"[------------- XConnectXP0_StopAppPool : ManageAppPool---------------------- -]", 24},
                {"[---- XConnectXP0_RemoveDefaultBinding : WebBinding --------------------------]", 25},
                {"[---------- XConnectXP0_SetPermissions : FilePermissions-------------------- -]", 26},
                {"[-------------- XConnectXP0_InstallWDP : WebDeploy ---------------------------]", 27},
                {"[-------------- XConnectXP0_SetLicense : Copy --------------------------------]", 35},
                {"[------------- XConnectXP0_CleanShards : Command -----------------------------]", 36},
                {"[------------- SitecoreSolr_CleanCores : EnsurePath --------------------------]", 41},
                {"[------------- SitecoreXP0_CreatePaths : EnsurePath --------------------------]", 45},
                {"[-------------- SitecoreXP0_InstallWDP : WebDeploy ---------------------------]", 47},
                {"[-------------- SitecoreXP0_SetLicense : Copy --------------------------------]", 86},
                {"[-------- SitecoreXP0_UpdateSolrSchema : SitecoreUrl -------------------------]", 87},
                {"[--------- SitecoreXP0_DisplayPassword : WriteInformation --------------------]", 99}
            }
        };

        #endregion

        internal class DownloadItem
        {
            public string Name { get; set; }
            public string File { get; set; }
            public string Hash { get; set; }
            public string Folder { get; set; }
        }

        private List<DownloadItem> Versions = new List<DownloadItem>
        {
            new DownloadItem { Name = "Sitecore 9.3.0 XP", File="Sitecore 9.3.0 rev. 003498 (WDP XP0 packages).zip", Folder="9.3.0 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/93/Sitecore%20Experience%20Platform%2093%20Initial%20Release/Secure/WDP/Sitecore%209.3.0%20rev.%20003498%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.0.0 XP", File="Sitecore 10.0.0 rev. 004346 (WDP XP0 packages).zip", Folder="10.0.0 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/100/Sitecore%20Experience%20Platform%20100/Secure/WDP/Sitecore%2010.0.0%20rev.%20004346%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.0.1 XP", File="Sitecore 10.0.1 rev. 004842 (WDP XP0 packages).zip", Folder="10.0.1 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/100/Sitecore%20Experience%20Platform%20100%20Update1/Secure/WDP/Sitecore%2010.0.1%20rev.%20004842%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.0.2 XP", File="Sitecore 10.0.2 rev. 006052 (WDP XP0 packages).zip", Folder="10.0.2 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/100/Sitecore%20Experience%20Platform%20100%20Update2/Secure/WDP/Sitecore%2010.0.2%20rev.%20006052%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.0.3 XP", File="Sitecore 10.0.3 rev. 006577 (WDP XP0 packages).zip", Folder="10.0.3 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/100/Sitecore%20Experience%20Platform%20100%20Update3/Secure/WDP/Sitecore%2010.0.3%20rev.%20006577%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.1.0 XP", File="Sitecore 10.1.0 rev. 005207 (WDP XP0 packages).zip", Folder="10.1.0 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/101/Sitecore%20Experience%20Platform%20101/Secure/WDP/Sitecore%2010.1.0%20rev.%20005207%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.1.1 XP", File="Sitecore 10.1.1 rev. 005862 (WDP XP0 packages).zip", Folder="10.1.1 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/101/Sitecore%20Experience%20Platform%20101%20Update1/Secure/WDP/Sitecore%2010.1.1%20rev.%20005862%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.1.2 XP", File="Sitecore 10.1.2 rev. 006578 (WDP XP0 packages).zip", Folder="10.1.2 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/101/Sitecore%20Experience%20Platform%20101%20Update2/Secure/WDP/Sitecore%2010.1.2%20rev.%20006578%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.1.3 XP", File="Sitecore 10.1.3 rev. 009558 (WDP XP0 packages).zip", Folder="10.1.3 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/101/Sitecore%20Experience%20Platform%20101%20Update3/Secure/WDP/Sitecore%2010.1.3%20rev.%20009558%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.2.0 XP", File="Sitecore 10.2.0 rev. 006766 (WDP XP0 packages).zip", Folder="10.2.0 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/102/Sitecore%20Experience%20Platform%20102/Secure/WDP/Sitecore%2010.2.0%20rev.%20006766%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.2.1 XP", File="Sitecore 10.2.1 rev. 009559 (WDP XP0 packages).zip", Folder="10.2.1 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/102/Sitecore%20Experience%20Platform%20102%20Update1/Secure/WDP/Sitecore%2010.2.1%20rev.%20009559%20(WDP%20XP0%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.3.0 XP", File="Sitecore 10.3.0 rev. 008463 (WDP XP0 packages).zip", Folder="10.3.0 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/103/Sitecore%20Experience%20Platform%20103/Secure/WDP/Sitecore%2010.3.0%20rev.%20008463%20(WDP%20XP0%20packages).zip" },
            
            new DownloadItem { Name = "Sitecore 10.3.0 XM", File="Sitecore 10.3.0 rev. 008463 (WDP XM1 packages).zip", Folder="10.3.0 XM", 
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/103/Sitecore%20Experience%20Platform%20103/Secure/WDP/Sitecore%2010.3.0%20rev.%20008463%20(WDP%20XM1%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.3.1 XP", File="Sitecore 10.3.1 rev. 009452 (WDP XP0 packages).zip", Folder="10.3.1 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/103/Sitecore%20Experience%20Platform%20103%20Update1/Secure/Sitecore%2010.3.1%20rev.%20009452%20(WDP%20XP0%20packages).zip" },
            
            new DownloadItem { Name = "Sitecore 10.3.1 XM", File="Sitecore 10.3.1 rev. 009452 (WDP XM1 packages).zip", Folder="10.3.1 XM", 
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/103/Sitecore%20Experience%20Platform%20103%20Update1/Secure/Sitecore%2010.3.1%20rev.%20009452%20(WDP%20XM1%20packages).zip" },

            new DownloadItem { Name = "Sitecore 10.4.0 XP", File="Sitecore 10.4.0 rev. 010422 (WDP XP0 packages).zip", Folder="10.4.0 XP",
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/104/Sitecore%20Experience%20Platform%20104/Sitecore%2010.4.0%20rev.%20010422%20(WDP%20XP0%20packages).zip" },
            
            new DownloadItem { Name = "Sitecore 10.4.0 XM", File="Sitecore 10.4.0 rev. 010422 (WDP XM1 packages).zip", Folder="10.4.0 XM", 
                Hash = "https://scdp.blob.core.windows.net/downloads/Sitecore%20Experience%20Platform/104/Sitecore%20Experience%20Platform%20104/Sitecore%2010.4.0%20rev.%20010422%20(WDP%20XM1%20packages).zip" }
        };

        private DownloadItem SelectedVersion => comboVersions.SelectedItem as DownloadItem;
        private void PopulateDropbox()
        {
            comboVersions.Items.Clear();
            comboVersions.DisplayMember = "Name";
            comboVersions.ValueMember = "Folder";
            comboVersions.DataSource = Versions;
            //comboVersions.DataSource = Settings.Hashes
            //    .Where(h => h.Product.StartsWith("Sitecore 10") || h.Product.StartsWith("Sitecore 9.3"))
            //    .ToList();
        }

        private async void install_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ToggleControls(false);
                loadingCircle.Visible = true;
                loadingCircle.Active = true;

                await CopyLicenseIfRemote();
                DialogResult = DialogResult.OK;
            }
        }

        //TODO: duplicated same method from presenter for Install class
        private IProfile CreateProfileFromRemoteSettings(IRemoteSettings remoteSettings)
        {
            var profileProvider = Create.New<IProfilesProvider>();
            return profileProvider.CreateProfile(remoteSettings);
        }

        private async Task CopyLicenseIfRemote()
        {
            var remoteScriptCopier = Create.WithProfile<IRemoteScriptCopier>(ProfileForInstallation, this);

            var licenseFile = licenseTextbox.Text.Trim();
            if (File.Exists(licenseFile))
            {
                licenseTextbox.Text = await remoteScriptCopier.CopyIfRemote(licenseFile);
            }
        }

        private async void buttonTestRemoting_Click(object sender, EventArgs e)
        {
            if (ValidateTestRemoting() && TestRemote != null)
            {
                ToggleControls(false);
                await TestRemote(this, new EventArgs<IRemoteSettings>(this));
            }
        }

        private void buttonTestSQL_Click(object sender, EventArgs e)
        {
            //if (!ValidateForm()) return;

            TestSqlClicked(this, new EventArgs<ISqlServerRecord, IRemoteSettings>(this, this));
        }

        private void buttonTestSolr_Click(object sender, EventArgs e)
        {
            TestSolr(this, new EventArgs<string, IRemoteSettings>(solrUrlText.Text.Trim(), this));
        }

        public void SetRemoteSettings(IRemoteSettings remoteSettings)
        {
            RemoteFolder = remoteSettings.RemoteFolder;

            ToggleControls(true);
            UpdateButtonsState();
        }

        IProfile ProfileForInstallation => Create.New<IProfilesProvider>().CreateProfile(this);

        private void button1_Click(object sender, EventArgs e)
        {
            var browser = new FolderBrowser(ProfileForInstallation, true) { StartPosition = FormStartPosition.CenterParent };
            if (browser.ShowDialog() == DialogResult.OK)
            {
                textDestinationFolder.Text = browser.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var browser = new FolderBrowser(ProfileForInstallation, true) { StartPosition = FormStartPosition.CenterParent };
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
        }

        private void SetDefaults_Click(object sender, EventArgs e)
        {
            //var last = comboVersions.Items.Count - 1;
            //comboVersions.SelectedIndex = last;

            textDestinationFolder.Text = @"C:\inetpub\wwwroot";
            licenseTextbox.Text = @"c:\license.xml";
            adminPasswordText.Text = "b";

            prefixText.Text = IsXmSelected ? "xm" : "xp";
            sitecoreSiteText.Text = IsXmSelected ? $"cm.{prefixText.Text}.local" : $"{prefixText.Text}.local";
            xconnectText.Text = IsXmSelected ? $"cd.{prefixText.Text}.local" : $"xconnect.{prefixText.Text}.local";
            identityServerText.Text = $"identityserver.{prefixText.Text}.local";

            solrUrlText.Text = "https://localhost:8112/solr";
            solrServiceText.Text = "solr-8.11.2";
            solrRootFolderText.Text = @"c:\Solr\solr-8.11.2";

            sqlServerText.Text = ".\\SQLSERVER";
            sqlServerUsernameText.Text = "sa";
            sqlServerPasswordText.Text = "SA_PASSWORD";

        }

        private void checkBoxRemote_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRemotingControls(true);
            UpdateButtonsState();
            UpdateSqlButtonsState();
            UpdateSolrButtonsState();

            groupBoxSql.Text = checkBoxRemote.Checked ? "SQL Server (relative to a remote machine)" : "SQL Server";
            groupBoxSolr.Text = checkBoxRemote.Checked ? "Solr (relative to a remote machine)" : "Solr";
        }

        public void ToggleControls(bool enabled)
        {
            comboVersions.Enabled = enabled;
            installPrerequisites.Enabled = enabled;
            createSifonProfile.Enabled = enabled;

            prefixText.Enabled = enabled;
            sitecoreSiteText.Enabled = enabled;
            xconnectText.Enabled = enabled;
            identityServerText.Enabled = enabled;

            textDestinationFolder.Enabled = enabled;
            licenseTextbox.Enabled = enabled;
            adminPasswordText.Enabled = enabled;

            solrUrlText.Enabled = enabled;
            solrServiceText.Enabled = enabled;
            solrRootFolderText.Enabled = enabled;

            sqlServerText.Enabled = enabled;
            sqlServerUsernameText.Enabled = enabled;
            sqlServerPasswordText.Enabled = enabled;
            
            buttonTestRemoting.Enabled = enabled && IsRemotingBlockValid();
            targetFolderButton.Enabled = enabled && IsRemotingBlockValid();
            buttonSolrFolder.Enabled = enabled && IsRemotingBlockValid();

            UpdateSqlButtonsState();
            UpdateSolrButtonsState();

            ToggleRemotingControls(enabled);

            revealSitecoreAdminPassword.Enabled = enabled && checkBoxRemote.Checked;
            linkRevealSqlPassword.Enabled = enabled /*&& checkBoxRemote.Checked*/;
            licenseFileButton.Enabled = enabled;

            checkBoxRemote.Enabled = enabled;
            textRemoteHostname.Enabled = enabled;
            textRemoteUsername.Enabled = enabled;
            textRemotePassword.Enabled = enabled;

            buttonSetDefaults.Enabled = enabled;
            buttonInstall.Enabled = enabled;
            buttonTestSQL.Enabled = enabled;
            buttonTestSolr.Enabled = enabled;
        }

        private void ToggleRemotingControls(bool enabled)
        {
            textRemoteHostname.Enabled = enabled && checkBoxRemote.Checked;
            textRemoteUsername.Enabled = enabled && checkBoxRemote.Checked;
            textRemotePassword.Enabled = enabled && checkBoxRemote.Checked;
            linkRevealRemoting.Enabled = enabled && checkBoxRemote.Checked;
            buttonTestRemoting.Enabled = enabled && checkBoxRemote.Checked && IsRemotingBlockValid();
            buttonSolrFolder.Enabled = enabled && (!checkBoxRemote.Checked || IsRemotingBlockValid());
            targetFolderButton.Enabled = enabled && (!checkBoxRemote.Checked || IsRemotingBlockValid());
        }

        #region Reveal / Hide

        public const string RevealLabel = "reveal";
        public const string HideLabel = "hide";

        private void linkReveal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPassword(sender, textRemotePassword);
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

        #region ISqlServerRecord implementation

        public string RecordName => throw new NotImplementedException("Not used");
        public string SqlServer => sqlServerText.Text.Trim();
        public string SqlAdminUsername => sqlServerUsernameText.Text.Trim();

        public string SqlAdminPassword
        {
            get => sqlServerPasswordText.Text.Trim();
            set => throw new NotImplementedException("Not used");
        }

        #endregion

        #region IRemoteSettings implementation

        public bool RemotingEnabled { get => checkBoxRemote.Checked; set => throw new NotImplementedException(); }

        public string RemoteHost { get => textRemoteHostname.Text.Trim(); set => textRemoteHostname.Text = value; }
        public string RemoteUsername { get => textRemoteUsername.Text.Trim(); set => textRemoteUsername.Text = value; }
        public string RemotePassword { get => textRemotePassword.Text.Trim(); set => textRemotePassword.Text = value; }
        public string RemoteFolder { get; set; } = String.Empty;

        #endregion

        private bool IsXmSelected => ((DownloadItem)comboVersions.SelectedItem).Name.EndsWith("XM");

        private void comboVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            sitecoreSiteLabel.Text = IsXmSelected ? "Sitecore CM site:" : "Sitecore site:";
            xconnectLabel.Text = IsXmSelected ? "Sitecore CD site:" : "XConnect site:";
        }

        private void buttonInstallSQL_Click(object sender, EventArgs e)
        {
            var form = new SQL.InstallSQL { StartPosition = FormStartPosition.CenterParent };
            if (form.ShowDialog() == DialogResult.OK)
            {
                buttonInstallSQL.Enabled = false;
                sqlServerText.Text = $".\\{form.SqlServer}";
                sqlServerUsernameText.Text = "sa";
                sqlServerPasswordText.Text = form.SqlAdminPassword;
            }

            form.Dispose();
        }
    }
}
