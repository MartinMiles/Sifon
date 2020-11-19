using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Helpers;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Factories;

namespace Sifon.Shared.Forms.IndexSelectorDialog
{
    public partial class IndexSelector : Form
    {
        private IProfile _profile;

        public IndexSelector()
        {
            InitializeComponent();
        }

        private async void IndexSelector_Load(object sender, EventArgs e)
        {
            ToggleControls(false);
            var indexFinder = Create.WithProfile<IIndexFinder>(_profile, this);
            var indexes = await indexFinder.FindAll();

            buttonSelect.Select();
            PopulateDropdown(indexes);
            ToggleControls(true);

            if (comboVersions.Items.Count == 0)
            {
                comboVersions.Items.Add(NOTHING);
                comboVersions.SelectedIndex = 0;
                comboVersions.Enabled = false;
            }
        }

        private void ToggleControls(bool enabled)
        {
            buttonSelect.Enabled = enabled && comboVersions.Items.Count > 0;
            comboVersions.Enabled = enabled;
            Cursor = enabled ? Cursors.Arrow : Cursors.WaitCursor;
        }

        // This method is to be called from a Sifon PowerShell metadata started with tripple-hash character, as described below:
        // ### $SelectedFile = new Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker::GetFile("Caption","Label","Archives|*.zip","Button")
        public string[] GetIndex(IProfile profile)
        {
            if (profile == null) return null;
            _profile = profile;

            StartPosition = FormStartPosition.CenterParent;

            if (ShowDialog() == DialogResult.OK)
            {
                var selected = comboVersions.SelectedItem as string;

                comboVersions.Items.RemoveAt(0);
                
                return selected != ALL 
                    ? new [] { selected } 
                    : comboVersions.Items.Cast<string>().Select(item => item.ToString()).ToArray();
            }

            return null;
        }

        const string ALL = "-= process all the indexes =-";
        const string NOTHING = "-= nothing found, could be a connection error =-";

        public void PopulateDropdown(IEnumerable<string> items)
        {
            comboVersions.Items.Clear();

            foreach (var item in items)
            {
                comboVersions.Items.Add(item);
            }
            
            if (comboVersions.Items.Count > 0)
            {
                comboVersions.Items.Insert(0, ALL);
                comboVersions.SelectedIndex = 0;
            }

            buttonSelect.Enabled = comboVersions.Items.Count > 0;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
