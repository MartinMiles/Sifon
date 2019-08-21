using System.Diagnostics;
using System.Windows.Forms;
using Sifon.Forms.Base;

namespace Sifon.Forms.About
{
    internal partial class About : BaseForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var blog = new ProcessStartInfo("http://Blog.MartinMiles.net");
            Process.Start(blog);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var email = new ProcessStartInfo("mailto:Sitecore.Professional@gmail.com");
            Process.Start(email);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var twitter = new ProcessStartInfo("https://twitter.com/SitecoreMartin");
            Process.Start(twitter);
        }
    }
}
