using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Sifon.Shared.UserControls.ThreadSafeFilePicker;

namespace Sifon.Shared.Forms.LocalFilePickerDialog
{
    public partial class LocalFilePicker : Form
    {
        #region Passed parameters

        public string Filters { private get; set; } = "All files (*.*)"; // extensions to show
        public string Caption { private get; set; } = "DIALOG CAPTION";
        public string Label { private get; set; } = "LABEL ABOVE THE TEXTBOX";
        public string Button { private get; set; } = "BUTTON";

        public Func<string, string> Validation { private get; set; }

        public string FilePath { get; private set; } // output value

        #endregion

        public LocalFilePicker()
        {
            InitializeComponent();
        }

        

        private void Form_Load(object sender, EventArgs e)
        {
            Text = Caption;
            textInstanaceToBackup.Text = Label;
            buttonInstall.Text = Button;
        }

        private void buttonBackupLocation_Click(object sender, EventArgs e)
        {
            var dlg = new ThreadSafeOpenPicker
            {
                Filter = Filters, DefaultExt = "zip", StartupLocation = new Point(Location.X, Location.Y)
            };

            var res = dlg.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            pathTextbox.Text = dlg.FilePath.Trim();
            FilePath = dlg.FilePath.Trim();

            if (Validation != null)
            {
                string validationResult = Validation(pathTextbox.Text);

                buttonInstall.Enabled = string.IsNullOrWhiteSpace(validationResult);

                if (!buttonInstall.Enabled)
                {
                    MessageBox.Show(validationResult, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    buttonInstall.Focus();
                }
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
