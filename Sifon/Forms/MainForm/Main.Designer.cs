namespace Sifon.Forms.MainForm
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContainerPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sitecorePortalCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.installSolrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installSQLServerExpressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installHostPrerequsitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllExistingSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerOutput = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.buttonStopScript = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.removeToolStripMenuItem1,
            this.restoreToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.containersToolStripMenuItem,
            this.pluginsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1410, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.installToolStripMenuItem.Text = "Install";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.removeToolStripMenuItem1.Text = "Remove";
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem1_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            this.profilesToolStripMenuItem.Click += new System.EventHandler(this.profilesToolStripMenuItem_Click);
            // 
            // containersToolStripMenuItem
            // 
            this.containersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem1,
            this.menuContainerPlugins});
            this.containersToolStripMenuItem.Enabled = false;
            this.containersToolStripMenuItem.Name = "containersToolStripMenuItem";
            this.containersToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.containersToolStripMenuItem.Text = "Containers";
            this.containersToolStripMenuItem.ToolTipText = "Containers are temporary unavailable in this version";
            // 
            // profilesToolStripMenuItem1
            // 
            this.profilesToolStripMenuItem1.Name = "profilesToolStripMenuItem1";
            this.profilesToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.profilesToolStripMenuItem1.Text = "Container Profiles";
            this.profilesToolStripMenuItem1.Click += new System.EventHandler(this.menuContainersProfiles_Click);
            // 
            // menuContainerPlugins
            // 
            this.menuContainerPlugins.Name = "menuContainerPlugins";
            this.menuContainerPlugins.Size = new System.Drawing.Size(168, 22);
            this.menuContainerPlugins.Text = "Plugins / Actions";
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sitecorePortalCredentialsToolStripMenuItem,
            this.settingsToolStripMenuItem1,
            this.installSolrToolStripMenuItem,
            this.installSQLServerExpressToolStripMenuItem,
            this.installHostPrerequsitesToolStripMenuItem,
            this.resetAllExistingSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // sitecorePortalCredentialsToolStripMenuItem
            // 
            this.sitecorePortalCredentialsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sitecorePortalCredentialsToolStripMenuItem.Name = "sitecorePortalCredentialsToolStripMenuItem";
            this.sitecorePortalCredentialsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.sitecorePortalCredentialsToolStripMenuItem.Text = "Sitecore Portal Credentials";
            this.sitecorePortalCredentialsToolStripMenuItem.Click += new System.EventHandler(this.sitecorePortalCredentialsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.settingsToolStripMenuItem1.Text = "Application Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // installSolrToolStripMenuItem
            // 
            this.installSolrToolStripMenuItem.Name = "installSolrToolStripMenuItem";
            this.installSolrToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.installSolrToolStripMenuItem.Text = "Install Solr";
            this.installSolrToolStripMenuItem.Click += new System.EventHandler(this.installSolrToolStripMenuItem_Click);
            // 
            // installSQLServerExpressToolStripMenuItem
            // 
            this.installSQLServerExpressToolStripMenuItem.Name = "installSQLServerExpressToolStripMenuItem";
            this.installSQLServerExpressToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.installSQLServerExpressToolStripMenuItem.Text = "Install SQL Server Express";
            this.installSQLServerExpressToolStripMenuItem.Click += new System.EventHandler(this.installSQLServerExpressToolStripMenuItem_Click);
            // 
            // installHostPrerequsitesToolStripMenuItem
            // 
            this.installHostPrerequsitesToolStripMenuItem.Name = "installHostPrerequsitesToolStripMenuItem";
            this.installHostPrerequsitesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.installHostPrerequsitesToolStripMenuItem.Text = "Install Prerequsites";
            this.installHostPrerequsitesToolStripMenuItem.Click += new System.EventHandler(this.installHostPrerequsitesToolStripMenuItem_Click);
            // 
            // resetAllExistingSettingsToolStripMenuItem
            // 
            this.resetAllExistingSettingsToolStripMenuItem.Name = "resetAllExistingSettingsToolStripMenuItem";
            this.resetAllExistingSettingsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.resetAllExistingSettingsToolStripMenuItem.Text = "Reset All Existing Settings";
            this.resetAllExistingSettingsToolStripMenuItem.Click += new System.EventHandler(this.resetAllExistingSettingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.checkUpdatesToolStripMenuItem,
            this.sendFeedbackToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.aboutToolStripMenuItem1.Text = "About Sifon";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // checkUpdatesToolStripMenuItem
            // 
            this.checkUpdatesToolStripMenuItem.Name = "checkUpdatesToolStripMenuItem";
            this.checkUpdatesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.checkUpdatesToolStripMenuItem.Text = "Check Updates";
            this.checkUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkUpdatesToolStripMenuItem_Click);
            // 
            // sendFeedbackToolStripMenuItem
            // 
            this.sendFeedbackToolStripMenuItem.Name = "sendFeedbackToolStripMenuItem";
            this.sendFeedbackToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sendFeedbackToolStripMenuItem.Text = "Send Feedback";
            this.sendFeedbackToolStripMenuItem.Click += new System.EventHandler(this.sendFeedbackToolStripMenuItem_Click);
            // 
            // timerOutput
            // 
            this.timerOutput.Enabled = true;
            this.timerOutput.Tick += new System.EventHandler(this.timerOutput_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboProfiles);
            this.groupBox2.Controls.Add(this.statusLabel);
            this.groupBox2.Controls.Add(this.buttonStopScript);
            this.groupBox2.Controls.Add(this.progressLabel);
            this.groupBox2.Controls.Add(this.progressBar);
            this.groupBox2.Controls.Add(this.listBoxOutput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 80, 8, 8);
            this.groupBox2.Size = new System.Drawing.Size(1410, 771);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1158, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select active profile:";
            // 
            // comboProfiles
            // 
            this.comboProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(1161, 49);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(140, 21);
            this.comboProfiles.TabIndex = 10;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(8, 753);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "Ready.";
            // 
            // buttonStopScript
            // 
            this.buttonStopScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopScript.Enabled = false;
            this.buttonStopScript.Location = new System.Drawing.Point(1307, 33);
            this.buttonStopScript.Name = "buttonStopScript";
            this.buttonStopScript.Size = new System.Drawing.Size(95, 38);
            this.buttonStopScript.TabIndex = 6;
            this.buttonStopScript.Text = "Stop Script";
            this.buttonStopScript.UseVisualStyleBackColor = true;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(8, 57);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(51, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "Progress:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(8, 76);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1394, 23);
            this.progressBar.TabIndex = 7;
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this.listBoxOutput.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxOutput.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.HorizontalScrollbar = true;
            this.listBoxOutput.Location = new System.Drawing.Point(8, 105);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.ScrollAlwaysVisible = true;
            this.listBoxOutput.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxOutput.Size = new System.Drawing.Size(1394, 641);
            this.listBoxOutput.TabIndex = 1;
            this.listBoxOutput.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBoxOutput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxOutput_MouseDoubleClick);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 771);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sifon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timerOutput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonStopScript;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sitecorePortalCredentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuContainerPlugins;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sendFeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installHostPrerequsitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installSolrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllExistingSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installSQLServerExpressToolStripMenuItem;
    }
}

