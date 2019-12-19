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
            this.labelWarn3 = new System.Windows.Forms.Label();
            this.labelWarn2 = new System.Windows.Forms.Label();
            this.labelWarn1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textPrefix = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textProfileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelWarn3);
            this.groupBox1.Controls.Add(this.labelWarn2);
            this.groupBox1.Controls.Add(this.labelWarn1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textPrefix);
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.buttonRename);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textProfileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboProfiles);
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 295);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profiles:";
            // 
            // labelWarn3
            // 
            this.labelWarn3.AutoSize = true;
            this.labelWarn3.ForeColor = System.Drawing.Color.Red;
            this.labelWarn3.Location = new System.Drawing.Point(16, 244);
            this.labelWarn3.Name = "labelWarn3";
            this.labelWarn3.Size = new System.Drawing.Size(276, 13);
            this.labelWarn3.TabIndex = 11;
            this.labelWarn3.Text = "as well as other parameters before the first run and save !";
            // 
            // labelWarn2
            // 
            this.labelWarn2.AutoSize = true;
            this.labelWarn2.ForeColor = System.Drawing.Color.Red;
            this.labelWarn2.Location = new System.Drawing.Point(16, 228);
            this.labelWarn2.Name = "labelWarn2";
            this.labelWarn2.Size = new System.Drawing.Size(279, 13);
            this.labelWarn2.TabIndex = 10;
            this.labelWarn2.Text = "Please change the profile name, prefix, website root folder";
            // 
            // labelWarn1
            // 
            this.labelWarn1.AutoSize = true;
            this.labelWarn1.ForeColor = System.Drawing.Color.Red;
            this.labelWarn1.Location = new System.Drawing.Point(16, 209);
            this.labelWarn1.Name = "labelWarn1";
            this.labelWarn1.Size = new System.Drawing.Size(63, 13);
            this.labelWarn1.TabIndex = 9;
            this.labelWarn1.Text = "WARNING!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Prefix:";
            // 
            // textPrefix
            // 
            this.textPrefix.Location = new System.Drawing.Point(19, 166);
            this.textPrefix.Name = "textPrefix";
            this.textPrefix.Size = new System.Drawing.Size(190, 20);
            this.textPrefix.TabIndex = 4;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(217, 165);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(67, 22);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(217, 116);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(67, 22);
            this.buttonRename.TabIndex = 5;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name:";
            // 
            // textProfileName
            // 
            this.textProfileName.Location = new System.Drawing.Point(19, 117);
            this.textProfileName.Name = "textProfileName";
            this.textProfileName.Size = new System.Drawing.Size(190, 20);
            this.textProfileName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected profile:";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPrefix;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textProfileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.Label labelWarn2;
        private System.Windows.Forms.Label labelWarn1;
        private System.Windows.Forms.Label labelWarn3;
    }
}
