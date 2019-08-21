using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Remover
{
    partial class Remover
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboInstances, Tooltips.Remove.InstancesDropdown);
            new ToolTip().SetToolTip(textWebfolder, Tooltips.Remove.Webfolder);
            new ToolTip().SetToolTip(textDatabasePrefix, Tooltips.Remove.DatabasePrefixFilter);
            new ToolTip().SetToolTip(listDatabases, Tooltips.Remove.ListDatabases);
            new ToolTip().SetToolTip(buttonRemove, Tooltips.Remove.RemoveButton);
        }
    }
}
