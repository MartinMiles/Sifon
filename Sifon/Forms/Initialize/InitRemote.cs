using System;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;
using Sifon.Shared.Extensions;

namespace Sifon.Forms.Initialize
{
    public partial class InitRemote : BaseForm, InitRemoteView
    {
        public event EventHandler<EventArgs> FormLoaded = delegate { };

        //public string RemoteHostname { get; set; }
        public IRemoteSettings RemoteSettings  { get; set; }

        public string RemoteFolder { get; private set; }

        public InitRemote()
        {
            InitializeComponent();
        }

        private void InitRemote_Load(object sender, EventArgs e)
        {
            new InitRemotePresenter(this, RemoteSettings);

            Text = $"Initializing {RemoteSettings.RemoteHostname}";
            
            //labelStatus.Visible = false;

            FormLoaded(this, new EventArgs());
        }

        private void done_Click(object sender, EventArgs e)
        {
            // need to return if positive 
            DialogResult = DialogResult.OK;
            Close();
        }

        public void UpdateProgressBar(int percentComplete, string statusLabelText)
        {
            if (percentComplete < 0) return;

            progressBar.Value = percentComplete;
            labelStatus.Text = statusLabelText;
            progressLabel.Text = $"Progress: {percentComplete}%";
        }
        
        public void ScriptComplete(string folder, string errorMessage)
        {
            if (errorMessage.NotEmpty())
            {
                buttonDone.Text = "Cancel";
                ShowError("Connectivity error", errorMessage);
                buttonDone.DialogResult = DialogResult.OK;
            }
            else
            {
                buttonDone.DialogResult = DialogResult.Cancel;
                labelRemoteFolder.Text = $"Remote folder created at [{RemoteSettings.RemoteHostname}]:  {folder}";
            }

            RemoteFolder = folder;
            buttonDone.Enabled = true;
        }
    }
}
