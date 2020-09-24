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
    public partial class Restore : BaseForm, IRestoreView, IBackupRestoreModel
    {
        public event EventHandler<EventArgs<string>> ValidateBeforeClose = delegate { };
        public event EventHandler<EventArgs<string>> FolderSelected = delegate { };

        public Restore()
        {
            InitializeComponent();
            new RestorePresenter(this);
        }

        private void Restore_Load(object sender, EventArgs e)
        {
            Raise_FormLoaded();
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

        public void LoadFolder(IEnumerable<string> databaseBackups)
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

        public void ShowDatagrid(IEnumerable<KeyValuePair<string, string>> list)
        {
            groupGrid.Text = list.Any() ? Messages.Restore.RestoreTargetFound : Messages.Restore.RestoreTargetNotFound;
            dataGrid.ShowDataGrid(list, new[] { "Backup archive files location", "Destination folder to restore" });

            stateGridReady = true;
        }

        public void SetXConnctAndIdentity(IEnumerable<KeyValuePair<string, string>> list)
        {
            var site = list.FirstOrDefault(i => !CheckSite(i.Key) && !i.Key.Contains(Settings.Parameters.XConnect) && !i.Key.Contains(Settings.Parameters.IdentityServer));
            var xconnect = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.XConnect));
            var identityPath = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.IdentityServer));

            SitecoreInstance = site.Key;
            XConnect = xconnect.Key;
            XConnectFolder = xconnect.Value;
            IdentityServer = identityPath.Key;
            IdentityServerFolder = identityPath.Value;
            CommerceSites = list.Where(i => CheckSite(i.Key));

            checkFiles.Enabled = SitecoreInstance != null && SitecoreInstance != null;
            checkXconnect.Enabled = XConnect != null && XConnectFolder != null;
            checkIDS.Enabled = IdentityServer != null && IdentityServerFolder != null;
            checkCommerce.Enabled = CommerceSites != null && CommerceSites.Any();

            stateSitesReady = true;
        }

        private bool CheckSite(string site)
        {
            string[] commerceSites = { "Authoring", "Ops", "Shops", "Minions", "BizFx" };
            return commerceSites.Any(s => site.Contains(s));
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

        #region IBackupRestoreModel implementation

        public EmbeddedActivity EmbeddedActivity => EmbeddedActivity.Restore;
        public string DestinationFolder => textSourceFolder.Text.TrimEnd('\\');
        public string SitecoreInstance { get; private set; }
        public bool ProcessDatabases => checkDatabases.Checked;
        public bool ProcessWebroot => checkFiles.Checked;
        public bool ProcessXconnect => checkXconnect.Checked;
        public bool ProcessIDS => checkIDS.Checked;
        public bool ProcessHorizon => checkHorizon.Checked;
        public bool ProcessPublishing => checkPublishing.Checked;
        public bool ProcessCommerce => checkCommerce.Checked;
        public string XConnect { get; private set; }
        public string IdentityServer { get; private set; }
        public string Horizon { get; private set; }
        public string PublishingService { get; private set; }
        public IEnumerable<KeyValuePair<string, string>> CommerceSites { get; private set; }

        public string XConnectFolder { get; private set; }
        public string IdentityServerFolder { get; private set; }
        public string[] SelectedDatabases => listDatabases.Selected().Select(d => d.TrimEnd(".bak")).ToArray();

        #endregion

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
