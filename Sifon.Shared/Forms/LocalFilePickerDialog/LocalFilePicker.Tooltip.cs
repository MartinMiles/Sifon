using System.Windows.Forms;

namespace Sifon.Shared.Forms.LocalFilePickerDialog
{
    partial class LocalFilePicker
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(pathTextbox, "Please enter the requested path");
            new ToolTip().SetToolTip(buttonLocation, "Browse");
            new ToolTip().SetToolTip(buttonInstall, "Process with the selected path");
        }
    }
}
