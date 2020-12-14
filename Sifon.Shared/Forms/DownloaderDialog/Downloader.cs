using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Extensions;
using Sifon.Shared.Code.Downloader;
using Sifon.Shared.Forms.Base;
using Sifon.Shared.Forms.FolderBrowserDialog;

namespace Sifon.Shared.Forms.DownloaderDialog
{
    public partial class Downloader : BaseDialog
    {
        const string CHECK = "Check all";
        const string UNCHECK = "Uncheck all";

        private IProfile _profile;
        private string _json;
        private List<Resource> _resources;

        public Downloader()
        {
            InitializeComponent();
        }

        private void Downloader_Load(object sender, EventArgs e)
        {
            if (comboVersion.Items.Count > 0)
            {
                comboVersion.SelectedIndex = comboVersion.Items.Count - 1;
            }

            buttonDownload.Select();

            Destination = $"{Environment.CurrentDirectory}\\Downloads";

            CheckUncheckAll(true);

            foreach (var checkBox in CheckBoxes)
            {
                checkBox.CheckedChanged += CheckedChanged;
            }

            UpdateButtonState();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            buttonDownload.Enabled = CheckBoxes.Any(cb => cb.Checked) && Destination.NotEmpty();
        }

        public Resource[] SelectProducts(IProfile profile, string json)
        {
            _profile = profile;
            _json = json;

            Text += $" - {profile.WindowCaptionSuffix}";

            StartPosition = FormStartPosition.CenterParent;

            if (ShowDialog() == DialogResult.OK)
            {
                _resources.ForEach(r => r.path = $"{Destination}\\{r.path}");
                return _resources.ToArray();
            }

            return null;
        }

        private List<CheckBox> _checkBoxes;
        private IEnumerable<CheckBox> CheckBoxes
        {
            get
            {
                if (_checkBoxes == null)
                {
                    _checkBoxes = new List<CheckBox>();

                    foreach (Control c in Controls)
                    {
                        if (c is GroupBox && c.Name.StartsWith("group"))
                        {
                            foreach (Control _c in c.Controls)
                            {
                                if (_c is CheckBox && _c.Name.StartsWith("check"))
                                {
                                    _checkBoxes.Add(_c as CheckBox);
                                }
                            }
                        }
                    }
                }

                return _checkBoxes;
            }
        }

        public string Destination
        {
            get => textDestinationFolder.Text.TrimEnd('\\').Trim();
            set => textDestinationFolder.Text = value.Trim().TrimEnd('\\');
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (!Destination.NotEmpty())
            {
                DialogResult = DialogResult.Abort;
            }

            if (File.Exists(_json))
            {
                string selectedPlatform = comboVersion.SelectedItem as string;
                var platforms = JsonConvert.DeserializeObject<IEnumerable<Platform>>(File.ReadAllText(_json));
                var platform = platforms.FirstOrDefault(p => p.name.Trim() == selectedPlatform);

                if (platform == null)
                {
                    MessageBox.Show($"Patform {selectedPlatform} not found.\nPlease verify json file has valid resources", "Error");
                    return;
                }

                _resources = new List<Resource>();

                foreach (var cb in CheckBoxes)
                {
                    if (cb.Checked)
                    {
                        var code = cb.Name.Substring(5);
                        var codeMatch = platform.resources.Where(p => p.code == code);
                        _resources.AddRange(codeMatch);
                    }
                }

                _resources.ForEach(r => r.path = $"{platform.name}\\{r.path}");
            }
        }

        private void buttonLocation_Click(object sender, EventArgs e)
        {
            var browser = new FolderBrowser(_profile, true) { StartPosition = FormStartPosition.CenterParent };
            if (browser.ShowDialog() == DialogResult.OK)
            {
                textDestinationFolder.Text = browser.SelectedPath;
            }
        }

        private void linkAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckUncheckAll(linkAll.Text == CHECK);
        }

        private void CheckUncheckAll(bool allChecked)
        {
            foreach (var checkBox in CheckBoxes)
            {
                checkBox.Checked = allChecked;
            }

            linkAll.Text = allChecked ? UNCHECK : CHECK;
        }

        private void textDestinationFolder_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }
    }
}
