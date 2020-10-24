using System;
using Sifon.Abstractions.Forms;
using Sifon.Code.Events;
using Sifon.Forms.Base;

namespace Sifon.Forms.Prerequsites
{
    internal partial class Prerequsites : BaseForm, IPrerequisitesView, IPrerequisites
    {
        public event EventHandler<EventArgs<IPrerequisites>> InstallClicked = delegate {};

        public Prerequsites()
        {
            InitializeComponent();
            new PrerequsitesPresenter(this);
        }

        private void Prerequsites_Load(object sender, EventArgs e)
        {
            EnableControls(false);
            Raise_FormLoaded();
        }

        private void Install_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            InstallClicked(this, new EventArgs<IPrerequisites>(this));
        }

        #region IPrerequisites

        public bool Chocolatey
        {
            get => checkChocolatey.Checked;
            set => checkChocolatey.Checked = value;
        }

        public bool Git
        {
            get => checkGit.Checked;
            set => checkGit.Checked = value;
        }

        public bool SIF { get; set; }   //TODO: Get rid of this prop if not used

        #endregion

        public void EnableControls(bool enabled)
        {
            checkChocolatey.Enabled = enabled;
            checkGit.Enabled = enabled;

            buttonInstall.Enabled = enabled;
        }

        public void UpdateProgressBar(int percentComplete, string statusLabelText)
        {
            if (percentComplete < 0) return;

            progressBar.Value = percentComplete;
            //labelStatus.Text = statusLabelText;
            progressLabel.Text = $"Progress: {percentComplete}%";
        }

        public void UpdateView(Tuple<bool, bool> bools)
        {
            checkChocolatey.Checked = bools.Item1;
            checkGit.Checked = bools.Item2;

            EnableControls(true);
        }

        public void ScriptComplete(string errorMessage)
        {
            //if (errorMessage.NotEmpty())
            //{
            //    buttonDone.Text = "Cancel";
            //    ShowError("Connectivity error", errorMessage);
            //    buttonDone.DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    buttonDone.DialogResult = DialogResult.Cancel;
            //    resultHeading.Text = $"Remote folders for script and module created at [{RemoteSettings.RemoteHost}]:";
            //    labelScriptsRemoteFolder.Text = scriptsFolder;
            //    labelModuleRemoteFolder.Text = moduleFolder;
            //}

            //RemoteFolder = scriptsFolder;
            //buttonDone.Enabled = true;
        }
    }
}
