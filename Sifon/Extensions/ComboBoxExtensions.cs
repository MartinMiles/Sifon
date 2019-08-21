using System.Windows.Forms;

namespace Sifon.Extensions
{
    internal static class ComboBoxExtensions
    {
        public static bool IsEmpty(this ComboBox comboBox)
        {
            return comboBox.Items.Count == 0;
        }
    }
}
