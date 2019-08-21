namespace Sifon.Forms.Backup
{
    partial class Backup
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
            this.components = new System.ComponentModel.Container();
            this.groupBackup = new System.Windows.Forms.GroupBox();
            this.checkCommerce = new System.Windows.Forms.CheckBox();
            this.checkIds = new System.Windows.Forms.CheckBox();
            this.checkXconnect = new System.Windows.Forms.CheckBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.textInstanaceToBackup = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textDestinationFolderToBackup = new System.Windows.Forms.TextBox();
            this.buttonBackupLocation = new System.Windows.Forms.Button();
            this.checkFiles = new System.Windows.Forms.CheckBox();
            this.comboInstances = new System.Windows.Forms.ComboBox();
            this.checkDatabases = new System.Windows.Forms.CheckBox();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listDatabases = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkSelectAll = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBackup
            // 
            this.groupBackup.Controls.Add(this.checkCommerce);
            this.groupBackup.Controls.Add(this.checkIds);
            this.groupBackup.Controls.Add(this.checkXconnect);
            this.groupBackup.Controls.Add(this.label5);
            this.groupBackup.Controls.Add(this.dataGrid);
            this.groupBackup.Controls.Add(this.buttonBackupLocation);
            this.groupBackup.Controls.Add(this.textInstanaceToBackup);
            this.groupBackup.Controls.Add(this.textDestinationFolderToBackup);
            this.groupBackup.Controls.Add(this.label2);
            this.groupBackup.Controls.Add(this.checkFiles);
            this.groupBackup.Controls.Add(this.comboInstances);
            this.groupBackup.Location = new System.Drawing.Point(13, 13);
            this.groupBackup.Name = "groupBackup";
            this.groupBackup.Size = new System.Drawing.Size(290, 343);
            this.groupBackup.TabIndex = 0;
            this.groupBackup.TabStop = false;
            this.groupBackup.Text = "Sitecore instance backup parameters:";
            // 
            // checkCommerce
            // 
            this.checkCommerce.AutoSize = true;
            this.checkCommerce.Enabled = false;
            this.checkCommerce.Location = new System.Drawing.Point(155, 112);
            this.checkCommerce.Name = "checkCommerce";
            this.checkCommerce.Size = new System.Drawing.Size(116, 17);
            this.checkCommerce.TabIndex = 48;
            this.checkCommerce.Text = "Backup Commerce";
            this.checkCommerce.UseVisualStyleBackColor = true;
            // 
            // checkIds
            // 
            this.checkIds.AutoSize = true;
            this.checkIds.Enabled = false;
            this.checkIds.Location = new System.Drawing.Point(155, 89);
            this.checkIds.Name = "checkIds";
            this.checkIds.Size = new System.Drawing.Size(134, 17);
            this.checkIds.TabIndex = 47;
            this.checkIds.Text = "Backup Identity Server";
            this.checkIds.UseVisualStyleBackColor = true;
            // 
            // checkXconnect
            // 
            this.checkXconnect.AutoSize = true;
            this.checkXconnect.Enabled = false;
            this.checkXconnect.Location = new System.Drawing.Point(9, 112);
            this.checkXconnect.Name = "checkXconnect";
            this.checkXconnect.Size = new System.Drawing.Size(140, 17);
            this.checkXconnect.TabIndex = 46;
            this.checkXconnect.Text = "Backup xConnect folder";
            this.checkXconnect.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(9, 216);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.Size = new System.Drawing.Size(273, 110);
            this.dataGrid.TabIndex = 45;
            // 
            // textInstanaceToBackup
            // 
            this.textInstanaceToBackup.AutoSize = true;
            this.textInstanaceToBackup.Location = new System.Drawing.Point(9, 31);
            this.textInstanaceToBackup.Name = "textInstanaceToBackup";
            this.textInstanaceToBackup.Size = new System.Drawing.Size(143, 13);
            this.textInstanaceToBackup.TabIndex = 29;
            this.textInstanaceToBackup.Text = "Sitecore instance to backup:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Binding for the selected instance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Folder to put backup into:";
            // 
            // textDestinationFolderToBackup
            // 
            this.textDestinationFolderToBackup.Location = new System.Drawing.Point(9, 168);
            this.textDestinationFolderToBackup.Name = "textDestinationFolderToBackup";
            this.textDestinationFolderToBackup.Size = new System.Drawing.Size(230, 20);
            this.textDestinationFolderToBackup.TabIndex = 26;
            this.textDestinationFolderToBackup.Validating += new System.ComponentModel.CancelEventHandler(this.textDestinationFolderToBackup_Validating);
            // 
            // buttonBackupLocation
            // 
            this.buttonBackupLocation.Location = new System.Drawing.Point(238, 167);
            this.buttonBackupLocation.Name = "buttonBackupLocation";
            this.buttonBackupLocation.Size = new System.Drawing.Size(41, 22);
            this.buttonBackupLocation.TabIndex = 27;
            this.buttonBackupLocation.Text = "...";
            this.buttonBackupLocation.UseVisualStyleBackColor = true;
            this.buttonBackupLocation.Click += new System.EventHandler(this.buttonBackupLocation_Click);
            // 
            // checkFiles
            // 
            this.checkFiles.AutoSize = true;
            this.checkFiles.Checked = true;
            this.checkFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFiles.Enabled = false;
            this.checkFiles.Location = new System.Drawing.Point(9, 89);
            this.checkFiles.Name = "checkFiles";
            this.checkFiles.Size = new System.Drawing.Size(131, 17);
            this.checkFiles.TabIndex = 11;
            this.checkFiles.Text = "Backup website folder";
            this.checkFiles.UseVisualStyleBackColor = true;
            this.checkFiles.CheckedChanged += new System.EventHandler(this.checkFiles_CheckedChanged);
            // 
            // comboInstances
            // 
            this.comboInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInstances.FormattingEnabled = true;
            this.comboInstances.Location = new System.Drawing.Point(9, 47);
            this.comboInstances.Name = "comboInstances";
            this.comboInstances.Size = new System.Drawing.Size(270, 21);
            this.comboInstances.TabIndex = 7;
            this.comboInstances.SelectedIndexChanged += new System.EventHandler(this.comboInstances_SelectedIndexChanged);
            // 
            // checkDatabases
            // 
            this.checkDatabases.AutoSize = true;
            this.checkDatabases.Location = new System.Drawing.Point(15, 26);
            this.checkDatabases.Name = "checkDatabases";
            this.checkDatabases.Size = new System.Drawing.Size(158, 17);
            this.checkDatabases.TabIndex = 10;
            this.checkDatabases.Text = "Backup selected databases";
            this.checkDatabases.UseVisualStyleBackColor = true;
            this.checkDatabases.CheckedChanged += new System.EventHandler(this.checkDatabases_CheckedChanged);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Enabled = false;
            this.buttonBackup.Location = new System.Drawing.Point(541, 362);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(54, 23);
            this.buttonBackup.TabIndex = 6;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select databases for backup:";
            // 
            // listDatabases
            // 
            this.listDatabases.FormattingEnabled = true;
            this.listDatabases.Location = new System.Drawing.Point(12, 74);
            this.listDatabases.Name = "listDatabases";
            this.listDatabases.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listDatabases.Size = new System.Drawing.Size(263, 251);
            this.listDatabases.TabIndex = 12;
            this.listDatabases.SelectedIndexChanged += new System.EventHandler(this.listDatabases_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkSelectAll);
            this.groupBox1.Controls.Add(this.listDatabases);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkDatabases);
            this.groupBox1.Location = new System.Drawing.Point(314, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 343);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instance databases:";
            // 
            // linkSelectAll
            // 
            this.linkSelectAll.AutoSize = true;
            this.linkSelectAll.Location = new System.Drawing.Point(175, 27);
            this.linkSelectAll.Name = "linkSelectAll";
            this.linkSelectAll.Size = new System.Drawing.Size(100, 13);
            this.linkSelectAll.TabIndex = 14;
            this.linkSelectAll.TabStop = true;
            this.linkSelectAll.Text = "select all databases";
            this.linkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(606, 397);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBackup);
            this.Controls.Add(this.buttonBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup Sitecore instance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Backup_FormClosing);
            this.Load += new System.EventHandler(this.Loaded);
            this.groupBackup.ResumeLayout(false);
            this.groupBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBackup;
        private System.Windows.Forms.CheckBox checkFiles;
        private System.Windows.Forms.CheckBox checkDatabases;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboInstances;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listDatabases;
        private System.Windows.Forms.Label textInstanaceToBackup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textDestinationFolderToBackup;
        private System.Windows.Forms.Button buttonBackupLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkSelectAll;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.CheckBox checkIds;
        private System.Windows.Forms.CheckBox checkXconnect;
        private System.Windows.Forms.CheckBox checkCommerce;
    }
}