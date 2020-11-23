using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.SettingsForm
{
    partial class SettingsForm
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(checkBoxCrashLog, Tooltips.SettingsForm.CrashLogCheckbox);
            new ToolTip().SetToolTip(textRepository, Tooltips.SettingsForm.PluginsRepository);
            new ToolTip().SetToolTip(buttonSave, Tooltips.SettingsForm.DoneButton);
        }
    }
}
