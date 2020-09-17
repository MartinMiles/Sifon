using System.Diagnostics;
using System.Windows.Forms;
using Sifon.Forms.Base;
using Sifon.Shared.Statics;

namespace Sifon.Forms.About
{
    internal partial class About : BaseForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var blog = new ProcessStartInfo("https://Blog.MartinMiles.net");
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

        private void About_Load(object sender, System.EventArgs e)
        {
            Text = $"{Settings.ProductVersion}";
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var website = new ProcessStartInfo("http://Sifon.uk");
            Process.Start(website);
        }
    }
}
