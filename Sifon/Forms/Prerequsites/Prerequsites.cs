using System;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Forms.Base;

namespace Sifon.Forms.Prerequsites
{
    internal partial class Prerequsites : BaseForm, IPrerequisitesView, IPrerequisites
    {
        public event EventHandler<EventArgs<IPrerequisites>> InstallClicked = delegate {};

        internal Prerequsites()
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
            labelCheckResult.Text = "Please be patient, it may take a while...";
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

        public bool WinRM
        {
            get => checkRemoting.Checked;
            set => checkRemoting.Checked = value;
        }

        public bool SIF
        {
            get => checkSif.Checked;
            set => checkSif.Checked = value;
        }

        #endregion

        public void EnableControls(bool enabled)
        {
            checkChocolatey.Enabled = enabled;
            checkGit.Enabled = enabled;
            checkRemoting.Enabled = enabled;
            checkSif.Enabled = enabled;

            buttonInstall.Enabled = enabled;
            buttonClose.Enabled = enabled;
            SetWaitCursor(!enabled);
        }

        public void UpdateProgressBar(int percentComplete, string statusLabelText)
        {
            if (percentComplete < 0) return;

            progressBar.Value = percentComplete;
            progressLabel.Text = $"Progress: {percentComplete}%";
        }

        public void UpdateView(Tuple<bool, bool, bool, bool> bools)
        {
            checkChocolatey.Checked = bools.Item1;
            checkGit.Checked = bools.Item2;
            checkRemoting.Checked = bools.Item3;
            checkSif.Checked = bools.Item4;

            EnableControls(true);
            
            if (bools.Item1 && bools.Item2 && bools.Item3 && bools.Item4)
            {
                labelCheckResult.Text = "You've already got all the necessary prerequsites ";
                buttonClose.Focus();
                buttonInstall.Enabled = false;
            }
            else
            {
                buttonInstall.Focus();
            }
        }

        public void Success(Tuple<bool, bool, bool, bool> installationResult)
        {
            checkChocolatey.Checked = installationResult.Item1;
            checkGit.Checked = installationResult.Item2;
            checkRemoting.Checked = installationResult.Item3;
            checkSif.Checked = installationResult.Item4;

            ShowInfo("Success", "Prerequsites have been installed");
            EnableControls(true);
            buttonInstall.Visible = false;
            buttonClose.Focus();
        }

        public void Error(Exception e)
        {
            labelCheckResult.Text = "Finished, however there were some errors occured.";
            ShowError("An error has occured", $"{e.Message}{Environment.NewLine}{e.StackTrace}");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            labelCheckResult.Text = "Done.";
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
            buttonInstall.Enabled = checkChocolatey.Checked || checkGit.Checked || checkRemoting.Checked || checkSif.Checked;
        }
    }
}
