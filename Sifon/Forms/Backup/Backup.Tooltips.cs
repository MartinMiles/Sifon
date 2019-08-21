using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Backup
{
    partial class Backup
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(textDestinationFolderToBackup, Tooltips.Backup.DestinationFolder);
            new ToolTip().SetToolTip(comboInstances, Tooltips.Backup.SitecoreInstancesDropdown);
            new ToolTip().SetToolTip(dataGrid, Tooltips.Backup.Bindings);
            new ToolTip().SetToolTip(listDatabases, Tooltips.Backup.ListDatabases);
            new ToolTip().SetToolTip(buttonBackup, Tooltips.Backup.ButtonBackup);
        }
    }
}
