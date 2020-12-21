using System.Windows.Forms;

namespace Sifon.Shared.Forms.DownloaderDialog
{
    partial class Downloader
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(textDestinationFolder, "Please enter the download destination path");
            new ToolTip().SetToolTip(buttonLocation, "Browse");
            new ToolTip().SetToolTip(comboVersion, "Please select version of the platform to download resources for");
            new ToolTip().SetToolTip(linkAll, "Check or uncheck all the items in one go");
            new ToolTip().SetToolTip(buttonDownload, "Process downloading items for the selected categories");
        }
    }
}
