using System.Windows.Forms;
using Sifon.Statics;

namespace Sifon.Forms.Profiles.UserControls.Parameters
{
    public partial class Parameters
    {
        public override void SetTooltips()
        {
            new ToolTip().SetToolTip(linkLabelSampleDownload, Tooltips.Profiles.Parameters.DownloadLink);
            new ToolTip().SetToolTip(buttonAddPair, Tooltips.Profiles.Parameters.AddPair);
        }
    }
}
