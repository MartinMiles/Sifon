using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.SqlSettings
{
    partial class SqlSettings
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(comboBoxServers, Tooltips.SqlSettings.ServersDropdown);
            new ToolTip().SetToolTip(buttonDelete, Tooltips.SqlSettings.DeleteButton);

            new ToolTip().SetToolTip(textName, Tooltips.SqlSettings.TextName);
            new ToolTip().SetToolTip(textInstance, Tooltips.SqlSettings.TextInstance);
            new ToolTip().SetToolTip(textUsername, Tooltips.SqlSettings.TextUsername);
            new ToolTip().SetToolTip(textPassword, Tooltips.SqlSettings.TextPassword);

            new ToolTip().SetToolTip(buttonTest, Tooltips.SqlSettings.TestButton);
            new ToolTip().SetToolTip(buttonSave, Tooltips.SqlSettings.SaveButton);
        }
    }
}
