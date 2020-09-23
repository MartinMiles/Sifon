using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    public partial class Website
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(labelWebsites, Tooltips.Profiles.WebsitesDropdown);
            new ToolTip().SetToolTip(comboWebsites, Tooltips.Profiles.WebsitesDropdown);

            new ToolTip().SetToolTip(labelWebroot, Tooltips.Profiles.TextWebroot);
            new ToolTip().SetToolTip(textWebroot, Tooltips.Profiles.TextWebroot);

            new ToolTip().SetToolTip(labelGrid, Tooltips.Profiles.ListBindings);
            new ToolTip().SetToolTip(dataGrid, Tooltips.Profiles.ListBindings);
        }
    }
}
