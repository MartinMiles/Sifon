using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sifon.Shared.Validation
{
    public class FormValidation : IFormValidation
    {
        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            var errorBuilder = new StringBuilder(Statics.Validation.General.ErrorsList);

            foreach (var error in errorList)
            {
                errorBuilder.AppendLine(error);
            }

            if (errorList.Any())
            {
                ShowError(Statics.Validation.General.MessageBoxCapture, errorBuilder.ToString());
            }

            return !errorList.Any();
        }

        public bool ShowYesNo(string caption, string message)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        public void ShowInfo(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
