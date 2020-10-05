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
    public partial class Restore : BaseForm, IRestoreView, IRestore
    {
        public event EventHandler<EventArgs<string>> ValidateBeforeClose = delegate { };
        public event EventHandler<EventArgs<string>> FolderSelected = delegate { };

        #region IBackupRestoreModel implementation

        public EmbeddedActivity EmbeddedActivity => EmbeddedActivity.Restore;
        public string DestinationFolder => textSourceFolder.Text.TrimEnd('\\');

        public bool WebsiteChecked
        {
            get => checkFiles.Checked;
            set => checkFiles.Checked = value;
        }

        public bool XConnectChecked
        {
            get => checkXconnect.Checked;
            set => checkXconnect.Checked = value;
        }
        
        public bool IdentityChecked
        {
            get => checkIDS.Checked;
            set => checkIDS.Checked = value;
        }

        public bool PublishingChecked
        {
            get => checkHorizon.Checked;
            set => checkHorizon.Checked = value;
        }

        public bool HorizonChecked
        {
            get => checkPublishing.Checked;
            set => checkPublishing.Checked = value;
        }

        public bool CommerceChecked
        {
            get => checkCommerce.Checked;
            set => checkCommerce.Checked = value;
        }

        public string WebsiteZip { get; private set; }
        public string XConnectZip { get; private set; }
        public string IdentityZip { get; private set; }
        public string HorizonZip { get; private set; }
        public string PublishingZip { get; private set; }

        public string WebsiteFolder { get;  set; }
        public string XConnectFolder { get;  set; }
        public string IdentityFolder { get;  set; }
        public string HorizonFolder { get;  set; }
        public string PublishingFolder { get;  set; }
        public Dictionary<string, string> CommerceSites { get;  set; }

        public bool ProcessDatabases => checkDatabases.Checked;
        public string[] Databases => listDatabases.Selected().Select(d => d.TrimEnd(".bak")).ToArray();

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

        // TODO: Should recieve interface
        public void SetOtherSites(IRestore model)
        {
            //var site = model.WebsiteFolder; // list.FirstOrDefault(i => IsMainSitecoreSite(i.Key));
            //var xconnect = model.XConnectFolder; // list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.XConnect));
            //var identityPath = model.IdentityFolder; // list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.IdentityServer));
            //var horizonPath = model.HorizonFolder; // list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.Horizon));
            //var publishingPath = model.PublishingFolder; //list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.PublishingService));

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

            //model.WebsiteChecked = model.WebsiteZip.NotEmpty();
            //model.XConnectChecked = model.XConnectZip.NotEmpty();
            //model.IdentityChecked = model.IdentityZip.NotEmpty();
            //model.HorizonChecked = model.HorizonZip.NotEmpty();
            //model.PublishingChecked = model.PublishingZip.NotEmpty();
            //model.CommerceChecked = model.CommerceSites.Any()

            DisplayDatabases(model.Databases);

            stateSitesReady = true;
        }

        //public void SetOtherSites(IEnumerable<KeyValuePair<string, string>> list)
        //{
        //    var site = list.FirstOrDefault(i => IsMainSitecoreSite(i.Key)); 
        //    var xconnect = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.XConnect));
        //    var identityPath = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.IdentityServer));
        //    var horizonPath = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.Horizon));
        //    var publishingPath = list.FirstOrDefault(i => i.Key.Contains(Settings.Parameters.PublishingService));

        //    SitecoreInstanceZip = site.Key;

        //    XConnectZip = xconnect.Key;
        //    XConnectFolder = xconnect.Value;

        //    IdentityZip = identityPath.Key;
        //    IdentityFolder = identityPath.Value;

        //    HorizonZip = horizonPath.Key;
        //    HorizonFolder = horizonPath.Value;

        //    PublishingServiceZip = publishingPath.Key;
        //    PublishingFolder = publishingPath.Value;

        //    CommerceSites = list.Where(i => CheckCommerceSite(i.Key));

        //    // TODO: checkboxes
        //    checkFiles.Enabled = SitecoreInstanceZip != null && SitecoreInstanceZip != null;
        //    checkXconnect.Enabled = XConnectZip != null && XConnectFolder != null;
        //    checkIDS.Enabled = IdentityZip != null && IdentityFolder != null;
        //    checkHorizon.Enabled = HorizonZip != null && HorizonZip != null;
        //    checkPublishing.Enabled = PublishingServiceZip != null && PublishingServiceZip != null;
        //    checkCommerce.Enabled = CommerceSites.Any();

        //    stateSitesReady = true;
        //}



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
