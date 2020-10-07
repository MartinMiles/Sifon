using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Code.Statics;

namespace Sifon.Forms.Restore
{
    partial class Restore
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
        }

        public bool RestoreButtonCriteria => 
            !textSourceFolder.IsEmpty() && checkFiles.Checked || checkDatabases.Checked && !listDatabases.IsEmpty();

        public void SetRestoreButton(bool? enabled)
        {
            if (buttonRestore.Text != Settings.Buttons.Loading)
            {
                buttonRestore.Enabled = enabled ?? RestoreButtonCriteria;
            }

            Cursor = buttonRestore.Text != Settings.Buttons.Loading ? Cursors.Arrow : Cursors.WaitCursor;
        }

        public void SetRestoreButtonTitle(string text)
        {
            buttonRestore.Text = text;
        }

        #endregion
    }
}
