using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Statics;

namespace Sifon.Forms.SqlSettings
{
    internal partial class SqlSettings : BaseForm, ISqlSettingsView, ISqlServerRecord
    {
        public event EventHandler<EventArgs<string>> SelectedRecordChanged = delegate { };
        public event EventHandler<EventArgs<Tuple<string, ISqlServerRecord>>> SqlRecordRenamed = delegate { };
        public event EventHandler<EventArgs<ISqlServerRecord>> SqlRecordAdded = delegate { };
        public event EventHandler<EventArgs<string>> SqlRecordDeleted = delegate { };
        public event EventHandler<EventArgs<ISqlServerRecord>> TestClicked = delegate { };
        public event EventHandler<EventArgs> FormLoad = delegate { };
        public event EventHandler<EventArgs> ClosingForm = delegate { };

        private string oldName = String.Empty;
        
        #region ISqlServerRecord implementation

        public string RecordName => textName.Text.Trim();
        public string SqlServer => textInstance.Text.Trim();
        public string SqlAdminUsername => textUsername.Text.Trim();
        public string SqlAdminPassword
        {
            get => textPassword.Text.Trim();
            set => textPassword.Text = value;
        }

        #endregion

        public SqlSettings()
        {
            InitializeComponent();
            new SqlSettingsPresenter(this);
        }

        private void SqlSettings_Load(object sender, EventArgs e)
        {
            RevealPasswordWithinTextbox(textPassword, linkReveal, false);
            FormLoad(this, e);
        }

        public void PopulateServersDropdown(IEnumerable<string> serverRecords, string selectedRecord)
        {
            comboBoxServers.Items.Clear();
            comboBoxServers.Items.Add(Settings.Dropdowns.AddNewServer);

            foreach (var serverRecord in serverRecords)
            {
                comboBoxServers.Items.Add(serverRecord);
            }

            int selectedRecordIndex = comboBoxServers.Items.IndexOf(selectedRecord);
            comboBoxServers.SelectedIndex = comboBoxServers.Items.Count > 1 && selectedRecordIndex > -1 ? selectedRecordIndex : 0;
        }

        private void comboBoxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSave.Text = comboBoxServers.SelectedIndex > 0 ? Settings.Buttons.SaveAndClose : Settings.Buttons.Add;
            buttonDelete.Enabled = comboBoxServers.SelectedIndex > 0;

            if (comboBoxServers.SelectedIndex == 0)
            {
                textName.Text = String.Empty;
                textInstance.Text = String.Empty;
                textUsername.Text = String.Empty;
                textPassword.Text = String.Empty;
            }
            else
            {
                SelectedRecordChanged(this, new EventArgs<string>(comboBoxServers.SelectedItem.ToString()));
            }

            UpdateButtonsState();
        }

        public void SetSqlServerName(string name)
        {
            oldName = name;
            textName.Text = name;
        }

        public void SetSqlInstance(string instanceName)
        {
            textInstance.Text = instanceName;
        }

        public void SetSqlUsername(string username)
        {
            textUsername.Text = username;
        }

        public void SetSqlPassword(string password)
        {
            textPassword.Text = password;
        }

        public void ToggleControls(bool enabled)
        {
            comboBoxServers.Enabled = enabled;
            textName.Enabled = enabled;
            textInstance.Enabled = enabled;
            textUsername.Enabled = enabled;
            textPassword.Enabled = enabled;

            buttonDelete.Enabled = enabled;
            buttonTest.Enabled = enabled;
            buttonSave.Enabled = enabled;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            TestClicked(this, new EventArgs<ISqlServerRecord>(this));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SqlRecordDeleted(this, new EventArgs<string>(comboBoxServers.SelectedItem.ToString()));
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (comboBoxServers.SelectedIndex > 0)
            {
                SqlRecordRenamed(this, new EventArgs<Tuple<string, ISqlServerRecord>>(new Tuple<string, ISqlServerRecord>(oldName, this)));
            }
            else
            {
                SqlRecordAdded(this, new EventArgs<ISqlServerRecord>(this));
            }
        }

        private void RevealPasswordClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var label = (LinkLabel)sender;
            RevealPasswordWithinTextbox(textPassword, linkReveal);
        }
    }
}
