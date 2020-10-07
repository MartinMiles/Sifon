using System;
using System.Windows.Forms;
using Sifon.Code.Extensions;
using Sifon.Code.Statics;

namespace Sifon.Forms.Backup
{
    partial class Backup
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
            textDestinationFolderToBackup.TextChanged += DestinationHasChanged;
        }

        private void DestinationHasChanged(object sender, EventArgs e)
        {
            ToggleControls(FolderNotEmpty);
            EnableDisableMainButton(true);
        }

        private bool FolderNotEmpty => textDestinationFolderToBackup.Text.NotEmpty();

        public void EnableDisableMainButton(bool? enabled = null)
        {
            if (enabled == null)
            {
                if (FolderNotEmpty)
                {
                   buttonBackup.Enabled =
                        textDestinationFolderToBackup.Text.Length > 0
                        && (checkFiles.Checked || checkDatabases.Checked && listDatabases.SelectedItems.Count > 0);
                }
            }
            else
            {
                buttonBackup.Enabled = (bool) enabled && FolderNotEmpty;
                buttonBackup.Text = (bool)enabled ? Settings.Buttons.Backup : Settings.Buttons.Loading;
                buttonBackup.Text = (bool)enabled ? Settings.Buttons.Backup : Settings.Buttons.Loading;
                Cursor = (bool)enabled ? Cursors.Arrow : Cursors.WaitCursor;
            }
        }

        #endregion
    }
}
