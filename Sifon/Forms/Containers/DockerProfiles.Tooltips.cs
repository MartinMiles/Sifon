using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Containers
{
    partial class DockerProfiles
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboProfiles, Tooltips.DockerProfiles.Profiles);

            new ToolTip().SetToolTip(textProfileName, Tooltips.DockerProfiles.ProfileName);
            new ToolTip().SetToolTip(textRepositoryUrl, Tooltips.DockerProfiles.RepositoryUrl);
            new ToolTip().SetToolTip(textRepositoryFolder, Tooltips.DockerProfiles.RepositoryFolder);
            new ToolTip().SetToolTip(textAdminPassword, Tooltips.DockerProfiles.AdminPassword);
            new ToolTip().SetToolTip(textSaPassword, Tooltips.DockerProfiles.SaPassword);
            new ToolTip().SetToolTip(textInitialize, Tooltips.DockerProfiles.InitializeScript);

            new ToolTip().SetToolTip(linkRevealAdmin, Tooltips.DockerProfiles.RevealAdmin);
            new ToolTip().SetToolTip(linkRevealSa, Tooltips.DockerProfiles.RevealSa);
            new ToolTip().SetToolTip(linkDelete, Tooltips.DockerProfiles.Delete);

            new ToolTip().SetToolTip(buttonAddRename, Tooltips.DockerProfiles.AddRename);
        }
    }
}
