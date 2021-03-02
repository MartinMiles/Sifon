using System.Windows.Forms;

namespace Sifon.Forms.Install
{
    partial class Install
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(prefixText, "This is you instance prefix. It will also prefix databases and Solr cores");
            new ToolTip().SetToolTip(sitecoreSiteText, "The hostname to be used for Sitecore site");
        }
    }
}
