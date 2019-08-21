using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sifon.Shared.Helpers;
using Sifon.Statics;

namespace Sifon.Forms.MainForm
{
    partial class Main
    {
        #region Listbox cotnext menu

        private ContextMenuStrip collectionRoundMenuStrip;

        public void InitListboxContexMenu()
        {
            var toolStripMenuItem1 = new ToolStripMenuItem { Text = Statics.ContextMenu.CopyClipboard };
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;

            var toolStripMenuItem3 = new ToolStripMenuItem { Text = Statics.ContextMenu.SaveToFile };
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;

            var toolStripMenuItem2 = new ToolStripMenuItem { Text = Statics.ContextMenu.ClearAll };
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;

            collectionRoundMenuStrip = new ContextMenuStrip();
            collectionRoundMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                toolStripMenuItem1, toolStripMenuItem3, toolStripMenuItem2
            });

            listBoxOutput.MouseDown += myListBox_MouseDown;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetOutputLines(true));
        }

        private string GetOutputLines(bool onlySelected)
        {
            var builder = new StringBuilder();
            var items = onlySelected ? listBoxOutput.SelectedItems.Cast<string>() : listBoxOutput.Items.Cast<string>();
            foreach (var selectedItem in items)
            {
                var helper = new RegexHelper(Pattern.ColorPattern);
                var line = helper.Replace(selectedItem);
                builder.AppendLine(line);
            }

            return builder.ToString();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "*.log|*.txt";
            saveFileDialog1.Title = Statics.ContextMenu.SaveDialogTitle;
            saveFileDialog1.ShowDialog();
            var fileName = saveFileDialog1.FileName;

            if (!string.IsNullOrEmpty(fileName))
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                File.AppendAllText(saveFileDialog1.FileName, GetOutputLines(false));
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listBoxOutput.Items.Clear();
        }

        private void myListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            collectionRoundMenuStrip.Show(Cursor.Position);
            collectionRoundMenuStrip.Visible = true;
        }

        #endregion
    }
}
