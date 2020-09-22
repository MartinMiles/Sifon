using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Forms.Base;
using Sifon.Shared.Events;
using Sifon.Shared.Statics;

namespace Sifon.Forms.PortalCredentials
{
    public partial class PortalCredentials : BaseForm, IPortalCredentialsView, ISettingRecord
    {
        public event EventHandler<EventArgs> FormLoad = delegate { };
        public event EventHandler<EventArgs<ISettingRecord>> TestClicked = delegate { };
        public event EventHandler<EventArgs<ISettingRecord>> ValuesChanged = delegate { };

        public PortalCredentials()
        {
            InitializeComponent();
            new PortalCredentialsPresenter(this);
        }

        private void PortalCredentials_Load(object sender, EventArgs e)
        {
            RevealPasswordWithinTextbox(textPassword, linkReveal, false);
            FormLoad(this, e);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            ValuesChanged(this, new EventArgs<ISettingRecord>(this));
        }

        private void linkReveal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPasswordWithinTextbox(textPassword, linkReveal);
        }

        private void TestCredentials_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            TestClicked(this, new EventArgs<ISettingRecord>(this));
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

        public string PortalUsername => textUsername.Text.Trim();

        public string PortalPassword
        {
            get => textPassword.Text.Trim();
            set => textPassword.Text = value;
        }

        #endregion
    }
}
