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
    public partial class Remover : BaseForm, IRemoverView, IBackupRemoverViewModel
    {
        public event EventHandler<EventArgs> FormLoaded = delegate { }; // TODO: Remove in favor of base or it should be that?
        public event EventHandler<EventArgs<string>> InstanceChanged = delegate { };
        public event EventHandler<EventArgs<string>> DatabaseFilterChanged = delegate { };
        public event EventHandler<EventArgs> ClosingForm = delegate { };

        private string SelectedHostname => (string)comboInstances.SelectedItem;

        #region IBackupRestoreModel implementation

        public EmbeddedActivity EmbeddedActivity => EmbeddedActivity.Remove;
        public string DestinationFolder => textWebfolder.Text.TrimEnd('\\');

        #region IBackupRestoreCheckboxes implementation

        public bool WebsiteChecked => checkFiles.Checked;
        public bool XConnectChecked => checkXconnect.Checked;
        public bool IdentityChecked => checkIDS.Checked;
        public bool PublishingChecked => checkHorizon.Checked;
        public bool HorizonChecked => checkPublishing.Checked;
        public bool CommerceChecked => checkCommerce.Checked;

        #endregion

        #region IBackupRestoreFolders

        public Dictionary<string, string> CommerceSites { get; set; }


        public string WebsiteFolder
        {
            get => textWebfolder.Text.TrimEnd('\\');
            set => textWebfolder.Text = value;
        }

        //TODO: setters

        public string XConnectFolder // => textXConnectFolder.Text.TrimEnd('\\');
        {
            get => textXConnectFolder.Text.TrimEnd('\\');
            set => textXConnectFolder.Text = value;
        }

        public string IdentityFolder //=> textIdsFolder.Text.TrimEnd('\\');
        {
            get => textIdsFolder.Text.TrimEnd('\\');
            set => textIdsFolder.Text = value;
        }

        public string HorizonFolder
        {
            get => textHorizonFolder.Text.TrimEnd('\\');
            set => textHorizonFolder.Text = value;
        }

        public string PublishingFolder
        {
            get => textPublishingFolder.Text.TrimEnd('\\');
            set => textPublishingFolder.Text = value;
        }

        #endregion

        #region IDatabase implementation

        public bool ProcessDatabases => checkDatabases.Checked;
        public string[] Databases => listDatabases.Selected();

        #endregion

        #endregion

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
                ShowError(Messages.Backup.RetrievingDatabasesFailed, errors.First());
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

        public void SetWebfoldersAndCheckboxes(IBackupRestoreFolders model)
        {
            checkFiles.Checked = model.WebsiteFolder.NotEmpty();

            if (model.WebsiteFolder != null)
            {
                textWebfolder.Text = model.WebsiteFolder;
            }

            //TODO: Move this logic into model's booleans
            checkFiles.Visible = model.WebsiteFolder != null || comboInstances.SelectedIndex == 0;
            textWebfolder.Visible = model.WebsiteFolder != null || comboInstances.SelectedIndex == 0;
            buttonBrowseWebfolder.Visible = model.WebsiteFolder != null || comboInstances.SelectedIndex == 0;

            if (model.XConnectFolder.NotEmpty())
            {
                textXConnectFolder.Text = model.XConnectFolder;
            }

            checkXconnect.Visible = model.XConnectFolder.NotEmpty() || comboInstances.SelectedIndex == 0;
            textXConnectFolder.Visible = model.XConnectFolder.NotEmpty() || comboInstances.SelectedIndex == 0;
            buttonBrowseXconnect.Visible = model.XConnectFolder.NotEmpty() || comboInstances.SelectedIndex == 0;

            if (model.IdentityFolder != null)
            {
                textIdsFolder.Text = model.IdentityFolder;
            }
            checkIDS.Visible = model.IdentityFolder != null || comboInstances.SelectedIndex == 0;
            textIdsFolder.Visible = model.IdentityFolder != null || comboInstances.SelectedIndex == 0;
            buttonBrowseIDS.Visible = model.IdentityFolder != null || comboInstances.SelectedIndex == 0;

            if (model.HorizonFolder != null)
            {
                textHorizonFolder.Text = model.HorizonFolder;
            }
            checkHorizon.Visible = model.HorizonFolder != null || comboInstances.SelectedIndex == 0;
            textHorizonFolder.Visible = model.HorizonFolder != null || comboInstances.SelectedIndex == 0;
            buttonBrowseHorizon.Visible = model.HorizonFolder != null || comboInstances.SelectedIndex == 0;

            if (model.PublishingFolder != null)
            {
                textPublishingFolder.Text = model.PublishingFolder;
            }
            checkPublishing.Visible = model.PublishingFolder != null || comboInstances.SelectedIndex == 0;
            textPublishingFolder.Visible = model.PublishingFolder != null || comboInstances.SelectedIndex == 0;
            buttonBrowsePublishing.Visible = model.PublishingFolder != null || comboInstances.SelectedIndex == 0;

            CommerceSites = model.CommerceSites;
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

        #region Checkboxes enabling / disabling

        private void checkFiles_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(sender as CheckBox, textWebfolder, buttonBrowseWebfolder);
        }

        private void checkXconnect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(sender as CheckBox, textXConnectFolder, buttonBrowseXconnect);
        }

        private void checkIDS_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(sender as CheckBox, textIdsFolder, buttonBrowseIDS);
        }

        private void checkHorizon_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(sender as CheckBox, textHorizonFolder, buttonBrowseHorizon);
        }

        private void checkPublishing_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChanged(sender as CheckBox, textPublishingFolder, buttonBrowsePublishing);
        }

        private void CheckBoxChanged(CheckBox checkBox, TextBox textbox, Button button)
        {
            textbox.ReadOnly = !checkBox.Checked;
            button.Enabled = checkBox.Checked;
            EnableDisableMainButton();
        }

        #endregion

        private void checkDatabases_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            listDatabases.BackColor = checkBox.Checked ? SystemColors.Window : SystemColors.Control;

            EnableDisableMainButton();
        }

        #region Browse buttons handlers

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

        private void buttonBrowseHorizon_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textHorizonFolder, false);
        }

        private void buttonBrowsePublishing_Click(object sender, EventArgs e)
        {
            Raise_FolderBrowserClicked(textPublishingFolder, false);
        }

        #endregion

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