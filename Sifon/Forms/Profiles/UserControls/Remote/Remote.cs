using System;
using System.Drawing;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Initialize;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Extensions;
using Sifon.Shared.Statics;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    public partial class Remote : BaseUserControl, IRemoteView, IRemoteSettings
    {
        public event EventHandler<EventArgs<bool>> ToggleLastTabs = delegate { };
        public event EventHandler<EventArgs<string>> RemoteInitialized = delegate { };
        public event EventHandler<EventArgs<IRemoteSettings>> TestRemote = delegate { };

        private bool initialRemotingState;


        public Remote()
        {
            InitializeComponent();
            new RemotePresenter(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            RevealPassword(false);
            base.OnLoad(e);
        }

        public void EnableControls(bool value)
        {
            checkBoxRemote.Enabled = value;
            EnableRemotingControls(value);
        }

        public void SetCheckbox(bool enabled)
        {
            checkBoxRemote.Checked = enabled;
            EnableRemotingControls(enabled);
            initialRemotingState = checkBoxRemote.Checked;
        }

        public void SetHostname(string hostname)
        {
            textHostname.Text = hostname;
        }

        public void SetUsername(string username)
        {
            textUsername.Text = username;
        }

        public void SetPassword(string password)
        {
            textPassword.Text = password;
        }
        public void SetRemoteFolder(string remoteFolder)
        {
            textRemoteFolder.Text = remoteFolder;
            labelRemoteFolder.Text = "Remote folder" + (remoteFolder.NotEmpty() ? ":" : " (comes after initialization)");
        }

        private void checkBoxRemote_CheckedChanged(object sender, EventArgs e)
        {
            bool remote = ((CheckBox) sender).Checked;
            ValidateNotEmpty();
            EnableRemotingControls(remote);

            ToggleLastTabs(this, new EventArgs<bool>(remote == initialRemotingState));
        }

        private void EnableRemotingControls(bool value)
        {
            textHostname.Enabled = value;
            textUsername.Enabled = value;
            textPassword.Enabled = value;
            linkReveal.Enabled = value;

            UpdateButtons();
        }

        public void UpdateButtons()
        {
            buttonInitialize.Enabled = InitButtonEnabled;
            buttonTest.Enabled = TestButtonEnabled;
        }

        private void linkReveal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var label = (LinkLabel)sender;
            RevealPassword(label.Text.Contains(Settings.Labels.Reveal));
        }
        private void RevealPassword(bool reveal)
        {
            textPassword.PasswordChar = reveal ? new char() : '*';
            linkReveal.Text = reveal ? $"({Settings.Labels.Hide})" : $"({Settings.Labels.Reveal})";

            linkReveal.Location = new Point(reveal ? 244 : 235, 160);
        }

        private void buttonInitialize_Click(object sender, EventArgs e)
        {
            buttonInitialize.Enabled = false;
            var initializeForm = new InitRemote
            {
                StartPosition = FormStartPosition.CenterParent,
                RemoteSettings = this

            };
            if (initializeForm.ShowDialog() == DialogResult.OK && initializeForm.RemoteFolder.NotEmpty())
            {
                RemoteInitialized(this, new EventArgs<string>(initializeForm.RemoteFolder));
            }

            initializeForm.Dispose();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            ToggleTestButton(false);
            TestRemote(this, new EventArgs<IRemoteSettings>(this));
        }

        public void ToggleTestButton(bool enabled)
        {
            buttonTest.Enabled = enabled;
        }

        #region IRemoteSettings implementation

        public bool RemotingEnabled => checkBoxRemote.Checked;
        public string RemoteHostname => textHostname.Text.Trim();
        public string RemoteUsername => textUsername.Text.Trim();
        public string RemotePassword => textPassword.Text.Trim();
        public string RemoteFolder => textRemoteFolder.Text.Trim();

        #endregion
    }
}
