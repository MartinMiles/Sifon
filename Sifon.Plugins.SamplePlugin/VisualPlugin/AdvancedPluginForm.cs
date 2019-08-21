using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sifon.Plugins.Example.VisualPlugin.Code;

namespace Sifon.Plugins.Example.VisualPlugin
{
    public partial class AdvancedPluginForm : Form
    {
        public Dictionary<string, string> Parameters { get; set; }

        public AdvancedPluginForm()
        {
            InitializeComponent();
        }

        private void AdvancedPluginForm_Load(object sender, EventArgs e)
        {
            dataGrid.BackgroundColor = Color.White;
            dataGrid.RowHeadersVisible = false;
            dataGrid.DataSource = Parameters.ToBindingList();
        }

        private void done_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
