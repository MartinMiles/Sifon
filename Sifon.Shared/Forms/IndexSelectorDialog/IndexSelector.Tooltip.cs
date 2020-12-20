using System.Windows.Forms;

namespace Sifon.Shared.Forms.IndexSelectorDialog
{
    partial class IndexSelector
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboVersions, "Please select a specific index to process or them all");
            new ToolTip().SetToolTip(buttonSelect, "Process with the selected option");
        }
    }
}
