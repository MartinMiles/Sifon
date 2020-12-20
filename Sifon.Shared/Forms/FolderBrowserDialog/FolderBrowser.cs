using System;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Forms.Base;

namespace Sifon.Shared.Forms.FolderBrowserDialog
{
    public partial class FolderBrowser : BaseDialog
    {
        public string SelectedPath { get; private set; }

        // empty constructor needed for meta-language execution
        public FolderBrowser()
        {
            InitializeComponent();
            folderTreeView.ShowFiles = false;
        }

        public FolderBrowser(IProfile profile, bool allowCreateNewFolder = false) : this()
        {
            Init(profile, allowCreateNewFolder);
        }

        private async void Init(IProfile profile, bool allowCreateNewFolder)
        {
            await folderTreeView.InitAndShow(profile);
            buttonNewFolder.Visible = allowCreateNewFolder;
            Text = $"{Statics.Controls.FolderBrowser.Caption} - {profile.WindowCaptionSuffix}";
        }

        private void buttonNewFolder_Click(object sender, EventArgs e)
        {
            buttonNewFolder.Enabled = false;
            folderTreeView.MakeNewFolder();
        }

        public string GetFolder(IProfile profile, bool allowCreateNewFolder = false)
        {
            Init(profile, allowCreateNewFolder);

            StartPosition = FormStartPosition.CenterParent;
            ShowDialog();
            return SelectedPath;
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
