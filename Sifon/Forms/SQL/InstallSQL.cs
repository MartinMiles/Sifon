using System;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Forms;
using Sifon.Forms.Base;

namespace Sifon.Forms.SQL
{
    internal partial class InstallSQL : BaseForm, IDatabaseInstall, IInstallDatabase
    {
        public event EventHandler<EventArgs<IDatabaseInstall>> InstallClicked = delegate { };

        public InstallSQL()
        {
            InitializeComponent();
        }

        private void defaultsButton_Click(object sender, EventArgs e)
        {
            textInstance.Text = ".\\SQLSERVER";
            textPassword.Text = "SA_PASSWORD";
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            ToggleControls(false);
            ToggleSpinner(false);

            InstallClicked(this, new EventArgs<IDatabaseInstall>(this));


        }

        public void ToggleControls(bool enabled)
        {
            textInstance.Enabled = enabled;
            buttonInstall.Enabled = enabled;
            textPassword.Enabled = enabled;
            button1.Enabled = enabled;
        }
        private void ToggleSpinner(bool enabled)
        {
            loadingCircle.Visible = !enabled;
            loadingCircle.Active = !enabled;
        }

        public void UpdateView(bool result) // TODO: Do we need this method at all ?
        {
            ToggleControls(true);
            ToggleSpinner(true);

            if (result)
            {
                ShowInfo("Success", "SQL Server Express instance has been successfully installed");
                DialogResult = DialogResult.OK;
                Close();

            }
            else
            {
                ShowError("Something went wrong", "Solr instance has NOT been installed");
            }
        }

        #region IDatabaseInstall

        public string Instance
        {
            get => textInstance.Text;
            set => textInstance.Text = value;
        }

        public string Password
        {
            get => textPassword.Text;
            set => textPassword.Text = value;
        }

        #endregion
    }
}
