using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Restore
{
    partial class Restore
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(textSourceFolder, Tooltips.Restore.SourceFolder);
            new ToolTip().SetToolTip(dataGrid, Tooltips.Restore.ArchivesGrid);
            new ToolTip().SetToolTip(checkFiles, Tooltips.Restore.Website);
            new ToolTip().SetToolTip(checkXconnect, Tooltips.Restore.XConnect);
            new ToolTip().SetToolTip(checkIdentity, Tooltips.Restore.Identity);
            new ToolTip().SetToolTip(checkHorizon, Tooltips.Restore.Horizon);
            new ToolTip().SetToolTip(checkPublishing, Tooltips.Restore.Publishing);
            new ToolTip().SetToolTip(checkCommerce, Tooltips.Restore.Commerce);
            new ToolTip().SetToolTip(listDatabases, Tooltips.Restore.ListDatabases);
            new ToolTip().SetToolTip(buttonRestore, Tooltips.Restore.RestoreButton);
        }
    }
}
