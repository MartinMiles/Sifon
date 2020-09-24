using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Extensions;
using Sifon.Forms.Base;
using Sifon.Shared.Events;
using Sifon.Statics;

namespace Sifon.Forms.Backup
{
    public partial class Backup : BaseForm, IBackupView, IBackupRestoreModel
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
                await InstanceChanged(sender, new EventArgs<string>(SitecoreInstance));
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

        public void PopulateHostnamesListboxForSite(IEnumerable<KeyValuePair<string, string>> hostnames)
        {
            dataGrid.ShowDataGrid(hostnames, new[] { "Protocol", "Hostname" });
        }

        public void ToggleControls(bool enabled)
        {
            textDestinationFolderToBackup.Enabled = enabled;
            comboInstances.Enabled = enabled;
            checkDatabases.Enabled = enabled;
            checkFiles.Enabled = enabled;

            Cursor = enabled ? Cursors.Arrow : Cursors.WaitCursor;
        }

        public void PopulateDatabasesListboxForSite(IEnumerable<string> databaseNames, IEnumerable<string> errors)
        {
            listDatabases.Items.Clear();
            foreach (string databaseName in databaseNames)
            {
                listDatabases.Items.Add(databaseName);
            }

            if (errors.Any())
            {
                ShowError("Retrieving databases error", errors.First());
            }
        }

        //public void SetCheckboxes(bool site, bool xconnect, bool ids, bool horizon, bool publishing, bool commerceSites)
        //{
        //    checkFiles.Enabled = site;
        //    checkXconnect.Enabled = xconnect;
        //    checkIds.Enabled = ids;
        //    checkHorizon.Enabled = horizon;
        //    checkPublishing.Enabled = publishing;
        //    checkCommerce.Enabled = commerceSites;
        //}

        // TODO: shared for all backup restore. maybe to base?

        public void SetFieldsandCheckboxes(BackupViewModel model)
        {
            XConnect = model.XConnect;
            IdentityServer = model.Identity;
            Horizon = model.Horizon;
            PublishingService = model.Publishing;
            CommerceSites = model.CommerceSites;

            checkFiles.Enabled = model.SiteChecked;
            checkXconnect.Enabled = model.XConnectChecked;
            checkIds.Enabled = model.IdentityChecked;
            checkHorizon.Enabled = model.HorizonChecked;
            checkPublishing.Enabled = model.PublishingChecked;
            checkCommerce.Enabled = model.CommerceChecked;

        }

        //public void SetXConnctAndIdentity(string xconnectFolder, string idsFolder, IEnumerable<KeyValuePair<string, string>> commerceSites)
        //{
        //    XConnect = xconnectFolder;
        //    IdentityServer = idsFolder;
        //    CommerceSites = commerceSites;
        //}

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

        #region IBackupRestoreModel implementation

        public EmbeddedActivity EmbeddedActivity => EmbeddedActivity.Backup;
        public string DestinationFolder => textDestinationFolderToBackup.Text.TrimEnd('\\');
        public string SitecoreInstance => comboInstances.SelectedItem.ToString();
        public bool ProcessDatabases => checkDatabases.Checked;
        public bool ProcessWebroot => checkFiles.Checked;
        public bool ProcessXconnect => checkXconnect.Checked;
        public bool ProcessIDS => checkIds .Checked;
        public bool ProcessHorizon => checkHorizon .Checked;
        public bool ProcessPublishing => checkPublishing .Checked;
        public bool ProcessCommerce => checkCommerce.Checked;

        public string XConnect { get; private set; }
        public string IdentityServer { get; private set; }
        public string Horizon { get; private set; }
        public string HorizonFolder { get; }                // not used - implemented only for interface compliance with restore
        public string PublishingServiceFolder { get; }      // not used - implemented only for interface compliance with restore

        public string PublishingService { get; private set; }
        public IEnumerable<KeyValuePair<string, string>> CommerceSites { get; private set; }
        public string XConnectFolder { get; private set; }
        public string IdentityServerFolder { get; private set; }
        public string[] SelectedDatabases => listDatabases.Selected();

        #endregion
    }
}
