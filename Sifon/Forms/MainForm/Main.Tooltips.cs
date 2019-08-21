using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.MainForm
{
    partial class Main
    {
        protected void SetTooltips()
        {
            new ToolTip().SetToolTip(comboProfiles, Tooltips.Main.ProfilesDropdown);
            new ToolTip().SetToolTip(buttonStopScript, Tooltips.Main.StopButton);
            new ToolTip().SetToolTip(progressBar, Tooltips.Main.ProgressBar);
            new ToolTip().SetToolTip(listBoxOutput, Tooltips.Main.Output);
        }
    }
}
