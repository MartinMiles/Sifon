using System;
using System.Diagnostics;
using System.Windows.Forms;
using Sifon.Code.Model;
using Sifon.Forms.Base;

namespace Sifon.Forms.Updates
{
    internal partial class CheckUpdates : BaseForm, ICheckUpdatesView
    {
        public event EventHandler<EventArgs> CheckClicked = delegate { };

        public CheckUpdates()
        {
            InitializeComponent();
            new CheckUpdatesPresenter(this);
        }

        private void CheckUpdates_Load(object sender, EventArgs e)
        {
            Raise_FormLoaded();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            buttonCheck.Enabled = false;
            CheckClicked(this, new EventArgs());
        }

        public void UpdateResult(ProductVersion version, string hostBase, bool actualVersion)
        {
            if (actualVersion)
            {
                labelMain.Text = "You've already got the latest version";
                linkDownload.Visible = false;
            }
            else
            {
                labelMain.Text = "A newer version found available for downloading by the link:";
                linkDownload.Visible = true;
                linkDownload.Text = $"{hostBase}{version.DownloadUrl}";
            }
        }

        public void ProcessError(Exception e)
        {
            string message = e.Message + Environment.NewLine + e.InnerException?.Message ?? "";
            ShowError("An error occured", message);
        }

        private void linkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = ((LinkLabel) sender).Text;
            Process.Start(url);
            DialogResult = DialogResult.OK;
        }
    }
}
