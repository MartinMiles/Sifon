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
        private bool initialRemotingState;

        #region Public events
        public event EventHandler<EventArgs<bool>> ToggleLastTabs = delegate { };       // TODO: remove later
        public event EventHandler<EventArgs<string>> RemoteInitialized = delegate { };
        public event EventHandler<EventArgs<IRemoteSettings>> TestRemote = delegate { };

        #endregion

        #region Expose fields properties

        public bool RemotingEnabled
        {
            get => checkBoxRemote.Checked;
            set => checkBoxRemote.Checked = value;
        }

        public string RemoteHost
        {
            get => textHostname.Text.Trim();
            set => textHostname.Text = value;
        }

        public string RemoteUsername
        {
            get => textUsername.Text.Trim();
            set => textUsername.Text = value;
        }

        public string RemotePassword
        {
            get => textPassword.Text.Trim();
            set => textPassword.Text = value;
        }

        public string RemoteFolder
        {
            get => textRemoteFolder.Text.Trim();
            set => textRemoteFolder.Text = value;
        }

        #endregion

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

            // this is commented out after last tabs are removed until first two have been submitted
            //ToggleLastTabs(this, new EventArgs<bool>(remote == initialRemotingState));
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
    }
}
