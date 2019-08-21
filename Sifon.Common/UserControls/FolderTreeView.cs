using System;
using System.IO;
using System.Windows.Forms;
using Sifon.PowerShell;

namespace Ex_TreeView
{
    public partial class FolderTreeView : UserControl
    {
        private readonly SimpleRunner _simpleRunner;

        public FolderTreeView()
        {
            InitializeComponent();
            _simpleRunner = new SimpleRunner();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CreateTree(trwFileExplorer);
        }

        private void trwFileExplorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode node = EnumerateDirectory(e.Node);
            }
        }

        public bool CreateTree(TreeView treeView)
        {
            bool returnValue = false;

            try
            {
                //TreeNode desktop = new TreeNode {Text = "Desktop", Tag = "Desktop"};
                //desktop.Nodes.Add("");
                //treeView.Nodes.Add(desktop);

                foreach (DriveInfo drv in DriveInfo.GetDrives())
                {
                    TreeNode fChild = new TreeNode();
                    if (drv.DriveType == DriveType.CDRom)
                    {
                        fChild.ImageIndex = 1;
                        fChild.SelectedImageIndex = 1;
                    }
                    else if (drv.DriveType == DriveType.Fixed)
                    {
                        fChild.ImageIndex = 0;
                        fChild.SelectedImageIndex = 0;
                    }
                    fChild.Text = drv.Name;
                    fChild.Nodes.Add("");
                    treeView.Nodes.Add(fChild);
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                returnValue = false;
            }
            return returnValue;
        }

        public TreeNode EnumerateDirectory(TreeNode parentNode)
        {
            try
            {
                var rootDir = GetDirectoryInfo(parentNode.FullPath);

                parentNode.Nodes[0].Remove();
                foreach (string dir in GetDirectories(rootDir))
                {
                    TreeNode node = new TreeNode { Text = dir };
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }

                foreach (string file in GetFiles(rootDir))
                {
                    TreeNode node = new TreeNode { Text = file, ImageIndex = 2, SelectedImageIndex = 2 };
                    parentNode.Nodes.Add(node);
                }
            }

            catch (Exception ex)
            {
            }

            return parentNode;
        }
    }
}
