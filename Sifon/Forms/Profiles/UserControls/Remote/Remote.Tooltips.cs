using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    partial class Remote
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(checkBoxRemote, Tooltips.Profiles.Remote.EnableCheckbox);
            new ToolTip().SetToolTip(textHostname, Tooltips.Profiles.Remote.Hostname);
            new ToolTip().SetToolTip(textUsername, Tooltips.Profiles.Remote.Username);
            new ToolTip().SetToolTip(textPassword, Tooltips.Profiles.Remote.Password);
        }
    }
}
