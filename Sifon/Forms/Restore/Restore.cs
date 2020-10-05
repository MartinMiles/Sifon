using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Extensions;
using Sifon.Forms.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Shared.Statics;
using Sifon.Statics;

namespace Sifon.Forms.Restore
{
    public partial class Restore : BaseForm, IRestoreView, IRestoreViewModel
    {
        public event EventHandler<EventArgs<string>> ValidateBeforeClose = delegate { };
        public event EventHandler<EventArgs<string>> FolderSelected = delegate { };

        #region IBackupRestoreModel implementation

        public EmbeddedActivity EmbeddedActivity => EmbeddedActivity.Restore;
        public string DestinationFolder => textSourceFolder.Text.TrimEnd('\\');

        #region IBackupRestoreCheckboxes implementation

        public bool WebsiteChecked => checkFiles.Checked;

        public bool XConnectChecked => checkXconnect.Checked;

        public bool IdentityChecked => checkIDS.Checked;

        public bool PublishingChecked => checkHorizon.Checked;

        public bool HorizonChecked => checkPublishing.Checked;

        public bool CommerceChecked => checkCommerce.Checked;

        #endregion

        #region IRestoreZips implementation

        public string WebsiteZip { get; private set; }
        public string XConnectZip { get; private set; }
        public string IdentityZip { get; private set; }
        public string HorizonZip { get; private set; }
        public string PublishingZip { get; private set; }

        #endregion

        #region IBackupRestoreFolders implementation

        public string WebsiteFolder { get; private set; }
        public string XConnectFolder { get; private set; }
        public string IdentityFolder { get; private set; }
        public string HorizonFolder { get; private set; }
        public string PublishingFolder { get; private set; }
        public Dictionary<string, string> CommerceSites { get; private set; }

        #endregion

        #region IDatabase implementation

        public bool ProcessDatabases => checkDatabases.Checked;
        public string[] Databases => listDatabases.Selected().Select(d => d.TrimEnd(".bak")).ToArray();

        #endregion

        #endregion

        public Restore()
        {
            InitializeComponent();
            new RestorePresenter(this);
        }

        private void Restore_Load(object sender, EventArgs e)
        {
            Raise_FormLoaded();
        }

        public void DisplayDatabases(IEnumerable<string> databaseBackups)
        {
            listDatabases.Items.Clear();
            foreach (string file in databaseBackups)
            {
                listDatabases.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
            }

            linkSelectAll.Visible = databaseBackups.Any();

            listDatabases.BackColor = databaseBackups.Any() ? SystemColors.Window : SystemColors.Control;
            listDatabases.Enabled = databaseBackups.Any();
            checkDatabases.Enabled = databaseBackups.Any();
            checkDatabases.Checked = !databaseBackups.Any() ? false : listDatabases.SelectedItems.Count > 0;

            StateDatabaseReady = true;
        }

        private void buttonBackupLocation_Click(object sender, EventArgs e)
        {
            SetRestoreButtonTitle(Settings.Buttons.Loading);
            Raise_FolderBrowserClicked(textSourceFolder, false);
            //SetRestoreButton(false);
        }

        private void textSourceFolder_TextChanged(object sender, EventArgs e)
        {
            ResetState();
            FolderSelected(this, new EventArgs<string>(textSourceFolder.Text));
        }

        public void ShowDatagrid(IEnumerable<KeyValuePair<string, string>> list, string[] columns)
        {
            groupGrid.Text = list.Any() ? Messages.Restore.RestoreTargetFound : Messages.Restore.RestoreTargetNotFound;
            dataGrid.ShowDataGrid(list, columns);
            stateGridReady = true;
        }

        public void SetSites(IRestoreViewModel model)
        {
            WebsiteZip = model.WebsiteZip;
            WebsiteFolder = model.WebsiteFolder;

            XConnectZip = model.XConnectZip;
            XConnectFolder = model.XConnectFolder;

            IdentityZip = model.IdentityZip;
            IdentityFolder = model.IdentityFolder;

            HorizonZip = model.HorizonZip;
            HorizonFolder = model.HorizonFolder;

            PublishingZip = model.PublishingZip;
            PublishingFolder = model.PublishingFolder;

            CommerceSites = model.CommerceSites;

            checkFiles.Enabled = model.WebsiteZip.NotEmpty();
            checkXconnect.Enabled = model.XConnectZip.NotEmpty();
            checkIDS.Enabled = model.IdentityZip.NotEmpty();
            checkHorizon.Enabled = model.HorizonZip.NotEmpty();
            checkPublishing.Enabled = model.PublishingZip.NotEmpty();
            checkCommerce.Enabled = model.CommerceSites.Any();

            DisplayDatabases(model.Databases);

            stateSitesReady = true;
        }

        protected void ToggleControls(bool enabled)
        {
            buttonBackupLocation.Enabled = enabled;
            checkDatabases.Enabled = enabled;
            checkFiles.Enabled = enabled;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listDatabases.SelectAll();
            checkDatabases.Checked = listDatabases.SelectedItems.Count > 0;
            SetRestoreButton(RestoreButtonCriteria);
        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkDatabases.Enabled = listDatabases.SelectedItems.Count > 0;
        }

        private void checkFiles_CheckedChanged(object sender, EventArgs e)
        {
            SetRestoreButton(RestoreButtonCriteria);
        }

        private void checkDatabases_CheckedChanged(object sender, EventArgs e)
        {
            SetRestoreButton(RestoreButtonCriteria);
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            buttonRestore.Enabled = false;
            ValidateBeforeClose(this, new EventArgs<string>(textSourceFolder.Text));
        }

        public void ValidateAndRun(IEnumerable<string> validationMessages)
        {
            if (!ShowValidationError(validationMessages)) return;

            if (!listDatabases.IsEmpty() || ShowYesNo(Messages.Backup.ConfirmDatabases.Caption, Messages.Backup.ConfirmDatabases.Message))
            {
                ToggleControls(false);
                DialogResult = DialogResult.OK;
            }
        }

        public override void CloseDialog()
        {
            DialogResult = DialogResult.Cancel;
        }
        
        #region Loading State - to be reworked ort moved into base class

        private bool stateDatabaseReady;
        private bool stateSitesReady;
        private bool stateGridReady;

        private bool StateGridReady
        {
            get => stateGridReady;
            set
            {
                stateGridReady = value;
                SetCursor(stateDatabaseReady && stateSitesReady&& stateGridReady);
            }
        }
        private bool StateDatabaseReady
        {
            get => stateDatabaseReady;
            set
            {
                stateDatabaseReady = value;
                SetCursor(stateDatabaseReady && stateSitesReady && stateGridReady);
            }
        }
        private bool StateSitesReady
        {
            get => stateSitesReady;
            set
            {
                stateSitesReady = value;
                SetCursor(stateDatabaseReady && stateSitesReady && stateGridReady);
            }
        }

        private void ResetState()
        {
            stateDatabaseReady = false;
            stateSitesReady = false;
            stateGridReady = false;

            SetCursor(false);
        }
        
        private void SetCursor(bool ready)
        {
            Cursor = ready ? Cursors.Arrow : Cursors.WaitCursor;
        }

        #endregion
    }
}
