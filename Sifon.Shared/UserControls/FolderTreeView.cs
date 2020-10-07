using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sifon.Abstractions.Profiles;
using Sifon.Abstractions.Validation;
using Sifon.Code.Events;
using Sifon.Code.Filesystem;
using Sifon.Code.Validation;

namespace Sifon.Shared.UserControls
{
    public partial class FolderTreeView : UserControl, IFormValidation
    {
        public event EventHandler<EventArgs<string>> DoubleClicked = delegate { };
        public event EventHandler<EventArgs> EditFinished = delegate { };
        public event EventHandler<EventArgs> CancelSent = delegate { };

        private readonly FormValidation _formValidation;
        private IFilesystem _filesystem;

        public bool ShowFiles { get; set; }
        public string SelectedPath => fileExplorer.SelectedNode.Tag as string;

        private IProfile _profile;
        public IProfile Profile
        {
            private get { return _profile;}
            set
            {
                _profile = value;
                _filesystem = new FilesystemFactory(_profile, this).Create();

                // TODO: This call is not awaited (see warning)
                CreateTree(fileExplorer);
            }
        }

        public FolderTreeView()
        {
            InitializeComponent();

            _formValidation = new FormValidation();

            fileExplorer.KeyDown += OnKeyDown;
            InitListboxContexMenu();
        }

        public async Task<bool> CreateTree(TreeView treeView)
        {
            bool returnValue = false;

            try
            {
                foreach (var drv in await _filesystem.GetDrives())
                {
                    var fChild = new TreeNode();
                    if (drv.Value == DriveType.CDRom)
                    {
                        fChild.ImageIndex = 1;
                        fChild.SelectedImageIndex = 1;
                        fChild.Tag = drv.Key;
                    }
                    else if (drv.Value == DriveType.Fixed)
                    {
                        fChild.ImageIndex = 0;
                        fChild.SelectedImageIndex = 0;
                        fChild.Tag = drv.Key;
                    }
                    fChild.Text = drv.Key;
                    fChild.Nodes.Add("");
                    treeView.Nodes.Add(fChild);
                    returnValue = true;
                }
            }
            catch (Exception e)
            {
                returnValue = false;
            }
            return returnValue;
        }

        private void trwFileExplorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                EnumerateDirectory(e.Node);
            }
        }

        public TreeNode EnumerateDirectory(TreeNode parentNode)
        {
            try
            {
                parentNode.Nodes[0].Remove();
                foreach (var dir in _filesystem.GetDirectories(parentNode.FullPath))
                {
                    var node = new TreeNode { Text = dir.Value, Tag = dir.Key };
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }

                if (ShowFiles)
                {
                    foreach (var file in _filesystem.GetFiles(parentNode.FullPath, String.Empty))
                    {
                        var node = new TreeNode { Text = file.Value, Tag = file.Key, ImageIndex = 2, SelectedImageIndex = 2 };
                        parentNode.Nodes.Add(node);
                    }
                }
            }

            catch (Exception e)
            {
            }

            return parentNode;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var treeView = sender as TreeView;
            var node = treeView.SelectedNode;

            if (e.KeyData == Keys.Escape)
            {
                if (node.IsEditing)
                {
                    node.EndEdit(true);
                }
                else
                {
                    CancelSent(this, new EventArgs());
                }
            }
            else if (e.KeyData == Keys.F2)
            {
                if (!node.IsEditing)
                {
                    fileExplorer.AfterLabelEdit += AfterLabelEdit;
                    node.BeginEdit();
                }
            }
            else if (e.KeyData == Keys.Delete)
            {
                NotifyAndDelete(node);
            }
        }

        private async void NotifyAndDelete(TreeNode node)
        {
            var directoryName = await _filesystem.GetDirectoryName(node.FullPath);
            if (directoryName != null && ShowYesNo("Delete folder", $"Are you sure you want to delete the folder:\n\n{directoryName}?"))
            {
                await _filesystem.DeleteDirectory(node.FullPath);
                node.Remove();
            }
        }

        private async Task<string> FindNewFolderName(string parentFolder, string suggested)
        {
            int count = 1;

            string newFullPath = Path.Combine(parentFolder, suggested);

            const string pattern = @"(.+ )\((\d+)\)$";

            while (await _filesystem.DirectoryExists(newFullPath))
            {
                if (Regex.IsMatch(newFullPath, pattern))
                {
                    newFullPath = Regex.Replace(newFullPath, pattern, m => $"{m.Groups[1].Value}({count++})");
                }
                else
                {
                    newFullPath = $"{newFullPath} ({count++})";
                }
            }

            return Path.GetFileName(newFullPath);
        }

        public async void MakeNewFolder()
        {
            string parentFolder = fileExplorer.SelectedNode.Tag as string;
            string newFoldename = await FindNewFolderName(parentFolder, "New Folder");

            var path = Path.Combine(parentFolder, newFoldename);
            
            await _filesystem.CreateDirectory(path);

            var node = new TreeNode { Text = newFoldename, Tag = path };
            fileExplorer.SelectedNode.Nodes.Add(node);
            fileExplorer.Refresh();

            fileExplorer.AfterLabelEdit += AfterLabelEdit;

            fileExplorer.SelectedNode = node;
            if (!node.IsEditing)
            {
                node.BeginEdit();
            }
        }

        private void AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            fileExplorer.AfterLabelEdit -= AfterLabelEdit;

            if (e.Node.Parent != null)
            {
                var parentPath = e.Node.Parent.Tag.ToString();

                var oldFileFullPath = Path.Combine(parentPath, e.Node.Text);

                if (e.Label != null)
                {
                    var newFullPath = Path.Combine(parentPath, e.Label);

                    if (oldFileFullPath != newFullPath)
                    {
                        _filesystem.RenameDirectory(oldFileFullPath, newFullPath);

                        e.Node.Text = e.Label;
                        e.Node.Tag = newFullPath;
                    }
                }
            }

            e.Node.EndEdit(true);
            EditFinished(this, new EventArgs());
        }

        private void trwFileExplorer_DoubleClick(object sender, EventArgs e)
        {
            var treeView = sender as TreeView;
            var node = treeView.SelectedNode;

            if (node != null)
            {
                DoubleClicked(this, new Sifon.Code.Events.EventArgs<string>(node.Tag as string));
            }
        }

        #region IFormValidation

        public bool ShowYesNo(string caption, string message)
        {
            return _formValidation.ShowYesNo(caption, message);
        }

        public void ShowInfo(string caption, string message)
        {
            _formValidation.ShowInfo(caption, message);
        }

        public void ShowError(string caption, string message)
        {
            _formValidation.ShowError(caption, message);
        }

        public bool ShowValidationError(IEnumerable<string> errorList)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
