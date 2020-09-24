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

namespace Sifon.Forms.Remover
{
    public partial class Remover : BaseForm, IRemoverView, IBackupRestoreModel
    {
        public event EventHandler<EventArgs> FormLoaded = delegate { };
        public event EventHandler<EventArgs<string>> InstanceChanged = delegate { };
        public event EventHandler<EventArgs<string>> DatabaseFilterChanged = delegate { };
        public event EventHandler<EventArgs> ClosingForm = delegate { };

        private string SelectedHostname => (string)comboInstances.SelectedItem;

        public Remover()
        {
            InitializeComponent();
            new RemoverPresenter(this);
        }

        #region Form handlers

        private void Remover_Load(object sender, EventArgs e)
        {
            ResetState();
            FormLoaded.Invoke(this, e);
        }

        private void comboInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetState();
            InstanceChanged.Invoke(this, new EventArgs<string>(SelectedHostname));
        }

        #endregion

        public void PopulateInstancesDropdown(IEnumerable<string> sitecoreInstances)
        {
            comboInstances.Items.Clear();
            comboInstances.Items.Add(Settings.ManualEntry);

            foreach (var instance in sitecoreInstances)
            {
                comboInstances.Items.Add(instance);
            }

            comboInstances.SelectedIndex = comboInstances.Items.Count > 1 ? 1 : 0;
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

            StateDatabaseReady = true;  
        }

        public void ToggleControls(bool enabled)
        {
            textDatabasePrefix.Enabled = enabled;
            buttonRemove.Enabled = enabled;
            linkSelectAll.Visible = listDatabases.Items.Count > 0;
        }

        // TODO: why not active - smth got missed out? TEST WITH new
        //protected void ScriptComplete()
        public void FinishUI()
        {
            textDatabasePrefix.Enabled = true;
            buttonRemove.Enabled = true;

            labelDatabasePrefix.Visible = comboInstances.SelectedIndex == 0;
            textDatabasePrefix.Visible = comboInstances.SelectedIndex == 0;

            if (comboInstances.SelectedIndex > 0)
            {
                textDatabasePrefix.Text = String.Empty;
            }
        }

        public void SetWebfoldersAndCheckboxes(string name, string xconnectFolder, string idsFolder, IEnumerable<KeyValuePair<string, string>> commerceSites)
        {
            checkFiles.Checked = name.NotEmpty();

            if (name != null)
            {
                textWebfolder.Text = name;
            }
            checkFiles.Visible = name != null || comboInstances.SelectedIndex == 0;
            textWebfolder.Visible = name != null || comboInstances.SelectedIndex == 0;
            buttonBrowseWebfolder.Visible = name != null || comboInstances.SelectedIndex == 0;

            if (xconnectFolder != null)
            {
                textXConnectFolder.Text = xconnectFolder;
            }

            checkXconnect.Visible = xconnectFolder != null || comboInstances.SelectedIndex == 0;
            textXConnectFolder.Visible = xconnectFolder != null || comboInstances.SelectedIndex == 0;
            buttonBrowseXconnect.Visible = xconnectFolder != null || comboInstances.SelectedIndex == 0;

            if (idsFolder != null)
            {
                textIdsFolder.Text = idsFolder;
            }
            checkIDS.Visible = idsFolder != null || comboInstances.SelectedIndex == 0;
            textIdsFolder.Visible = idsFolder != null || comboInstances.SelectedIndex == 0;
            buttonBrowseIDS.Visible = idsFolder != null || comboInstances.SelectedIndex == 0;

            CommerceSites = commerceSites;
            checkCommerce.Visible = CommerceSites != null && CommerceSites.Any();

            StateSitesReady = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listDatabases.SelectAll();
            EnableDisableMainButton();
        }

        private string ConfirmationMessage
        {
            get
            {
                var message = "Clicking Yes will entirely";

                if (checkDatabases.Checked)
                {
                    message += $" remove selected databases";
                }

                if (checkFiles.Checked && checkDatabases.Checked)
                {
                    message += " and";
                }

                if (checkFiles.Checked)
                {
                    message += " remove inner content of web root folder";
                }

                return message + ", leaving IIS site settings, services and Solr data";
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (ShowYesNo(Messages.General.YesNoCaption, ConfirmationMessage))
            {
                if (listDatabases.SelectedItems.Count == listDatabases.Items.Count || ShowYesNo(Messages.Remove.ConfirmDatabases.Caption, Messages.Remove.ConfirmDatabases.Message))
                {
                    buttonRemove.Enabled = false;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void textDatabasePrefix_TextChanged(object sender, EventArgs e)
        {
            DatabaseFilterChanged(this, new EventArgs<string>(((TextBox)sender).Text.Trim()));
        }

        private void checkFiles_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            textWebfolder.ReadOnly = !checkBox.Checked;
            buttonBrowseWebfolder.Enabled = checkBox.Checked;

            EnableDisableMainButton();
        }
        private void checkXconnect_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            textXConnectFolder.ReadOnly = !checkBox.Checked;
            buttonBrowseXconnect.Enabled = checkBox.Checked;

            EnableDisableMainButton();
        }

        private void checkIDS_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            textIdsFolder.ReadOnly = !checkBox.Checked;
            buttonBrowseIDS.Enabled = checkBox.Checked;

            EnableDisableMainButton();
        }
        private void checkDatabases_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            listDatabases.BackColor = checkBox.Checked ? SystemColors.Window : SystemColors.Control;

            EnableDisableMainButton();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textWebfolder, false);
        }

        private void buttonBrowseXconnect_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textXConnectFolder, false);
        }
        
        private void buttonBrowseIDS_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textIdsFolder, false);
        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkDatabases.Checked = !listDatabases.IsEmpty();
            EnableDisableMainButton();
        }
        public void ValidateAndRun(IEnumerable<string> validationMessages)
        {
            throw new NotImplementedException();
        }

        public override void CloseDialog()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            ClosingForm(this, new EventArgs());
        }

        #region IBackupRestoreModel implementation

        public EmbeddedActivity EmbeddedActivity => EmbeddedActivity.Remove;
        public string DestinationFolder => textWebfolder.Text.TrimEnd('\\');
        public string SitecoreInstance => comboInstances.SelectedItem.ToString();
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

        public string XConnectFolder => textXConnectFolder.Text.TrimEnd('\\');
        public string IdentityServerFolder => textIdsFolder.Text.TrimEnd('\\');

        public string[] SelectedDatabases => listDatabases.Selected();

        #endregion

        #region Loading State - to be reworked ort moved into base class

        private bool stateDatabaseReady;
        private bool stateSitesReady;

        private bool StateDatabaseReady
        {
            get => stateDatabaseReady;
            set
            {
                stateDatabaseReady = value;
                SetCursor(stateDatabaseReady && stateSitesReady);
            }
        }
        private bool StateSitesReady
        {
            get => stateSitesReady;
            set
            {
                stateSitesReady = value;
                SetCursor(stateDatabaseReady && stateSitesReady);
            }
        }

        private void ResetState()
        {
            stateDatabaseReady = false;
            stateSitesReady = false;
            SetCursor(false);
        }


        private void SetCursor(bool ready)
        {
            Cursor = ready ? Cursors.Arrow : Cursors.WaitCursor;
        }

        #endregion
    }
}