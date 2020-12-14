using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Solr
{
    partial class InstallSolr
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(textFolder, Tooltips.InstallSolr.Folder);
            new ToolTip().SetToolTip(textFolderSuffix, Tooltips.InstallSolr.FolderSuffix);
            new ToolTip().SetToolTip(buttonLocation, Tooltips.InstallSolr.Location);
            new ToolTip().SetToolTip(comboVersion, Tooltips.InstallSolr.Version);
            new ToolTip().SetToolTip(textPort, Tooltips.InstallSolr.Port);
            new ToolTip().SetToolTip(buttonInstall, Tooltips.InstallSolr.InstallButton);
            new ToolTip().SetToolTip(dataGrid, Tooltips.InstallSolr.Grid);
        }
    }
}
