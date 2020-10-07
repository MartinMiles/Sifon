using System;
using System.Windows.Forms;

namespace Sifon.Shared.UserControls
{
    public partial class FolderTreeView
    {
        #region Listbox cotnext menu

        private ContextMenuStrip collectionRoundMenuStrip;

        public void InitListboxContexMenu()
        {
            var toolStripMenuItem1 = new ToolStripMenuItem { Text = "Rename" };
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;

            var toolStripMenuItem2 = new ToolStripMenuItem { Text = "Delete" };
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;

            collectionRoundMenuStrip = new ContextMenuStrip();
            collectionRoundMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                toolStripMenuItem1, toolStripMenuItem2
            });

            fileExplorer.MouseDown += myListBox_MouseDown;
        }

        private void myListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            fileExplorer.SelectedNode = fileExplorer.GetNodeAt(e.X, e.Y);

            collectionRoundMenuStrip.Show(Cursor.Position);
            collectionRoundMenuStrip.Visible = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var node = fileExplorer.SelectedNode;

            if (node != null && !node.IsEditing)
            {
                fileExplorer.AfterLabelEdit += AfterLabelEdit;
                node.BeginEdit();
            }
        }

        //private string GetOutputLines(bool onlySelected)
        //{
        //    var builder = new StringBuilder();
        //    var items = onlySelected ? listBoxOutput.SelectedItems.Cast<string>() : listBoxOutput.Items.Cast<string>();
        //    foreach (var selectedItem in items)
        //    {
        //        var helper = new RegexHelper(Pattern.ColorPattern);
        //        var line = helper.Replace(selectedItem);
        //        builder.AppendLine(line);
        //    }

        //    return builder.ToString();
        //}

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "*.log|*.txt";
            //saveFileDialog1.Title = Statics.ContextMenu.SaveDialogTitle;
            //saveFileDialog1.ShowDialog();
            //var fileName = saveFileDialog1.FileName;

            //if (!string.IsNullOrEmpty(fileName))
            //{
            //    if (File.Exists(fileName))
            //    {
            //        File.Delete(fileName);
            //    }
            //    File.AppendAllText(saveFileDialog1.FileName, GetOutputLines(false));
            //}
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var node = fileExplorer.SelectedNode;

            if (node != null && !node.IsEditing)
            {
                NotifyAndDelete(node);
            }
        }

        #endregion
    }
}
