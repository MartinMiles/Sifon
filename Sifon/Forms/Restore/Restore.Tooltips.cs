using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Restore
{
    partial class Restore
    {
        protected override void SetTooltips()
        {
            //TODO: add tooltips for grid and new elements

            new ToolTip().SetToolTip(textSourceFolder, Tooltips.Restore.SourceFolder);
            //new ToolTip().SetToolTip(textWebfolderArchiveFile, Tooltips.Restore.Webfolder);
            //new ToolTip().SetToolTip(textDestinationFolder, Tooltips.Restore.DestinationFolder);
            new ToolTip().SetToolTip(listDatabases, Tooltips.Restore.ListDatabases);
            new ToolTip().SetToolTip(buttonRestore, Tooltips.Restore.RestoreButton);
        }
    }
}
