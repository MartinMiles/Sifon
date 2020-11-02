using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Prerequsites
{
    partial class Prerequsites
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(checkChocolatey, Tooltips.Prerequsites.Chocolatey);
            new ToolTip().SetToolTip(checkGit, Tooltips.Prerequsites.Git);
            new ToolTip().SetToolTip(checkRemoting, Tooltips.Prerequsites.Remoting);
            new ToolTip().SetToolTip(checkSif, Tooltips.Prerequsites.SIF);
            new ToolTip().SetToolTip(buttonInstall, Tooltips.Prerequsites.InstallButton);
            new ToolTip().SetToolTip(buttonClose, Tooltips.Prerequsites.CloseButton);
        }
    }
}
