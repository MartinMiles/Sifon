using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sifon.Shared.UserControls;
using Sifon.UserControls;

namespace Sifon.Extensions
{
    internal static class DataGridViewExtensions
    {
        public static void ShowDataGrid(this DataGridView dataGrid, IEnumerable<KeyValuePair<string, string>> hostnames, string[] columnNames)
        {
            dataGrid.DataBindingComplete += (sender, args) => { ((DataGridView)sender).ClearSelection(); };
            dataGrid.BackgroundColor = Color.White;
            dataGrid.RowHeadersVisible = false;
            dataGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGrid.DataSource = hostnames;
            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.Columns[0].HeaderText = columnNames[0];
                dataGrid.Columns[1].HeaderText = columnNames[1];
                dataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public static void SetButtonColumnEnable(this DataGridView dataGrid, int columnIndex, bool enabled)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                ((DataGridViewDisableButtonCell)row.Cells[columnIndex]).Enabled = enabled;
            }
            dataGrid.Refresh();
        }
    }
}
