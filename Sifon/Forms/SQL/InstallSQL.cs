using System;
using System.Collections.Generic;
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
            new InstallDatabasePresenter(this);

            PopulateEditions();
            PopulateVersions();
        }

        private void PopulateEditions()
        {
            comboEditions.Items.Clear();
            comboEditions.DisplayMember = "Display";
            comboEditions.ValueMember = "Code";
            comboEditions.DataSource = Editions;
        }
        private void PopulateVersions()
        {
            comboVersions.Items.Clear();
            comboVersions.DisplayMember = "Display";
            comboVersions.ValueMember = "Code";
            comboVersions.DataSource = Versions;
        }

        private List<ComboItem> Versions = new List<ComboItem>
        {
            new ComboItem { Code = "Latest", Display="Latest version (chocolatey)" },
            new ComboItem { Code = "2019", Display="Microsoft SQL Server 2019" },
            new ComboItem { Code = "2017", Display="Microsoft SQL Server 2017" },
            new ComboItem { Code = "2016", Display="Microsoft SQL Server 2016" }
        };

        private List<ComboItem> Editions = new List<ComboItem>
        {
            new ComboItem { Code = "Express",   Display="EXPRESS: lightweight, 10 Gb per database limit" },
            new ComboItem { Code = "Developer", Display="DEVELOPER: non-prod development-limited" },
        };

        internal class ComboItem
        {
            public string Code { get; set; }
            public string Display { get; set; }
        }     

        private void defaultsButton_Click(object sender, EventArgs e)
        {
            textInstance.Text = SelectedEdition.Code == "Express" ? ".\\SQLSERVER" : ".";
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
            comboEditions.Enabled = enabled;
            comboVersions.Enabled = enabled;
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

        public void UpdateView(bool result)
        {
            ToggleControls(true);
            ToggleSpinner(true);

            if (result)
            {
                //no need to ShowInfo("Success") as it was already been мфдшвфеув фтв shown by actual GetDate from server
                DialogResult = DialogResult.OK;
               Close();

            }
            else
            {
                ShowError("Something went wrong", "SQL Server has NOT been installed");
            }
        }

        private ComboItem SelectedEdition => comboEditions.SelectedItem as ComboItem;
        private ComboItem SelectedVersion => comboVersions.SelectedItem as ComboItem;

        #region IDatabaseInstall

        public string Edition
        {
            get => SelectedEdition.Code;
            set => throw new NotImplementedException();
        }
        
        public string Version
        {
            get => SelectedVersion.Code;
            set => throw new NotImplementedException();
        }
        
        public string Instance
        {
            get
            {
                string instance = textInstance.Text.Trim();
                return instance.StartsWith(".\\") ? instance.Substring(2) : instance;

            }

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
