using System;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;

namespace Sifon.Forms.PortalCredentials
{
    internal partial class PortalCredentials : BaseForm, IPortalCredentialsView, IPortalCredentials
    {
        public event EventHandler<EventArgs<IPortalCredentials>> TestClicked = delegate { };
        public event EventHandler<EventArgs<IPortalCredentials>> ValuesChanged = delegate { };

        internal PortalCredentials()
        {
            InitializeComponent();
            new PortalCredentialsPresenter(this);
        }

        private void PortalCredentials_Load(object sender, EventArgs e)
        {
            RevealPasswordWithinTextbox(textPassword, linkReveal, false);
            Raise_FormLoaded();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            ValuesChanged(this, new EventArgs<IPortalCredentials>(this));
        }

        private void linkReveal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPasswordWithinTextbox(textPassword, linkReveal);
        }

        private void TestCredentials_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            TestClicked(this, new EventArgs<IPortalCredentials>(this));
        }

        public void SetTextboxValues(ISettingRecord entity)
        {
            textUsername.Text = entity.PortalUsername;
            textPassword.Text = entity.PortalPassword;
        }

        public void ToggleControls(bool enabled)
        {
            textUsername.Enabled = enabled;
            textPassword.Enabled = enabled;
            linkReveal.Enabled = enabled;
            buttonTest.Enabled = enabled;
            buttonSave.Enabled = enabled;
        }

        #region ISettingRecord implementation

        public string PortalUsername
        {
            get => textUsername.Text.Trim();
            set => textUsername.Text = value;
        }

        public string PortalPassword
        {
            get => textPassword.Text.Trim();
            set => textPassword.Text = value;
        }

        #endregion
    }
}
