using System.Windows.Forms;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    internal class SelectedWebsiteChangedArgs
    {
        internal string Value { get; set; }
        internal string[] Sites { get; set; }
        internal TextBox TextBox { get; set; }
    }
}
