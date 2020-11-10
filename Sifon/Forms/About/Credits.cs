using System;
using System.Windows.Forms;
using Sifon.Forms.Base;

namespace Sifon.Forms.About
{
    internal partial class Credits : BaseForm
    {
        internal Credits()
        {
            InitializeComponent();
        }

        private void Credits_Load(object sender, EventArgs e)
        {
            buttonOK.Select();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://www.linkedin.com/in/jflarente");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://github.com/jeanfrancoislarente");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://github.com/michaellwest");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://www.linkedin.com/in/michaellwest/");
        }
    }
}
