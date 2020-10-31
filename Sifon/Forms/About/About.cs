using System.Windows.Forms;
using Sifon.Forms.Base;
using Sifon.Code.Statics;

namespace Sifon.Forms.About
{
    internal partial class About : BaseForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, System.EventArgs e)
        {
            Text = $"{Settings.ProductVersion}";

            buttonOK.Select();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://Blog.MartinMiles.net");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("mailto:Sitecore.Professional@gmail.com");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://twitter.com/SitecoreMartin");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("http://Sifon.uk");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://t.me/SitecoreTelegram");
        }

        private void buttonCredits_Click(object sender, System.EventArgs e)
        {
            var credits = new Credits {StartPosition = FormStartPosition.CenterParent};
            if (credits.ShowDialog() == DialogResult.OK)
            {
                credits.Dispose();
            }
        }
    }
}
