using System.Windows.Forms;

namespace Sifon.Shared.Forms.TextEditorDialog
{
    partial class TextEditor
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(buttonSave, "Save changes to the origin file");
        }
    }
}
