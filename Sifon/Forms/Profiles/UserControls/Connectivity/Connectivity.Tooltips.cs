using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Connectivity
{
    partial class Connectivity
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboSqlServers, Tooltips.Profiles.SqlServersDropdown);
            new ToolTip().SetToolTip(buttonSqlConnection, Tooltips.Profiles.SqlConnectionButton);
            new ToolTip().SetToolTip(comboSolr, Tooltips.Profiles.SolrDropdown);
        }
    }
}
