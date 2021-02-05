using System.Collections.Generic;
using System.Windows.Forms;
using Sifon.Abstractions.Messages;
using Sifon.Abstractions.Validation;
using Sifon.Shared.MessageBoxes;
using Sifon.Shared.Validation;

namespace Sifon.Shared.Forms.Base
{
    public class BaseDialog : Form
    {
        private readonly IDisplayMessage _displayMessage;
        private readonly IFormValidation _formValidation;

        public BaseDialog()
        {
            _displayMessage = new DisplayMessage();
            _formValidation = new FormValidation(_displayMessage);

            Load += (sender, args) => SetTooltips();
        }

        protected virtual void SetTooltips()
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected internal bool ShowYesNo(string caption, string message)
        {
            return _displayMessage.ShowYesNo(caption, message);
        }

        protected internal void ShowInfo(string caption, string message)
        {
            _displayMessage.ShowInfo(caption, message);
        }

        protected internal void ShowError(string caption, string message)
        {
            _displayMessage.ShowError(caption, message);
        }

        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            return _formValidation.ShowValidationError(errorList);
        }
    }
}
