using System.Windows.Forms;

namespace Sifon.Forms.Other
{
    public partial class FirstTimeRun : Form
    {
        public FirstTimeRun()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var about = new Prerequsites.Prerequsites { StartPosition = FormStartPosition.CenterParent };
            if (about.ShowDialog() == DialogResult.OK)
            {
                about.Dispose();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
