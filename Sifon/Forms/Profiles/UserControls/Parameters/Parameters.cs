using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Sifon.Extensions;
using Sifon.Forms.Profiles.UserControls.Base;
using Sifon.Code.Statics;

namespace Sifon.Forms.Profiles.UserControls.Parameters
{
    internal partial class Parameters : BaseUserControl, IParametersView
    {
        public event EventHandler<EventArgs> DownloadSampleScriptClicked = delegate { };

        private int lines = 0;

        internal Parameters()
        {
            InitializeComponent();
            new ParametersPresenter(this);
        }

        public Dictionary<string, string> Values
        {
            get
            {
                var dictionary = new Dictionary<string, string>();

                for (int i = 0; i < lines; i++)
                {
                    var key = Find(Settings.Profiles.Parameters.KeyPrefix, i);
                    var val = Find(Settings.Profiles.Parameters.ValPrefix, i);

                    if (key != null && val != null && !key.IsEmpty() && !val.IsEmpty())
                    {
                        dictionary.Add(key.Text.Trim(), val.Text.Trim());
                    }
                }

                return dictionary;
            }
        }

        public void SetValues(Dictionary<string, string> parameters)
        {
            foreach (var parameter in parameters)
            {
                AddNewTexboxesPair(lines, parameter.Key, parameter.Value);
            }
        }

        private void buttonAddPair_Click(object sender, System.EventArgs e)
        {
            if(!ValidateValues()) return;

            RemoveEmptyPairs();
            AddNewTexboxesPair(lines);
            buttonAddPair.Enabled = false;
        }



        private void RemoveEmptyPairs()
        {
            if (lines > 0)
            {
                for (int i = lines-1; i >=0;  i--)
                {
                    var key = Find(Settings.Profiles.Parameters.KeyPrefix, i);
                    var val = Find(Settings.Profiles.Parameters.ValPrefix, i);

                    if (key != null && val != null && key.IsEmpty() && val.IsEmpty())
                    {
                        panel.Controls.Remove(key);
                        panel.Controls.Remove(val);

                        for (int j = i; j <= lines; j++)
                        {
                            var _key = Find(Settings.Profiles.Parameters.KeyPrefix, j);
                            var _val = Find(Settings.Profiles.Parameters.ValPrefix, j);

                            if (_key != null && _val != null)
                            {
                                _key.Location = new Point(_key.Location.X, _key.Location.Y-26);
                                _val.Location = new Point(_val.Location.X, _val.Location.Y-26);
                                _key.Name = $"{Settings.Profiles.Parameters.KeyPrefix}{j - 1}";
                                _val.Name = $"{Settings.Profiles.Parameters.ValPrefix}{j - 1}";
                            }
                        }
                        lines--;

                    }
                }
            }
        }

        private void AddNewTexboxesPair(int index, string keyText = null, string keyValue = null)
        {
            int line = index * 26 + 12;
            var key = new TextBox {Location = new Point(18, line), Width = 110, Name = $"{Settings.Profiles.Parameters.KeyPrefix}{index}" };
            key.KeyPress += ValidateParameterName;
            key.KeyUp += UpdateButton;
            key.Text = keyText ?? String.Empty;

            var val = new TextBox {Location = new Point(134, line), Width = 140, Name = $"{Settings.Profiles.Parameters.ValPrefix}{index}"};
            val.KeyPress += MoveNext;
            val.KeyUp += UpdateButton;
            val.Text = keyValue ?? String.Empty;

            panel.Controls.Add(key);
            panel.Controls.Add(val);
            lines++;

            key.Focus();
        }

        private TextBox Find(string prefix, int i)
        {
            return Controls.Find($"{prefix}{i}", true).FirstOrDefault() as TextBox;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadSampleScriptClicked(this, new EventArgs());
        }

        public void SaveSampleScript(string script)
        {
            string filter = "PowerShell scripts (*.ps1)|*.ps1|All Files(*.*)|*.*";
            var savefile = new SaveFileDialog { FileName = "SampleProfileScript.ps1", Filter = filter };
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(savefile.FileName, script);
            }
        }
    }
}
