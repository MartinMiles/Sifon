using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal partial class Website
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(labelWebsiteCM, Tooltips.Profiles.WebsitesDropdown);
            new ToolTip().SetToolTip(comboWebsites, Tooltips.Profiles.WebsitesDropdown);

            new ToolTip().SetToolTip(labelWebrootCM, Tooltips.Profiles.TextWebroot);
            new ToolTip().SetToolTip(textWebroot, Tooltips.Profiles.TextWebroot);

            new ToolTip().SetToolTip(labelGrid, Tooltips.Profiles.ListBindings);
            new ToolTip().SetToolTip(dataGrid, Tooltips.Profiles.ListBindings);
        }
    }
}
