using System.Windows.Forms;
using Sifon.Code.PowerShell;

namespace Sifon.Forms.Other
{
    internal partial class FirstTimeRun : Form
    {
        internal FirstTimeRun()
        {
            InitializeComponent();
        }

        private void FirstTimeRun_Load(object sender, System.EventArgs e)
        {
            buttonPrerequsites.Focus();
            buttonPrerequsites.Enabled = false;
            buttonUnderstand.Enabled = false;

            var powerShellHelper = new PowerShellHelper();
            powerShellHelper.InstallModuleOnFirstRun();

            buttonPrerequsites.Enabled = true;
            buttonUnderstand.Enabled = true;
        }

        private void buttonPrerequsites_Click(object sender, System.EventArgs e)
        {
            EnableControls(false);

            var about = new Prerequsites.Prerequsites { StartPosition = FormStartPosition.CenterParent };
            if (about.ShowDialog() == DialogResult.OK)
            {
                about.Dispose();
                buttonUnderstand.Focus();
            }

            EnableControls(true);
        }

        public void EnableControls(bool enabled)
        {
            buttonPrerequsites.Enabled = enabled;
            buttonUnderstand.Enabled = enabled;
        }

        private void buttonUnderstand_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
