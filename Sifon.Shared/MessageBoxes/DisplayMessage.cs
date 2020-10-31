using System.Windows.Forms;
using Sifon.Abstractions.Messages;

namespace Sifon.Shared.MessageBoxes
{
    public class DisplayMessage : IDisplayMessage
    {
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
