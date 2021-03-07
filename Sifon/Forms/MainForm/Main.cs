using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sifon.Abstractions.Events;
using Sifon.Abstractions.Model.BackupRestore;
using Sifon.Forms.Containers;
using Sifon.Code.Statics;
using Sifon.Forms.Base;
using Sifon.Forms.Other;
using Sifon.Forms.Updates;

namespace Sifon.Forms.MainForm
{
    internal partial class Main : Form, IMainView
    {
        #region Events

        public event EventHandler<EventArgs> FormLoaded = delegate { };
        public event EventHandler<EventArgs> ScriptFinishRequested = delegate { };
        public event EventHandler<EventArgs<string>> SelectedProfileChanged = delegate { };
        public event EventHandler<EventArgs> ProfilesToolStripClicked = delegate { };
        public event EventHandler<EventArgs> SettingsChanged = delegate { };
        public event EventHandler<EventArgs<dynamic>> InstallToolStripClicked = delegate { };
        public event EventHandler<EventArgs<IBackupRemoverViewModel>> BackupToolStripClicked = delegate { };
        public event EventHandler<EventArgs<IBackupRemoverViewModel>> RemoveToolStripClicked = delegate { };
        public event EventHandler<EventArgs<IRestoreViewModel>> RestoreToolStripClicked = delegate { };
        public event BaseForm.AsyncEventHandler<EventArgs<string>> ScriptToolStripClicked;

        #endregion

        internal Main()
        {
            InitializeComponent();
            try
            {
                new MainPresenter(this);
            }
            catch (InvalidOperationException)
            {
                Load += (s, e) => Close();
            }
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
        
        private void menuContainersProfiles_Click(object sender, EventArgs e)
        {
            var dockerProfiles = new DockerProfiles { StartPosition = FormStartPosition.CenterParent };
            dockerProfiles.ShowDialog();
            dockerProfiles.Dispose();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var about = new About.About { StartPosition = FormStartPosition.CenterParent };
            if (about.ShowDialog() == DialogResult.OK)
            {
                about.Dispose();
            }
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var feedback = new Feedback.Feedback { StartPosition = FormStartPosition.CenterParent };
            if (feedback.ShowDialog() == DialogResult.OK)
            {
                feedback.Dispose();
            }
        }

        private void checkUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var checkUpdates = new CheckUpdates { StartPosition = FormStartPosition.CenterParent };
            if (checkUpdates.ShowDialog() == DialogResult.OK)
            {
                checkUpdates.Dispose();
            }
        }

        private void installHostPrerequsitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var prerequsites = new Prerequsites.Prerequsites { StartPosition = FormStartPosition.CenterParent };
            if (prerequsites.ShowDialog() == DialogResult.OK)
            {
                prerequsites.Dispose();
            }
        }

        private void sitecorePortalCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PortalCredentials.PortalCredentials { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm.SettingsForm { StartPosition = FormStartPosition.CenterParent };
            if (form.ShowDialog() == DialogResult.OK)
            {
                SettingsChanged(this, new EventArgs());
            }

            form.Dispose();
        }

        private void installSolrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Solr.InstallSolr { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
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

            PluginsToolStripEnabled();
        }

        public void PluginsToolStripEnabled()
        {
            var children = pluginsToolStripMenuItem.DropDown.Items;

            bool othersEnabled = backupToolStripMenuItem.Enabled;

            pluginsToolStripMenuItem.Enabled
                = othersEnabled || children.Count == 1 && children[0].Name.EndsWith("Get-SifonPlugins.ps1");
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

        public bool ShowFirstRunDialog()
        {
            var firstRunForm = new FirstTimeRun { StartPosition = FormStartPosition.CenterParent };
            return firstRunForm.ShowDialog() == DialogResult.OK;
        }

        public void ForceProfileDialogOnFirstRun()
        {
            var form = new Profiles.Profiles(true) { StartPosition = FormStartPosition.CenterParent };
            form.ShowDialog();
            form.Dispose();
        }

        public void End()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void TerminateAsEmptyProfile()
        {
            MessageBox.Show("A profile folder is not initialized or no active profile found.\nThat is requred for Sifon to run and function\nPlease configure at least one local profile", "First Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            End();
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var install = new Install.Install { StartPosition = FormStartPosition.CenterParent };
            
            if (install.ShowDialog() == DialogResult.OK)
            {
                InstallToolStripClicked(this, new EventArgs<dynamic>(install.Parameters));
            }

            install.Dispose();
        }
    }
}
