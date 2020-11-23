using System;
using System.Drawing;
using System.Windows.Forms;
using Sifon.Code.Extensions;
using Sifon.Code.Helpers;
using Sifon.Statics;

namespace Sifon.Forms.MainForm
{
    partial class Main
    {
        #region ListboxOutput updating

        public bool listBoxChangedFlag { get; set; } = false;

        public void AppendLine(string line, Color? color = null)
        {
            if (!string.IsNullOrEmpty(line))
            {
                if (color != null)
                {
                    line = $"#COLOR:{color.Value.Name}#{line}";
                }

                listBoxChangedFlag = true;
                if (listBoxOutput.Items.Count > 10000) listBoxOutput.Items.RemoveAt(0);
                listBoxOutput.Items.Add(line);
                listBoxOutput.TopIndex = listBoxOutput.Items.Count - 1;
            }
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            string line = ((ListBox)sender).Items[e.Index].ToString();

            e.DrawBackground();

            var brush = Brushes.White;
            if (line.StartsWith("INFORMATION: "))
            {
                brush = Brushes.Yellow;
            }
            if (line.StartsWith("WARNING: "))
            {
                brush = Brushes.Yellow;
            }
            if (line.StartsWith("ERROR: "))
            {
                brush = Brushes.Red;
            }

            var regexHelper = new RegexHelper(Pattern.ColorPattern);

            if (line.StartsWith("#COLOR:"))
            {
                string colorCode = regexHelper.Extract(line);
                if (colorCode.NotEmpty())
                {
                    brush = new SolidBrush(Color.FromName(colorCode));
                    line = regexHelper.Replace(line);
                }
            }

            e.Graphics.DrawString(line, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void timerOutput_Tick(object sender, EventArgs e)
        {
            if (listBoxChangedFlag)
            {
                listBoxOutput.EndUpdate();
                listBoxOutput.Update();
                listBoxChangedFlag = false;
                listBoxOutput.BeginUpdate();
            }
            else
            {
                listBoxOutput.EndUpdate();
            }
        }

        #endregion
    }
}
