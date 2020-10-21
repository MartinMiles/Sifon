using System.Diagnostics;
using System.Drawing;
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

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var website = new ProcessStartInfo("https://t.me/SitecoreTelegram");
            Process.Start(website);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            var p = new Pen(Color.Gray, 1);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 10, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
        }
    }
}
