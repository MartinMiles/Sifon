using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Containers;
using Sifon.Shared.Events;
using Sifon.Shared.Statics;

namespace Sifon.Forms.MainForm
{
    internal partial class Main : Form, IMainView
    {
        #region Events

        public event EventHandler<EventArgs> FormLoaded = delegate { };
        public event EventHandler<EventArgs> ScriptFinishRequested = delegate { };
        public event EventHandler<EventArgs<string>> SelectedProfileChanged = delegate { };
        public event EventHandler<EventArgs> ProfilesToolStripClicked = delegate { };
        public event EventHandler<EventArgs<IBackupRemoverViewModel>> BackupToolStripClicked = delegate { };
        public event EventHandler<EventArgs<IBackupRemoverViewModel>> RemoveToolStripClicked = delegate { };
        public event EventHandler<EventArgs<IRestoreViewModel>> RestoreToolStripClicked = delegate { };
        public event EventHandler<EventArgs<string>> ScriptToolStripClicked = delegate { };

        #endregion

        internal Main()
        {
            InitializeComponent();
            new MainPresenter(this);
        }
        
        private void Form_Load(object sender, EventArgs e)
        {
            FormLoaded(this, new EventArgs());

            SetTooltips();
            InitListboxContexMenu();

            buttonStopScript.Click += (s, a) => ScriptFinishRequested(this, new EventArgs());
        }

        public void SetCaption(string captionSuffix)
        {
            Text = $"{Settings.ProductVersion} - {Environment.CurrentDirectory} - {captionSuffix}";
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            ScriptFinishRequested(this, new EventArgs());
        }

        #region Profiles

        public void LoadProfilesSelector(IEnumerable<string> profiles, string selectedProfileName)
        {
            comboProfiles.Items.Clear();

            foreach (var profile in profiles)
            {
                comboProfiles.Items.Add(profile);
            }

            if (comboProfiles.Items.Count > 0)
            {
                comboProfiles.SelectedIndex = comboProfiles.Items.IndexOf(selectedProfileName);
            }

            comboProfiles.Enabled = profiles.Any();
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProfileChanged(this, new EventArgs<string>(comboProfiles.SelectedItem.ToString()));
        }

        #endregion

        #region Menu handlers for other forms

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var backupForm = new Backup.Backup { StartPosition = FormStartPosition.CenterParent };
            if (backupForm.ShowDialog() == DialogResult.OK)
            {
                backupForm.Dispose();
                BackupToolStripClicked(this, new EventArgs<IBackupRemoverViewModel>(backupForm));
            }
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var removeForm = new Remover.Remover { StartPosition = FormStartPosition.CenterParent };
            if (removeForm.ShowDialog() == DialogResult.OK)
            {
                RemoveToolStripClicked(this, new EventArgs<IBackupRemoverViewModel>(removeForm));
            }
            removeForm.Dispose();
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var restoreForm = new Restore.Restore { StartPosition = FormStartPosition.CenterParent };
            if (restoreForm.ShowDialog() == DialogResult.OK)
            {
                RestoreToolStripClicked(this, new EventArgs<IRestoreViewModel>(restoreForm));
            }
            restoreForm.Dispose();
        }

        private void profilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Profiles.Profiles { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();

            ProfilesToolStripClicked(this, new EventArgs());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About.About { StartPosition = FormStartPosition.CenterParent };
            if (about.ShowDialog() == DialogResult.OK)
            {
                about.Dispose();
            }
        }
        
        #endregion

        public void BeginUI()
        {
            listBoxOutput.Items.Clear();
            progressBar.Value = 0;
            buttonStopScript.Enabled = true;
            comboProfiles.Enabled = false;

            statusLabel.Text = "In progress...";
        }

        public void ToolStripsEnabled(bool enabled)
        {
            backupToolStripMenuItem.Enabled = enabled;
            removeToolStripMenuItem1.Enabled = enabled;
            restoreToolStripMenuItem.Enabled = enabled;
            pluginsToolStripMenuItem.Enabled = enabled;
        }

        public void FinishUI()
        {
            buttonStopScript.Enabled = false;
            comboProfiles.Enabled = true;

            statusLabel.Text = "Ready.";
        }

        public void UpdateProgressBar(int percentComplete, string statusLabelText)
        {
            if (percentComplete < 0) return;

            progressBar.Value = percentComplete;
            statusLabel.Text = statusLabelText;
            progressLabel.Text = $"Progress: {percentComplete}%";
        }

        public void ForceProfileDialogOnFirstRun()
        {
            var form = new Profiles.Profiles(true) { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        private void sitecorePortalCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PortalCredentials.PortalCredentials { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        public void TerminateAsEmptyProfile()
        {
            MessageBox.Show("A profile folder is not initialized.\nIt is requred for Sifon to run and function\nPlease configure at least one local profile", "First Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void menuContainersProfiles_Click(object sender, EventArgs e)
        {
            var form = new DockerProfiles { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        private void menuContainersPlugins_Click(object sender, EventArgs e)
        {

        }
    }
}
