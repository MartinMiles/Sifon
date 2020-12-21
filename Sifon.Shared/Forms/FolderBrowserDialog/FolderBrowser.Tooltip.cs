using System.Windows.Forms;

namespace Sifon.Shared.Forms.FolderBrowserDialog
{
    partial class FolderBrowser
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(buttonNewFolder, "Create a new folder at the selected profile destination");
            new ToolTip().SetToolTip(buttonSelect, "Precess with the selected folder");
            new ToolTip().SetToolTip(buttonCancel, "Cancel choosing a folder");
        }
    }
}
