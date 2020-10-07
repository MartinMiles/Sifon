using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Events;
using Sifon.Code.Extensions;
using Sifon.Code.Statics;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal partial class Website : BaseUserControl, IWebsiteView
    {
        public event EventHandler<EventArgs<string>> SelectedWebsiteChanged = delegate { };
        public event EventHandler<EventArgs<string>> WebrootFolderChanged = delegate { };
        public event EventHandler<EventArgs> FolderBrowserClicked = delegate { };
        
        #region Expose fields properties

        internal string SelectedSite => comboWebsites.SelectedItem?.ToString();

        internal string Webroot => textWebroot.Text.Trim();

        #endregion

        public Website()
        {
            InitializeComponent();
            new WebsitePresenter(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            ShowSiteHostnames(new List<KeyValuePair<string, string>>());
            base.OnLoad(e);
        }

        public void EnableControls(bool value)
        {
            comboWebsites.Enabled = value;
            textWebroot.Enabled = value;
            buttonWebroot.Enabled = value;
            dataGrid.Enabled = value;
        }

        public void LoadWebsitesDropdown(IEnumerable<string> sites)
        {
            comboWebsites.Items.Clear();
            comboWebsites.Items.Add(Settings.Dropdowns.NotSet);

            foreach (var siteName in sites)
            {
                comboWebsites.Items.Add(siteName);
            }
        }

        public void SetWebrootTextbox(string path)
        {
            if(path.NotEmpty())
            {
                textWebroot.Text = path;
            }
        }

        public void ShowSiteHostnames(IEnumerable<KeyValuePair<string, string>> hostnames)
        {
            dataGrid.ShowDataGrid(hostnames, new[] { "Protocol", "Hostname" });
        }

        public void SetWebsiteDropdownByProfile(string website)
        {
            if (comboWebsites.Items.Count > 0)
            {
                comboWebsites.SelectedIndex = website != null && comboWebsites.Items.Contains(website) ? comboWebsites.Items.IndexOf(website) : 0;
            }
        }

        private void buttonWebroot_Click(object sender, EventArgs e)
        {
            FolderBrowserClicked(this, new EventArgs());
        }

        private void comboWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboWebsites.SelectedIndex > 0)
            {
                SelectedWebsiteChanged(this, new EventArgs<string>(SelectedSite));
            }
            else
            {
                textWebroot.Text = String.Empty;
                dataGrid.DataSource = new List<KeyValuePair<string,string>>();
            }
        }

        private void textWebroot_TextChanged(object sender, EventArgs e)
        {
            var newValue = ((TextBox) sender).Text.Trim();

            if (newValue.IsValidFilePath())
            {
                WebrootFolderChanged(this, new EventArgs<string>(newValue));
            }
            else if (comboWebsites.SelectedIndex > 0)
            {
                ShowError("Validation Error", "Web root does not seem to be a valid path");
            }
        }
    }
}
