using System;
using System.Drawing;
using System.Linq;
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
        
        public bool NetCore
        {
            get => checkNetCore.Checked;
            set => checkNetCore.Checked = value;
        }
        
        public bool SqlServer
        {
            get => checkSqlServer.Checked;
            set => checkSqlServer.Checked = value;
        }

        #endregion

        public void EnableControls(bool enabled)
        {
            checkChocolatey.Enabled = enabled;
            checkGit.Enabled = enabled;
            checkRemoting.Enabled = enabled;
            checkSif.Enabled = enabled;
            checkNetCore.Enabled = enabled;
            checkSqlServer.Enabled = enabled;

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

        public void UpdateView(bool[] bools)
        {
            checkChocolatey.ForeColor = bools[0] ? Color.Green : Color.Red;
            checkGit.ForeColor = bools[1] ? Color.Green : Color.Red;
            checkRemoting.ForeColor = bools[2] ? Color.Green : Color.Red;
            checkSif.ForeColor = bools[3] ? Color.Green : Color.Red;
            checkNetCore.ForeColor = bools[4] ? Color.Green : Color.Red;
            checkSqlServer.ForeColor = bools[5] ? Color.Green : Color.Red;

            EnableControls(true);
            
            if (bools.All(b => b))
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

        public void Success(bool[] installationResult)
        {

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
            buttonInstall.Enabled = checkChocolatey.Checked 
                                    || checkGit.Checked 
                                    || checkRemoting.Checked 
                                    || checkSif.Checked 
                                    || checkSqlServer.Checked;
        }
    }
}
