using System;
using System.Windows.Forms;
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
            SetWaitCursor(!enabled);
        }

        public void UpdateProgressBar(int percentComplete, string statusLabelText)
        {
            if (percentComplete < 0) return;

            progressBar.Value = percentComplete;
            progressLabel.Text = $"Progress: {percentComplete}%";
        }

        public void UpdateView(Tuple<bool, bool> bools)
        {
            checkChocolatey.Checked = bools.Item1;
            checkGit.Checked = bools.Item2;

            EnableControls(true);
            buttonInstall.Focus();
        }

        public void Success(Tuple<bool, bool> installationResult)
        {
            checkChocolatey.Checked = installationResult.Item1;
            checkGit.Checked = installationResult.Item2;

            ShowInfo("Success", "Prerequsites have been installed");
            EnableControls(true);
            buttonInstall.Visible = false;
            buttonClose.Focus();
        }

        public void Error(Exception e)
        {
            ShowError("An error has occured", $"{e.Message}{Environment.NewLine}{e.StackTrace}");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void checkChocolatey_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInstallButton();
        }

        private void checkGit_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInstallButton();
        }
        private void UpdateInstallButton()
        {
            buttonInstall.Enabled = checkChocolatey.Checked || checkGit.Checked;
        }
    }
}
