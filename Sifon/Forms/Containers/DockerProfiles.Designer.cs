namespace Sifon.Forms.Containers
{
    partial class DockerProfiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockerProfiles));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkRevealSa = new System.Windows.Forms.LinkLabel();
            this.linkRevealAdmin = new System.Windows.Forms.LinkLabel();
            this.buttonDefaults = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textRepositoryFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textRepositoryUrl = new System.Windows.Forms.TextBox();
            this.linkDelete = new System.Windows.Forms.LinkLabel();
            this.labelAdminPassword = new System.Windows.Forms.Label();
            this.textSaPassword = new System.Windows.Forms.TextBox();
            this.labelAdminUsername = new System.Windows.Forms.Label();
            this.textAdminPassword = new System.Windows.Forms.TextBox();
            this.buttonAddRename = new System.Windows.Forms.Button();
            this.labelProfileName = new System.Windows.Forms.Label();
            this.textProfileName = new System.Windows.Forms.TextBox();
            this.labelCombo = new System.Windows.Forms.Label();
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkRevealSa);
            this.groupBox1.Controls.Add(this.linkRevealAdmin);
            this.groupBox1.Controls.Add(this.buttonDefaults);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textRepositoryFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textRepositoryUrl);
            this.groupBox1.Controls.Add(this.linkDelete);
            this.groupBox1.Controls.Add(this.labelAdminPassword);
            this.groupBox1.Controls.Add(this.textSaPassword);
            this.groupBox1.Controls.Add(this.labelAdminUsername);
            this.groupBox1.Controls.Add(this.textAdminPassword);
            this.groupBox1.Controls.Add(this.buttonAddRename);
            this.groupBox1.Controls.Add(this.labelProfileName);
            this.groupBox1.Controls.Add(this.textProfileName);
            this.groupBox1.Controls.Add(this.labelCombo);
            this.groupBox1.Controls.Add(this.comboProfiles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile details:";
            // 
            // linkRevealSa
            // 
            this.linkRevealSa.AutoSize = true;
            this.linkRevealSa.Location = new System.Drawing.Point(291, 269);
            this.linkRevealSa.Name = "linkRevealSa";
            this.linkRevealSa.Size = new System.Drawing.Size(42, 13);
            this.linkRevealSa.TabIndex = 9;
            this.linkRevealSa.TabStop = true;
            this.linkRevealSa.Text = "(reveal)";
            this.linkRevealSa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRevealSa_LinkClicked);
            // 
            // linkRevealAdmin
            // 
            this.linkRevealAdmin.AutoSize = true;
            this.linkRevealAdmin.Location = new System.Drawing.Point(123, 269);
            this.linkRevealAdmin.Name = "linkRevealAdmin";
            this.linkRevealAdmin.Size = new System.Drawing.Size(42, 13);
            this.linkRevealAdmin.TabIndex = 7;
            this.linkRevealAdmin.TabStop = true;
            this.linkRevealAdmin.Text = "(reveal)";
            this.linkRevealAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRevealAdmin_LinkClicked);
            // 
            // buttonDefaults
            // 
            this.buttonDefaults.Location = new System.Drawing.Point(15, 326);
            this.buttonDefaults.Name = "buttonDefaults";
            this.buttonDefaults.Size = new System.Drawing.Size(80, 22);
            this.buttonDefaults.TabIndex = 10;
            this.buttonDefaults.Text = "Set defaults";
            this.buttonDefaults.UseVisualStyleBackColor = true;
            this.buttonDefaults.Click += new System.EventHandler(this.buttonDefaults_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "GitHub repository folder (if not the root):";
            // 
            // textRepositoryFolder
            // 
            this.textRepositoryFolder.Location = new System.Drawing.Point(15, 216);
            this.textRepositoryFolder.MaxLength = 255;
            this.textRepositoryFolder.Name = "textRepositoryFolder";
            this.textRepositoryFolder.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textRepositoryFolder.Size = new System.Drawing.Size(318, 20);
            this.textRepositoryFolder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "GitHub repository to pull from:";
            // 
            // textRepositoryUrl
            // 
            this.textRepositoryUrl.Location = new System.Drawing.Point(15, 173);
            this.textRepositoryUrl.MaxLength = 255;
            this.textRepositoryUrl.Name = "textRepositoryUrl";
            this.textRepositoryUrl.Size = new System.Drawing.Size(318, 20);
            this.textRepositoryUrl.TabIndex = 4;
            // 
            // linkDelete
            // 
            this.linkDelete.AutoSize = true;
            this.linkDelete.ForeColor = System.Drawing.Color.Red;
            this.linkDelete.LinkColor = System.Drawing.Color.Red;
            this.linkDelete.Location = new System.Drawing.Point(221, 70);
            this.linkDelete.Name = "linkDelete";
            this.linkDelete.Size = new System.Drawing.Size(112, 13);
            this.linkDelete.TabIndex = 2;
            this.linkDelete.TabStop = true;
            this.linkDelete.Text = "Delete selected profile";
            this.linkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDelete_LinkClicked);
            // 
            // labelAdminPassword
            // 
            this.labelAdminPassword.AutoSize = true;
            this.labelAdminPassword.Location = new System.Drawing.Point(180, 269);
            this.labelAdminPassword.Name = "labelAdminPassword";
            this.labelAdminPassword.Size = new System.Drawing.Size(97, 13);
            this.labelAdminPassword.TabIndex = 22;
            this.labelAdminPassword.Text = "SQL \'sa\' password:";
            // 
            // textSaPassword
            // 
            this.textSaPassword.Location = new System.Drawing.Point(183, 285);
            this.textSaPassword.MaxLength = 50;
            this.textSaPassword.Name = "textSaPassword";
            this.textSaPassword.PasswordChar = '*';
            this.textSaPassword.Size = new System.Drawing.Size(150, 20);
            this.textSaPassword.TabIndex = 8;
            // 
            // labelAdminUsername
            // 
            this.labelAdminUsername.AutoSize = true;
            this.labelAdminUsername.Location = new System.Drawing.Point(12, 269);
            this.labelAdminUsername.Name = "labelAdminUsername";
            this.labelAdminUsername.Size = new System.Drawing.Size(87, 13);
            this.labelAdminUsername.TabIndex = 20;
            this.labelAdminUsername.Text = "Admin password:";
            // 
            // textAdminPassword
            // 
            this.textAdminPassword.Location = new System.Drawing.Point(15, 285);
            this.textAdminPassword.MaxLength = 50;
            this.textAdminPassword.Name = "textAdminPassword";
            this.textAdminPassword.PasswordChar = '*';
            this.textAdminPassword.Size = new System.Drawing.Size(150, 20);
            this.textAdminPassword.TabIndex = 6;
            // 
            // buttonAddRename
            // 
            this.buttonAddRename.Location = new System.Drawing.Point(266, 326);
            this.buttonAddRename.Name = "buttonAddRename";
            this.buttonAddRename.Size = new System.Drawing.Size(67, 22);
            this.buttonAddRename.TabIndex = 11;
            this.buttonAddRename.Text = "Rename";
            this.buttonAddRename.UseVisualStyleBackColor = true;
            this.buttonAddRename.Click += new System.EventHandler(this.buttonAddRename_Click);
            // 
            // labelProfileName
            // 
            this.labelProfileName.AutoSize = true;
            this.labelProfileName.Location = new System.Drawing.Point(12, 99);
            this.labelProfileName.Name = "labelProfileName";
            this.labelProfileName.Size = new System.Drawing.Size(68, 13);
            this.labelProfileName.TabIndex = 17;
            this.labelProfileName.Text = "Profile name:";
            // 
            // textProfileName
            // 
            this.textProfileName.Location = new System.Drawing.Point(15, 115);
            this.textProfileName.MaxLength = 127;
            this.textProfileName.Name = "textProfileName";
            this.textProfileName.Size = new System.Drawing.Size(318, 20);
            this.textProfileName.TabIndex = 3;
            // 
            // labelCombo
            // 
            this.labelCombo.AutoSize = true;
            this.labelCombo.Location = new System.Drawing.Point(12, 27);
            this.labelCombo.Name = "labelCombo";
            this.labelCombo.Size = new System.Drawing.Size(83, 13);
            this.labelCombo.TabIndex = 15;
            this.labelCombo.Text = "Selected profile:";
            // 
            // comboProfiles
            // 
            this.comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(15, 43);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(318, 21);
            this.comboProfiles.TabIndex = 1;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // DockerProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 393);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockerProfiles";
            this.Text = "Containers Profiles - (experimental, local only)";
            this.Load += new System.EventHandler(this.DockerProfiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDefaults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRepositoryFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRepositoryUrl;
        private System.Windows.Forms.LinkLabel linkDelete;
        private System.Windows.Forms.Label labelAdminPassword;
        private System.Windows.Forms.TextBox textSaPassword;
        private System.Windows.Forms.Label labelAdminUsername;
        private System.Windows.Forms.TextBox textAdminPassword;
        private System.Windows.Forms.Button buttonAddRename;
        private System.Windows.Forms.Label labelProfileName;
        private System.Windows.Forms.TextBox textProfileName;
        private System.Windows.Forms.Label labelCombo;
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.LinkLabel linkRevealSa;
        private System.Windows.Forms.LinkLabel linkRevealAdmin;
    }
}