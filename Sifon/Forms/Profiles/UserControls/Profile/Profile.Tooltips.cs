using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Profile
{
    partial class Profile
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(labelCombo, Tooltips.Profiles.ProfilesDropdown);
            new ToolTip().SetToolTip(comboProfiles, Tooltips.Profiles.ProfilesDropdown);

            new ToolTip().SetToolTip(labelProfileName, Tooltips.Profiles.ProfileName);
            new ToolTip().SetToolTip(textProfileName, Tooltips.Profiles.ProfileName);

            new ToolTip().SetToolTip(labelPrefix, Tooltips.Profiles.Prefix);
            new ToolTip().SetToolTip(textPrefix, Tooltips.Profiles.Prefix);

            new ToolTip().SetToolTip(labelAdminUsername, Tooltips.Profiles.AdminUsername);
            new ToolTip().SetToolTip(textAdminUsername, Tooltips.Profiles.AdminUsername);

            new ToolTip().SetToolTip(labelAdminPassword, Tooltips.Profiles.AdminPassword);
            new ToolTip().SetToolTip(textAdminPassword, Tooltips.Profiles.AdminPassword);

            new ToolTip().SetToolTip(buttonRename, Tooltips.Profiles.RenameButton);
            new ToolTip().SetToolTip(linkDelete, Tooltips.Profiles.DeleteButton);
        }
    }
}
