using System.Windows.Forms;

namespace Sifon.Shared.Forms.PackageVersionSelectorDialog
{
    partial class PackageVersionSelector
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboVersions, "Select version of product you would like to process with");
            new ToolTip().SetToolTip(comboVersions, "Process with the selection");
        }
    }
}
