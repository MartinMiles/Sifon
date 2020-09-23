using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Connectivity
{
    partial class Connectivity
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(labelSqlServers, Tooltips.Profiles.SqlServersDropdown);
            new ToolTip().SetToolTip(comboSqlServers, Tooltips.Profiles.SqlServersDropdown);

            new ToolTip().SetToolTip(labelSolrInstances, Tooltips.Profiles.SolrDropdown);
            new ToolTip().SetToolTip(comboSolrInstances, Tooltips.Profiles.SolrDropdown);

            new ToolTip().SetToolTip(labelSolr, Tooltips.Profiles.SolrText);
            new ToolTip().SetToolTip(textSolr, Tooltips.Profiles.SolrText);

            new ToolTip().SetToolTip(buttonSqlConnection, Tooltips.Profiles.SqlConnectionButton);
        }
    }
}
