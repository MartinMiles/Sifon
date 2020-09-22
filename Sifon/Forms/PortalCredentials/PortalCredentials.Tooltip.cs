using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.PortalCredentials
{
    partial class PortalCredentials
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(textUsername, Tooltips.PortalCredentials.TextUsername);
            new ToolTip().SetToolTip(textPassword, Tooltips.PortalCredentials.TextPassword);
            new ToolTip().SetToolTip(linkReveal, Tooltips.PortalCredentials.RevealLink);
            new ToolTip().SetToolTip(buttonTest, Tooltips.PortalCredentials.TestButton);
            new ToolTip().SetToolTip(buttonSave, Tooltips.PortalCredentials.SaveButton);
        }
    }
}
