using System.Windows.Forms;
using Sifon.Abstractions.Messages;
using Sifon.Shared.MessageBoxes;

namespace Sifon.Shared.Forms.Base
{
    public class BaseDialog : Form
    {
        private readonly IDisplayMessage _displayMessage;

        public BaseDialog()
        {
            _displayMessage = new DisplayMessage();
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
    }
}
