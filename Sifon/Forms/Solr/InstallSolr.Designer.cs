namespace Sifon.Forms.Solr
{
    partial class InstallSolr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallSolr));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadingCircle = new Sifon.UserControls.LoadingCircle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textFolderSuffix = new System.Windows.Forms.TextBox();
            this.buttonBackupLocation = new System.Windows.Forms.Button();
            this.labelFolder = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.comboVersion = new System.Windows.Forms.ComboBox();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadingCircle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textFolderSuffix);
            this.groupBox1.Controls.Add(this.buttonBackupLocation);
            this.groupBox1.Controls.Add(this.labelFolder);
            this.groupBox1.Controls.Add(this.textPort);
            this.groupBox1.Controls.Add(this.comboVersion);
            this.groupBox1.Controls.Add(this.textFolder);
            this.groupBox1.Controls.Add(this.buttonInstall);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters:";
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.InnerCircleRadius = 5;
            this.loadingCircle.Location = new System.Drawing.Point(136, 83);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.OuterCircleRadius = 11;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(48, 23);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.StylePreset = Sifon.UserControls.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.TabIndex = 51;
            this.loadingCircle.Text = "loadingCircle";
            this.loadingCircle.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Version:";
            // 
            // textFolderSuffix
            // 
            this.textFolderSuffix.Location = new System.Drawing.Point(179, 43);
            this.textFolderSuffix.Name = "textFolderSuffix";
            this.textFolderSuffix.ReadOnly = true;
            this.textFolderSuffix.Size = new System.Drawing.Size(57, 20);
            this.textFolderSuffix.TabIndex = 2;
            // 
            // buttonBackupLocation
            // 
            this.buttonBackupLocation.Location = new System.Drawing.Point(235, 42);
            this.buttonBackupLocation.Name = "buttonBackupLocation";
            this.buttonBackupLocation.Size = new System.Drawing.Size(30, 22);
            this.buttonBackupLocation.TabIndex = 3;
            this.buttonBackupLocation.Text = "...";
            this.buttonBackupLocation.UseVisualStyleBackColor = true;
            this.buttonBackupLocation.Click += new System.EventHandler(this.buttonBackupLocation_Click);
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(19, 24);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(109, 13);
            this.labelFolder.TabIndex = 4;
            this.labelFolder.Text = "Solr installation folder:";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(85, 83);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(45, 20);
            this.textPort.TabIndex = 5;
            // 
            // comboVersion
            // 
            this.comboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVersion.FormattingEnabled = true;
            this.comboVersion.Items.AddRange(new object[] {
            "6.6.2",
            "7.2.1",
            "7.5.0",
            "8.1.1",
            "8.4.0"});
            this.comboVersion.Location = new System.Drawing.Point(19, 83);
            this.comboVersion.Name = "comboVersion";
            this.comboVersion.Size = new System.Drawing.Size(60, 21);
            this.comboVersion.TabIndex = 4;
            this.comboVersion.SelectedIndexChanged += new System.EventHandler(this.comboVersion_SelectedIndexChanged);
            // 
            // textFolder
            // 
            this.textFolder.Location = new System.Drawing.Point(20, 43);
            this.textFolder.Name = "textFolder";
            this.textFolder.Size = new System.Drawing.Size(160, 20);
            this.textFolder.TabIndex = 1;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(200, 83);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(65, 23);
            this.buttonInstall.TabIndex = 6;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.button1_Click);
            // 
            // InstallSolr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 145);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallSolr";
            this.Text = "Install Solr";
            this.Load += new System.EventHandler(this.InstallSolr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.ComboBox comboVersion;
        private System.Windows.Forms.TextBox textFolder;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.TextBox textFolderSuffix;
        private System.Windows.Forms.Button buttonBackupLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UserControls.LoadingCircle loadingCircle;
    }
}