using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Extensions;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Extensions;
using Sifon.Code.Statics;
using Sifon.Forms.Base;
using Sifon.Statics;
using Sifon.Abstractions.Profiles;
using System.Threading.Tasks;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal partial class Website : BaseUserControl, IWebsiteView
    {
        //public event EventHandler<EventArgs<string>> SelectedWebsiteChanged = delegate { };
        //public event EventHandler<EventArgs<string>> WebrootFolderChanged = delegate { };
        public event BaseForm.AsyncEventHandler<EventArgs<SelectedWebsiteChangedArgs>> SelectedWebsiteChanged;
        public event BaseForm.AsyncEventHandler<EventArgs<string[]>> WebrootFolderChanged;
        //public event BaseForm.AsyncEventHandler<EventArgs<string, string>> TexboxesChanged;

        public event EventHandler<EventArgs<TextBox>> FolderBrowserClicked = delegate { };

        #region Expose fields properties

        internal string SelectedSite => comboWebsites.SelectedItem?.ToString();
        internal string SelecetedCD => comboWebsitesCD.SelectedItem?.ToString();
        internal string Webroot => textWebroot.Text.Trim();
        internal string WebrootCD => textWebrootCD.Text.Trim();

        #endregion
        

        internal Website()
        {
            InitializeComponent();
            new WebsitePresenter(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            //ShowSiteHostnames(new List<KeyValuePair<string, string>>(), ControlSettings.Grid.HostnameColumns);
            base.OnLoad(e);
        }

        public void SetHandlers()
        {
            comboWebsites.SelectedIndexChanged += new EventHandler(comboWebsites_SelectedIndexChanged);
            comboWebsitesCD.SelectedIndexChanged += new EventHandler(comboWebsites_SelectedIndexChanged);
            //textWebroot.TextChanged += new EventHandler(this.textWebroot_TextChanged);
            //textWebrootCD.TextChanged += new EventHandler(this.textWebroot_TextChanged);
        }

        public void SetLables(bool isXM)
        {
            labelWebsiteCD.Text = isXM ? "CD website:" : "XConnect website";
            labelWebrootCD.Text = isXM ? "CD website root folder:" : "XConnect website root folder:";
        }

        public void EnableControls(bool value)
        {
            comboWebsites.Enabled = value;
            comboWebsitesCD.Enabled = value;
            textWebroot.Enabled = value;
            textWebrootCD.Enabled = value;
            buttonWebroot.Enabled = value;
            buttonWebrootCD.Enabled = value;
            dataGrid.Enabled = value;
        }

        public void LoadWebsitesDropdown(IEnumerable<string> sites)
        {
            comboWebsites.Items.Clear();
            comboWebsites.Items.Add(Settings.Dropdowns.NotSet);

            comboWebsitesCD.Items.Clear();
            comboWebsitesCD.Items.Add(Settings.Dropdowns.NotSet);


            foreach (var siteName in sites)
            {
                comboWebsites.Items.Add(siteName);
                comboWebsitesCD.Items.Add(siteName);
            }
        }

        public void SetWebrootTextbox(TextBox folderTextBox, string path)
        {
            if (path.NotEmpty())
            {
                folderTextBox.Text = path;
            }

            //TexboxesChanged(textWebroot.Text, textWebrootCD.Text);
        }
        public void SetPathTextboxes(string pathCM, string pathCD)
        {
            textWebroot.Text = pathCM;
            textWebrootCD.Text = pathCD;
        }

        public void ShowSiteHostnames(IEnumerable<KeyValuePair<string, string>> hostnames, string[] columnNames)
        {
            dataGrid.ShowDataGrid(hostnames, columnNames);
        }

        public void SetWebsiteDropdownByProfile(IProfile profile)
        {
            if (comboWebsites.Items.Count > 0)
            {
                comboWebsites.SelectedIndex = profile.Website != null
                    && comboWebsites.Items.Contains(profile.Website)
                    ? comboWebsites.Items.IndexOf(profile.Website) : 0;
            }

            if (comboWebsitesCD.Items.Count > 0)
            {
                string siteName = profile.IsXM ? profile.CDSiteName : profile.XConnectSiteName;
                comboWebsitesCD.SelectedIndex = !string.IsNullOrWhiteSpace(siteName)
                    && comboWebsitesCD.Items.Contains(siteName)
                    ? comboWebsitesCD.Items.IndexOf(siteName) : 0;
            }
        }

        private void buttonWebroot_Click(object sender, EventArgs e)
        {
            FolderBrowserClicked(this, new EventArgs<TextBox>(textWebroot));
        }

        private void buttonWebrootCD_Click(object sender, EventArgs e)
        {
            FolderBrowserClicked(this, new EventArgs<TextBox>(textWebrootCD));
        }

        private async void comboWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            var textBox = combo.Name.EndsWith("CD") ? textWebrootCD : textWebroot;

            if (combo.SelectedIndex > 0 && SelectedWebsiteChanged != null)
            {
                var selectedSite = combo.SelectedItem?.ToString();
                var args = new SelectedWebsiteChangedArgs { Value = selectedSite, Sites = new[] { SelectedSite, SelecetedCD }, TextBox = textBox };
                await SelectedWebsiteChanged(this, new EventArgs<SelectedWebsiteChangedArgs>(args));
            }
            else
            {
                textBox.Text = String.Empty;
                dataGrid.DataSource = new List<KeyValuePair<string,string>>();
            }

            textBox.Enabled = combo.SelectedIndex > 0;
        }

        public void ShowRemoteWarning()
        {
            var message = $"As you've have just created a new remote profile,{Environment.NewLine}please click 'Save and Close' to apply the changes{Environment.NewLine}then re-open this window to enable auto-detection";
            ShowInfo("Remote profile", message);
        }
    }
}
