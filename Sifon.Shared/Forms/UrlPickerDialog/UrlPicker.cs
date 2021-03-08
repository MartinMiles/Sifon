using System;
using System.Windows.Forms;
using Sifon.Shared.Forms.Base;

namespace Sifon.Shared.Forms.UrlPickerDialog
{
    public partial class UrlPicker : BaseDialog
    {
        public UrlPicker()
        {
            InitializeComponent();
        }

        #region Passed parameters

        public string Caption { private get; set; } = "DIALOG CAPTION";
        public string Label { private get; set; } = "LABEL ABOVE THE TEXTBOX";
        public string Button { private get; set; } = "BUTTON";
        public bool OnlyHttp { private get; set; } = false;
        public bool OnlyFile { private get; set; } = false;

        public string Url => UrlTextbox.Text.Trim();

        #endregion

        private void UrlPicker_Load(object sender, EventArgs e)
        {
            Text = Caption;
            textLabel.Text = Label;
            buttonInstall.Text = Button;

            AddPassiveValidationHandlers();
        }

        // This method is to be called from a Sifon PowerShell metadata started with tripple-hash character, as described below:
        // ### $Url = new Sifon.Shared.Forms.UrlPickerDialog.UrlPicker::GetUrl("Package Downloader and Installer","Please select a package URL:","Download", $true, $true)
        public string GetUrl(string caption, string label, string button, bool httpOnly, bool fileOnly)
        {
            Caption = caption;
            Label = label;
            Button = button;
            OnlyHttp = httpOnly;
            OnlyFile = fileOnly;

            StartPosition = FormStartPosition.CenterParent;

            if (ShowDialog() == DialogResult.OK)
            {
                return Url;
            }

            return null;
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
