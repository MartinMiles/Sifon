using System;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;
using Sifon.Code.Extensions;

namespace Sifon.Forms.Initialize
{
    internal partial class InitRemote : BaseForm, InitRemoteView
    {
        public IRemoteSettings RemoteSettings  { get; set; }

        public string RemoteFolder { get; private set; }

        internal InitRemote()
        {
            InitializeComponent();
        }

        private void InitRemote_Load(object sender, EventArgs e)
        {
            new InitRemotePresenter(this, RemoteSettings);

            Text = $"Initializing Sifon on {RemoteSettings.RemoteHost}";

            Raise_FormLoaded();
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
        
        public void ScriptComplete(string scriptsFolder, string moduleFolder, string errorMessage)
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
                resultHeading.Text = $"Remote folders for script and module created at [{RemoteSettings.RemoteHost}]:";
                labelScriptsRemoteFolder.Text = scriptsFolder;
                labelModuleRemoteFolder.Text = moduleFolder;
            }

            RemoteFolder = scriptsFolder;
            buttonDone.Enabled = true;
        }
    }
}
