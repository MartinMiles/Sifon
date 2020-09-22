using System;
using System.Windows.Forms;
using Sifon.Forms.Base;
using Sifon.Shared.Statics;

namespace Sifon.Forms.PortalCredentials
{
    public partial class PortalCredentials : BaseForm, IPortalCredentialsView
    {
        public PortalCredentials()
        {
            InitializeComponent();
        }

        private void PortalCredentials_Load(object sender, EventArgs e)
        {
            RevealPasswordWithinTextbox(textPassword, linkReveal, false);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void linkReveal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RevealPasswordWithinTextbox(textPassword, linkReveal);
        }

        private void TestCredentials_Click(object sender, EventArgs e)
        {

        }
    }
}
