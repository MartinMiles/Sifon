using System;
using System.Drawing;
using System.Windows.Forms;
using Sifon.Shared.Forms.Base;
using Sifon.Shared.UserControls.ThreadSafeFilePicker;

namespace Sifon.Shared.Forms.LocalFilePickerDialog
{
    public partial class LocalFilePicker : BaseDialog
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

        // This method is to be called from a Sifon PowerShell metadata started with tripple-hash character, as described below:
        // ### $SelectedFile = new Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker::GetFile("Caption","Label","Archives|*.zip","Button")
        public string GetFile(string caption, string label, string filters,  string button)
        {
            Caption = caption;
            Label = label;
            Filters = filters;
            Button = button;

            StartPosition = FormStartPosition.CenterParent;

            Validation = s => "";

            if (ShowDialog() == DialogResult.OK)
            {
                return FilePath;
            }

            return null;
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

        #region Drag / drop 

        private void LocalFilePicker_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void LocalFilePicker_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                pathTextbox.Text = file;
            }
        }

        private void pathTextbox_DragEnter(object sender, DragEventArgs e)
        {
            LocalFilePicker_DragEnter(sender, e);
        }

        private void pathTextbox_DragDrop(object sender, DragEventArgs e)
        {
            LocalFilePicker_DragDrop(sender, e);
        }

        #endregion
    }
}