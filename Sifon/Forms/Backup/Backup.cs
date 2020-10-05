using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Extensions;
using Sifon.Forms.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Statics;

namespace Sifon.Forms.Backup
{
    public partial class Backup : BaseForm, IBackupView, IBackupRemoverViewModel
    {
        public event AsyncEventHandler<EventArgs<string>> InstanceChanged;
        public event EventHandler<EventArgs<string>> ValidateBeforeClose = delegate { };

        internal Backup()
        {
            InitializeComponent();
            new BackupPresenter(this);
        }

        #region Private form event handlers

        private void Loaded(object sender, EventArgs e)
        {
            Raise_FormLoaded();
        }

        private async void comboInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InstanceChanged != null)
            {
                await InstanceChanged(sender, new EventArgs<string>(WebsiteZip));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listDatabases.SelectAll();
            EnableDisableMainButton();
        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkDatabases.Checked = listDatabases.SelectedItems.Count > 0;
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            buttonBackup.Enabled = false;
            ValidateBeforeClose(this, new EventArgs<string>(DestinationFolder));
        }
   
        private void buttonBackupLocation_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textDestinationFolderToBackup, true);
            checkFiles.Checked = textDestinationFolderToBackup.Text.Length > 0;
        }

        #endregion

        public void ValidateAndRun(IEnumerable<string> validationMessages)
        {
            if (!ShowValidationError(validationMessages)) return;

            if (!listDatabases.IsEmpty() || ShowYesNo(Messages.Backup.ConfirmDatabases.Caption, Messages.Backup.ConfirmDatabases.Message))
            {
                ToggleControls(false);
                DialogResult = DialogResult.OK;
            }
        }

        public void PopulateInstancesDropdown(IEnumerable<string> sitecoreInstances)
        {
            foreach (var siteName in sitecoreInstances)
            {
                comboInstances.Items.Add(siteName);
            }

            if (comboInstances.Items.Count > 0)
            {
                comboInstances.SelectedIndex = 0;
            }

            EnableDisableMainButton();
        }

        public void PopulateHostnamesListboxForSite(IEnumerable<KeyValuePair<string, string>> hostnames, string[] columnNames)
        {
            dataGrid.ShowDataGrid(hostnames, columnNames);
        }

        public void ToggleControls(bool enabled)
        {
            textDestinationFolderToBackup.Enabled = enabled;
            comboInstances.Enabled = enabled;
            checkDatabases.Enabled = enabled;
            checkFiles.Enabled = enabled;

            Cursor = enabled ? Cursors.Arrow : Cursors.WaitCursor;
        }

        //public void PopulateDatabasesListboxForSite(IEnumerable<string> databaseNames, IEnumerable<string> errors)
        public void PopulateDatabasesListboxForSite(IDatabase viewModel, IEnumerable<string> errors)
        {
            listDatabases.Items.Clear();
            foreach (string databaseName in viewModel.Databases)
            {
                listDatabases.Items.Add(databaseName);
            }

            if (errors.Any())
            {
                ShowError(Messages.Backup.RetrievingDatabasesFailed, errors.First());
            }
        }

        public void SetFieldsAndCheckboxes(IBackupRestoreFolders model) //
        {
            XConnectFolder = model.XConnectFolder;
            IdentityFolder = model.IdentityFolder;
            HorizonFolder = model.HorizonFolder;
            PublishingFolder = model.PublishingFolder;
            CommerceSites = model.CommerceSites;

            checkFiles.Enabled = true;
            checkXconnect.Enabled = model.XConnectFolder.NotEmpty();
            checkIds.Enabled = model.IdentityFolder.NotEmpty();
            checkHorizon.Enabled = model.HorizonFolder.NotEmpty();
            checkPublishing.Enabled = model.PublishingFolder.NotEmpty();
            checkCommerce.Enabled = model.CommerceSites.Any();
        }

        private void textDestinationFolderToBackup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text.Trim() == String.Empty)
            {
                //errorProvider1.SetError(txtLastName, "Last Name is Required");
                e.Cancel = true;
            }
        }

        private void checkFiles_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableMainButton();
        }

        private void checkDatabases_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableMainButton();
        }

        public override void CloseDialog()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Backup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Raise_FormClosing();
        }

        #region IBackupRemoverViewModel implementation

        public EmbeddedActivity EmbeddedActivity => EmbeddedActivity.Backup;
        public string DestinationFolder => textDestinationFolderToBackup.Text.TrimEnd('\\');

        public bool ProcessDatabases => checkDatabases.Checked;
        public bool WebsiteChecked => checkFiles.Checked;
        public bool XConnectChecked => checkXconnect.Checked;
        public bool IdentityChecked => checkIds .Checked;
        public bool PublishingChecked => checkHorizon .Checked;
        public bool HorizonChecked => checkPublishing .Checked;
        public bool CommerceChecked => checkCommerce.Checked;

        public string WebsiteZip => comboInstances.SelectedItem.ToString();

        //public string XConnectZip { get; private set; }
        //public string IdentityZip { get; private set; }
        //public string HorizonZip { get; private set; }
        //public string PublishingZip { get; private set; }
        public Dictionary<string, string> CommerceSites { get; set; }

        public string WebsiteFolder { get; set; }
        public string XConnectFolder { get; set; }
        public string IdentityFolder { get; set; }
        public string HorizonFolder { get; set; }                // not used - implemented only for interface compliance with restore
        public string PublishingFolder { get; set; }      // not used - implemented only for interface compliance with restore

        public string[] Databases => listDatabases.Selected();

        #endregion
    }
}
