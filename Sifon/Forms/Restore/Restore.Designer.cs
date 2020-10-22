namespace Sifon.Forms.Restore
{
    partial class Restore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Restore));
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.checkHorizon = new System.Windows.Forms.CheckBox();
            this.checkPublishing = new System.Windows.Forms.CheckBox();
            this.checkDatabases = new System.Windows.Forms.CheckBox();
            this.checkCommerce = new System.Windows.Forms.CheckBox();
            this.textSourceFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listDatabases = new System.Windows.Forms.ListBox();
            this.linkSelectAll = new System.Windows.Forms.LinkLabel();
            this.buttonBackupLocation = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkIdentity = new System.Windows.Forms.CheckBox();
            this.checkFiles = new System.Windows.Forms.CheckBox();
            this.checkXconnect = new System.Windows.Forms.CheckBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.groupGrid = new System.Windows.Forms.GroupBox();
            this.groupParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupParameters
            // 
            this.groupParameters.Controls.Add(this.checkHorizon);
            this.groupParameters.Controls.Add(this.checkPublishing);
            this.groupParameters.Controls.Add(this.checkDatabases);
            this.groupParameters.Controls.Add(this.checkCommerce);
            this.groupParameters.Controls.Add(this.textSourceFolder);
            this.groupParameters.Controls.Add(this.label4);
            this.groupParameters.Controls.Add(this.listDatabases);
            this.groupParameters.Controls.Add(this.linkSelectAll);
            this.groupParameters.Controls.Add(this.buttonBackupLocation);
            this.groupParameters.Controls.Add(this.buttonRestore);
            this.groupParameters.Controls.Add(this.label5);
            this.groupParameters.Controls.Add(this.checkIdentity);
            this.groupParameters.Controls.Add(this.checkFiles);
            this.groupParameters.Controls.Add(this.checkXconnect);
            this.groupParameters.Location = new System.Drawing.Point(13, 13);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(615, 306);
            this.groupParameters.TabIndex = 0;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Restore databases and site files from an archive folder:";
            // 
            // checkHorizon
            // 
            this.checkHorizon.AutoSize = true;
            this.checkHorizon.Enabled = false;
            this.checkHorizon.Location = new System.Drawing.Point(22, 166);
            this.checkHorizon.Name = "checkHorizon";
            this.checkHorizon.Size = new System.Drawing.Size(102, 17);
            this.checkHorizon.TabIndex = 60;
            this.checkHorizon.Text = "Restore Horizon";
            this.checkHorizon.UseVisualStyleBackColor = true;
            // 
            // checkPublishing
            // 
            this.checkPublishing.AutoSize = true;
            this.checkPublishing.Enabled = false;
            this.checkPublishing.Location = new System.Drawing.Point(22, 189);
            this.checkPublishing.Name = "checkPublishing";
            this.checkPublishing.Size = new System.Drawing.Size(153, 17);
            this.checkPublishing.TabIndex = 59;
            this.checkPublishing.Text = "Restore Publishing Service";
            this.checkPublishing.UseVisualStyleBackColor = true;
            // 
            // checkDatabases
            // 
            this.checkDatabases.AutoSize = true;
            this.checkDatabases.Enabled = false;
            this.checkDatabases.Location = new System.Drawing.Point(324, 26);
            this.checkDatabases.Name = "checkDatabases";
            this.checkDatabases.Size = new System.Drawing.Size(158, 17);
            this.checkDatabases.TabIndex = 35;
            this.checkDatabases.Text = "Restore selected databases";
            this.checkDatabases.UseVisualStyleBackColor = true;
            this.checkDatabases.CheckedChanged += new System.EventHandler(this.checkDatabases_CheckedChanged);
            // 
            // checkCommerce
            // 
            this.checkCommerce.AutoSize = true;
            this.checkCommerce.Enabled = false;
            this.checkCommerce.Location = new System.Drawing.Point(22, 212);
            this.checkCommerce.Name = "checkCommerce";
            this.checkCommerce.Size = new System.Drawing.Size(182, 17);
            this.checkCommerce.TabIndex = 58;
            this.checkCommerce.Text = "Restore Sitecore Commerce sites";
            this.checkCommerce.UseVisualStyleBackColor = true;
            // 
            // textSourceFolder
            // 
            this.textSourceFolder.Location = new System.Drawing.Point(23, 51);
            this.textSourceFolder.Name = "textSourceFolder";
            this.textSourceFolder.Size = new System.Drawing.Size(234, 20);
            this.textSourceFolder.TabIndex = 50;
            this.textSourceFolder.TextChanged += new System.EventHandler(this.textSourceFolder_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Tip: requires index rebuild after restore";
            // 
            // listDatabases
            // 
            this.listDatabases.FormattingEnabled = true;
            this.listDatabases.Location = new System.Drawing.Point(324, 49);
            this.listDatabases.Name = "listDatabases";
            this.listDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listDatabases.Size = new System.Drawing.Size(273, 238);
            this.listDatabases.TabIndex = 32;
            this.listDatabases.SelectedIndexChanged += new System.EventHandler(this.listDatabases_SelectedIndexChanged);
            // 
            // linkSelectAll
            // 
            this.linkSelectAll.AutoSize = true;
            this.linkSelectAll.Location = new System.Drawing.Point(497, 27);
            this.linkSelectAll.Name = "linkSelectAll";
            this.linkSelectAll.Size = new System.Drawing.Size(100, 13);
            this.linkSelectAll.TabIndex = 40;
            this.linkSelectAll.TabStop = true;
            this.linkSelectAll.Text = "select all databases";
            this.linkSelectAll.Visible = false;
            this.linkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonBackupLocation
            // 
            this.buttonBackupLocation.Location = new System.Drawing.Point(255, 50);
            this.buttonBackupLocation.Name = "buttonBackupLocation";
            this.buttonBackupLocation.Size = new System.Drawing.Size(41, 22);
            this.buttonBackupLocation.TabIndex = 51;
            this.buttonBackupLocation.Text = "...";
            this.buttonBackupLocation.UseVisualStyleBackColor = true;
            this.buttonBackupLocation.Click += new System.EventHandler(this.buttonBackupLocation_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Enabled = false;
            this.buttonRestore.Location = new System.Drawing.Point(221, 264);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 23);
            this.buttonRestore.TabIndex = 53;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Folder to restore from:";
            // 
            // checkIdentity
            // 
            this.checkIdentity.AutoSize = true;
            this.checkIdentity.Enabled = false;
            this.checkIdentity.Location = new System.Drawing.Point(22, 143);
            this.checkIdentity.Name = "checkIdentity";
            this.checkIdentity.Size = new System.Drawing.Size(202, 17);
            this.checkIdentity.TabIndex = 57;
            this.checkIdentity.Text = "Restore Identity Server website folder";
            this.checkIdentity.UseVisualStyleBackColor = true;
            // 
            // checkFiles
            // 
            this.checkFiles.AutoSize = true;
            this.checkFiles.Enabled = false;
            this.checkFiles.Location = new System.Drawing.Point(23, 97);
            this.checkFiles.Name = "checkFiles";
            this.checkFiles.Size = new System.Drawing.Size(173, 17);
            this.checkFiles.TabIndex = 54;
            this.checkFiles.Text = "Restore Sitecore website folder";
            this.checkFiles.UseVisualStyleBackColor = true;
            this.checkFiles.CheckedChanged += new System.EventHandler(this.checkFiles_CheckedChanged);
            // 
            // checkXconnect
            // 
            this.checkXconnect.AutoSize = true;
            this.checkXconnect.Enabled = false;
            this.checkXconnect.Location = new System.Drawing.Point(22, 120);
            this.checkXconnect.Name = "checkXconnect";
            this.checkXconnect.Size = new System.Drawing.Size(162, 17);
            this.checkXconnect.TabIndex = 56;
            this.checkXconnect.Text = "Restore xConnect site frolder";
            this.checkXconnect.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(11, 31);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.Size = new System.Drawing.Size(586, 199);
            this.dataGrid.TabIndex = 47;
            // 
            // groupGrid
            // 
            this.groupGrid.Controls.Add(this.dataGrid);
            this.groupGrid.Location = new System.Drawing.Point(13, 337);
            this.groupGrid.Name = "groupGrid";
            this.groupGrid.Size = new System.Drawing.Size(615, 247);
            this.groupGrid.TabIndex = 49;
            this.groupGrid.TabStop = false;
            this.groupGrid.Text = "Archived backups:";
            // 
            // Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 590);
            this.Controls.Add(this.groupGrid);
            this.Controls.Add(this.groupParameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Restore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restore Sitecore instance";
            this.Load += new System.EventHandler(this.Restore_Load);
            this.groupParameters.ResumeLayout(false);
            this.groupParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupParameters;
        private System.Windows.Forms.ListBox listDatabases;
        private System.Windows.Forms.CheckBox checkDatabases;
        private System.Windows.Forms.LinkLabel linkSelectAll;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.CheckBox checkCommerce;
        private System.Windows.Forms.TextBox textSourceFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBackupLocation;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkIdentity;
        private System.Windows.Forms.CheckBox checkFiles;
        private System.Windows.Forms.CheckBox checkXconnect;
        private System.Windows.Forms.GroupBox groupGrid;
        private System.Windows.Forms.CheckBox checkHorizon;
        private System.Windows.Forms.CheckBox checkPublishing;
    }
}