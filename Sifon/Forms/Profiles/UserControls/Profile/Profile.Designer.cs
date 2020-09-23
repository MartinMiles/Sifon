namespace Sifon.Forms.Profiles.UserControls.Profile
{
    partial class Profile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkDelete = new System.Windows.Forms.LinkLabel();
            this.labelAdminPassword = new System.Windows.Forms.Label();
            this.textAdminPassword = new System.Windows.Forms.TextBox();
            this.labelAdminUsername = new System.Windows.Forms.Label();
            this.textAdminUsername = new System.Windows.Forms.TextBox();
            this.labelPrefix = new System.Windows.Forms.Label();
            this.textPrefix = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.labelProfileName = new System.Windows.Forms.Label();
            this.textProfileName = new System.Windows.Forms.TextBox();
            this.labelCombo = new System.Windows.Forms.Label();
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkDelete);
            this.groupBox1.Controls.Add(this.labelAdminPassword);
            this.groupBox1.Controls.Add(this.textAdminPassword);
            this.groupBox1.Controls.Add(this.labelAdminUsername);
            this.groupBox1.Controls.Add(this.textAdminUsername);
            this.groupBox1.Controls.Add(this.labelPrefix);
            this.groupBox1.Controls.Add(this.textPrefix);
            this.groupBox1.Controls.Add(this.buttonRename);
            this.groupBox1.Controls.Add(this.labelProfileName);
            this.groupBox1.Controls.Add(this.textProfileName);
            this.groupBox1.Controls.Add(this.labelCombo);
            this.groupBox1.Controls.Add(this.comboProfiles);
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 295);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profiles:";
            // 
            // linkDelete
            // 
            this.linkDelete.AutoSize = true;
            this.linkDelete.ForeColor = System.Drawing.Color.Red;
            this.linkDelete.LinkColor = System.Drawing.Color.Red;
            this.linkDelete.Location = new System.Drawing.Point(16, 255);
            this.linkDelete.Name = "linkDelete";
            this.linkDelete.Size = new System.Drawing.Size(112, 13);
            this.linkDelete.TabIndex = 13;
            this.linkDelete.TabStop = true;
            this.linkDelete.Text = "Delete selected profile";
            this.linkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelAdminPassword
            // 
            this.labelAdminPassword.AutoSize = true;
            this.labelAdminPassword.Location = new System.Drawing.Point(156, 193);
            this.labelAdminPassword.Name = "labelAdminPassword";
            this.labelAdminPassword.Size = new System.Drawing.Size(87, 13);
            this.labelAdminPassword.TabIndex = 12;
            this.labelAdminPassword.Text = "Admin password:";
            // 
            // textAdminPassword
            // 
            this.textAdminPassword.Location = new System.Drawing.Point(159, 209);
            this.textAdminPassword.Name = "textAdminPassword";
            this.textAdminPassword.PasswordChar = '*';
            this.textAdminPassword.Size = new System.Drawing.Size(125, 20);
            this.textAdminPassword.TabIndex = 11;
            // 
            // labelAdminUsername
            // 
            this.labelAdminUsername.AutoSize = true;
            this.labelAdminUsername.Location = new System.Drawing.Point(16, 193);
            this.labelAdminUsername.Name = "labelAdminUsername";
            this.labelAdminUsername.Size = new System.Drawing.Size(88, 13);
            this.labelAdminUsername.TabIndex = 10;
            this.labelAdminUsername.Text = "Admin username:";
            // 
            // textAdminUsername
            // 
            this.textAdminUsername.Location = new System.Drawing.Point(19, 209);
            this.textAdminUsername.Name = "textAdminUsername";
            this.textAdminUsername.Size = new System.Drawing.Size(125, 20);
            this.textAdminUsername.TabIndex = 9;
            // 
            // labelPrefix
            // 
            this.labelPrefix.AutoSize = true;
            this.labelPrefix.Location = new System.Drawing.Point(16, 138);
            this.labelPrefix.Name = "labelPrefix";
            this.labelPrefix.Size = new System.Drawing.Size(120, 13);
            this.labelPrefix.TabIndex = 8;
            this.labelPrefix.Text = "Sitecore instance prefix:";
            // 
            // textPrefix
            // 
            this.textPrefix.Location = new System.Drawing.Point(19, 154);
            this.textPrefix.Name = "textPrefix";
            this.textPrefix.Size = new System.Drawing.Size(265, 20);
            this.textPrefix.TabIndex = 4;
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(217, 250);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(67, 22);
            this.buttonRename.TabIndex = 5;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // labelProfileName
            // 
            this.labelProfileName.AutoSize = true;
            this.labelProfileName.Location = new System.Drawing.Point(16, 89);
            this.labelProfileName.Name = "labelProfileName";
            this.labelProfileName.Size = new System.Drawing.Size(68, 13);
            this.labelProfileName.TabIndex = 4;
            this.labelProfileName.Text = "Profile name:";
            // 
            // textProfileName
            // 
            this.textProfileName.Location = new System.Drawing.Point(19, 105);
            this.textProfileName.Name = "textProfileName";
            this.textProfileName.Size = new System.Drawing.Size(265, 20);
            this.textProfileName.TabIndex = 3;
            // 
            // labelCombo
            // 
            this.labelCombo.AutoSize = true;
            this.labelCombo.Location = new System.Drawing.Point(16, 29);
            this.labelCombo.Name = "labelCombo";
            this.labelCombo.Size = new System.Drawing.Size(83, 13);
            this.labelCombo.TabIndex = 2;
            this.labelCombo.Text = "Selected profile:";
            // 
            // comboProfiles
            // 
            this.comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(19, 45);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(265, 21);
            this.comboProfiles.TabIndex = 0;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Profile";
            this.Size = new System.Drawing.Size(314, 311);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPrefix;
        private System.Windows.Forms.TextBox textPrefix;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Label labelProfileName;
        private System.Windows.Forms.TextBox textProfileName;
        private System.Windows.Forms.Label labelCombo;
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.Label labelAdminPassword;
        private System.Windows.Forms.TextBox textAdminPassword;
        private System.Windows.Forms.Label labelAdminUsername;
        private System.Windows.Forms.TextBox textAdminUsername;
        private System.Windows.Forms.LinkLabel linkDelete;
    }
}
