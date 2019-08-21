using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    partial class Profile
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboProfiles, Tooltips.Profiles.ProfilesDropdown);
            new ToolTip().SetToolTip(textProfileName, Tooltips.Profiles.ProfileName);
            new ToolTip().SetToolTip(textPrefix, Tooltips.Profiles.Prefix);
            new ToolTip().SetToolTip(buttonRename, Tooltips.Profiles.RenameButton);
            new ToolTip().SetToolTip(buttonDelete, Tooltips.Profiles.DeleteButton);
        }
    }
}
