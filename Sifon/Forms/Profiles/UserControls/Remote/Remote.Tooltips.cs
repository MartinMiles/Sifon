using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Remote
{
    partial class Remote
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(checkBoxRemote, Tooltips.Profiles.Remote.EnableCheckbox);

            new ToolTip().SetToolTip(labelHostname, Tooltips.Profiles.Remote.Hostname);
            new ToolTip().SetToolTip(textHostname, Tooltips.Profiles.Remote.Hostname);

            new ToolTip().SetToolTip(labelUsername, Tooltips.Profiles.Remote.Username);
            new ToolTip().SetToolTip(textUsername, Tooltips.Profiles.Remote.Username);

            new ToolTip().SetToolTip(labelPassword, Tooltips.Profiles.Remote.Password);
            new ToolTip().SetToolTip(textPassword, Tooltips.Profiles.Remote.Password);

            new ToolTip().SetToolTip(labelRemoteFolder, Tooltips.Profiles.Remote.RemoteFolder);
            new ToolTip().SetToolTip(textRemoteFolder, Tooltips.Profiles.Remote.RemoteFolder);
        }
    }
}
