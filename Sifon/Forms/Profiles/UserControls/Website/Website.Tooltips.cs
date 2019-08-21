using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    public partial class Website
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboWebsites, Tooltips.Profiles.WebsitesDropdown);
            new ToolTip().SetToolTip(textWebroot, Tooltips.Profiles.TextWebroot);
            new ToolTip().SetToolTip(dataGrid, Tooltips.Profiles.ListBindings);
        }
    }
}
