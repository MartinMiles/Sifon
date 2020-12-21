using System.Windows.Forms;

namespace Sifon.Shared.Forms.SitecoreVersionSelectorDialog
{
    partial class SitecoreVersionSelector
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboVersions, "Select version of Sitecore platform you would like to process with");
            new ToolTip().SetToolTip(buttonSelect, "Process with the selection");
        }
    }
}
