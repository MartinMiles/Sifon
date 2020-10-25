using System.Management.Automation;
using System.Windows.Forms;

namespace Sifon.Forms.Other
{
    public partial class FirstTimeRun : Form
    {
        public FirstTimeRun()
        {
            InitializeComponent();
        }

        private void FirstTimeRun_Load(object sender, System.EventArgs e)
        {
            buttonPrerequsites.Focus();
            buttonPrerequsites.Enabled = false;
            buttonUnderstand.Enabled = false;

            InstallModuleOnFirstRun();

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

        private void InstallModuleOnFirstRun()
        {
            var ps = PowerShell.Create();

            try
            {
                ps.AddCommand("Set-ExecutionPolicy")
                    .AddArgument("Unrestricted")
                    .AddParameter("Scope", "CurrentUser");

                ps.Invoke();
            }
            catch (CmdletInvocationException) {}

            ps = PowerShell.Create();
            ps.AddCommand($".\\{Code.Statics.Modules.Directory}\\{Code.Statics.Modules.Files.Installer}");
            ps.Invoke();
        }

        private void buttonUnderstand_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
