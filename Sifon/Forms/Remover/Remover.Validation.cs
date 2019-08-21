using System;
using Sifon.Extensions;

namespace Sifon.Forms.Remover
{
    partial class Remover
    {
        #region Passive validation on text changed and character entered

        protected override void AddPassiveValidationHandlers()
        {
            textWebfolder.TextChanged += SourceFolderHasChanged;
            textXConnectFolder.TextChanged += SourceFolderHasChanged;
            textIdsFolder.TextChanged += SourceFolderHasChanged;
        }

        private void SourceFolderHasChanged(object sender, EventArgs e)
        {
            EnableDisableMainButton();
        }

        private void EnableDisableMainButton()
        {
            buttonRemove.Enabled = !textWebfolder.IsEmpty() && checkFiles.Checked 
                                   || !textXConnectFolder.IsEmpty() && checkXconnect.Checked
                                   || !textIdsFolder.IsEmpty() && checkIDS.Checked
                                   || checkDatabases.Checked && !listDatabases.IsEmpty();
        }
        
        #endregion
    }
}
