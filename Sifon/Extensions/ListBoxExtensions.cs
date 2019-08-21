using System.Collections.Generic;
using System.Windows.Forms;

namespace Sifon.Extensions
{
    internal static class ListBoxExtensions
    {
        public static bool IsEmpty(this ListBox listBox)
        {
            return listBox.Items.Count == 0;
        }

        internal static void SelectAll(this ListBox listbox)
        {
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                listbox.SetSelected(i, true);
            }
        }

        internal static string[] Selected(this ListBox listbox)
        {
            var selectedDatabases = new List<string>();

            foreach (var item in listbox.SelectedItems)
            {
                selectedDatabases.Add(item.ToString());
            }

            return selectedDatabases.ToArray();
        }
    }
}
