using System;
using System.Drawing;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Profiles;
using Sifon.Code.DialogEnhancements;
using Sifon.Code.Extensions;
using Sifon.Forms.Base;

namespace Sifon.Forms.SettingsForm
{
    internal partial class SettingsForm : BaseForm, ISettingsFormView, ICrashDetails
    {
        const string MASTER =  "Use master branch of a repository";
        const string VERSION = "Align to a version matching branch";

        public event EventHandler<EventArgs<ICrashDetails>> ValuesChanged = delegate { };

        internal SettingsForm()
        {
            InitializeComponent();
            new SettingsFormPresenter(this);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            PopulateVersionsCombo();
            Raise_FormLoaded();
            buttonSave.Focus();
        }

        private void PopulateVersionsCombo()
        {
            comboBranching.Items.Clear();
            comboBranching.Items.Add(MASTER);
            comboBranching.Items.Add(VERSION);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // No need to do validation yet as single checkbox is always valid
            // Later use this clause: if(!ValidateForm()) return;
            if (ValidateValues())
            {
                ValuesChanged(this, new EventArgs<ICrashDetails>(this));
            }
        }

        #region Interface implementation

        public bool UseDownloadCDN
        {
            get => checkDownloadCDN.Checked;
            set => checkDownloadCDN.Checked = value;
        }
        public bool SendCrashDetails
        {
            get => checkBoxCrashLog.Checked;
            set => checkBoxCrashLog.Checked = value;
        }

        public string PluginsRepository
        {
            get => textRepository.Text;
            set => textRepository.Text = value;
        }

        public string CustomPluginsFolder
        {
            get => textCustomPluginsFolder.Text.Trim();
            set => textCustomPluginsFolder.Text = value;
        }

        public bool AlignVersions
        {
            get => comboBranching.SelectedItem == VERSION;
            set => comboBranching.SelectedItem = value ? VERSION : MASTER;
        }

        #endregion

        public void SetView(ICrashDetails entity)
        {
            UseDownloadCDN = entity.UseDownloadCDN;
            SendCrashDetails = entity.SendCrashDetails;
            PluginsRepository = entity.PluginsRepository;
            CustomPluginsFolder = entity.CustomPluginsFolder;
            AlignVersions = entity.AlignVersions;
        }

        public void UpdateResult()
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCustomPluginsLocation_Click(object sender, EventArgs e)
        {

            var folderBrowser = new FolderBrowserDialog
            {
                SelectedPath = textCustomPluginsFolder.Text.NotEmpty() ? textCustomPluginsFolder.Text : @"c:\",
                ShowNewFolderButton = false
            };

            using (new OffsetWinDialog(this) { PreferredOffset = new Point(360, 3) })
            using (new SizeWinDialog(this) { PreferredSize = new Size(350, 450) })
            {
                DialogResult result = folderBrowser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    textCustomPluginsFolder.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("https://sifon.uk/docs/Settings.md");
        }
    }
}
