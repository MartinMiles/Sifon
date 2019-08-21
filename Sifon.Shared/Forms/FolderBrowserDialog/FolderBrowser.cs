using System;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;

namespace Sifon.Shared.Forms.FolderBrowserDialog
{
    public partial class FolderBrowser : Form
    {
        public string SelectedPath { get; private set; }

        public FolderBrowser(IProfile profile, bool allowCreateNewFolder = false)
        {
            InitializeComponent();

            folderTreeView.CancelSent += CancelSent;
            folderTreeView.EditFinished += EditFinished;

            folderTreeView.ShowFiles = false;
            folderTreeView.Profile = profile;

            buttonNewFolder.Visible = allowCreateNewFolder;
        }

        private void buttonNewFolder_Click(object sender, EventArgs e)
        {
            buttonNewFolder.Enabled = false;
            folderTreeView.MakeNewFolder();
        }

        private void EditFinished(object sender, EventArgs e)
        {
            buttonNewFolder.Enabled = true;
        }

        private void CancelSent(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectedPath = folderTreeView.SelectedPath;
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void CloseDialog()
        {
            DialogResult = DialogResult.Cancel;
            SelectedPath = null;
        }
    }
}
