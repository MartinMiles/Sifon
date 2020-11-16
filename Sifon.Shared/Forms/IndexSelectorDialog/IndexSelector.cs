using System;
using System.Collections.Generic;
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
            var indexFinder = Create.WithProfile<IIndexFinder>(_profile, this);
            var indexes = await indexFinder.FindAll();

            buttonSelect.Select();
            PopulateDropdown(indexes);
        }

        // This method is to be called from a Sifon PowerShell metadata started with tripple-hash character, as described below:
        // ### $SelectedFile = new Sifon.Shared.Forms.LocalFilePickerDialog.LocalFilePicker::GetFile("Caption","Label","Archives|*.zip","Button")
        public string GetIndex(IProfile profile)
        {
            if (profile == null) return null;
            _profile = profile;

            //TODO: from $Profile either local or remote
            //_items = new List<string> {"sitecore_core_index", "sitecore_master_index", "sitecore_web_index"};

            StartPosition = FormStartPosition.CenterParent;

            if (ShowDialog() == DialogResult.OK)
            {
                return IndexName;
            }

            return null;
        }

        public void PopulateDropdown(IEnumerable<string> items)
        {
            comboVersions.Items.Clear();

            //comboVersions.ValueMember = "url";
            //comboVersions.DisplayMember = "name";
            comboVersions.DataSource = items;

            //comboVersions.Items.Add()

            if (comboVersions.Items.Count > 0)
            {
                comboVersions.SelectedIndex = 0;
            }

            buttonSelect.Enabled = comboVersions.Items.Count > 0;
        }

        public string IndexName => comboVersions.SelectedItem as string;

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
