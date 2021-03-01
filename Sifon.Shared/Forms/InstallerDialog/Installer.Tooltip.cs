using System.Windows.Forms;

namespace Sifon.Shared.Forms.InstallerDialog
{
    partial class Installer
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(prefixText, "This is you instance prefix. It will also prefix databases and Solr cores");
            new ToolTip().SetToolTip(sitecoreSiteText, "The hostname to be used for Sitecore site");
        }
    }
}
