namespace Sifon.Forms.SettingsForm
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBranching = new System.Windows.Forms.ComboBox();
            this.labelRepository = new System.Windows.Forms.Label();
            this.textRepository = new System.Windows.Forms.TextBox();
            this.checkBoxCrashLog = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkDownloadCDN = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkFindMore = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCustomPluginsLocation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textCustomPluginsFolder = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.comboBranching);
            this.groupBox.Controls.Add(this.labelRepository);
            this.groupBox.Controls.Add(this.textRepository);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(323, 133);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Plugins repository:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Repository branching policy:";
            // 
            // comboBranching
            // 
            this.comboBranching.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBranching.FormattingEnabled = true;
            this.comboBranching.Location = new System.Drawing.Point(10, 91);
            this.comboBranching.Name = "comboBranching";
            this.comboBranching.Size = new System.Drawing.Size(300, 21);
            this.comboBranching.TabIndex = 4;
            // 
            // labelRepository
            // 
            this.labelRepository.AutoSize = true;
            this.labelRepository.Location = new System.Drawing.Point(10, 25);
            this.labelRepository.Name = "labelRepository";
            this.labelRepository.Size = new System.Drawing.Size(305, 13);
            this.labelRepository.TabIndex = 1;
            this.labelRepository.Text = "Plugins repository (which gets cloned under the \'Plugins\' menu):";
            // 
            // textRepository
            // 
            this.textRepository.Location = new System.Drawing.Point(10, 44);
            this.textRepository.Name = "textRepository";
            this.textRepository.Size = new System.Drawing.Size(300, 20);
            this.textRepository.TabIndex = 2;
            // 
            // checkBoxCrashLog
            // 
            this.checkBoxCrashLog.AutoSize = true;
            this.checkBoxCrashLog.Checked = true;
            this.checkBoxCrashLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrashLog.Location = new System.Drawing.Point(10, 26);
            this.checkBoxCrashLog.Name = "checkBoxCrashLog";
            this.checkBoxCrashLog.Size = new System.Drawing.Size(303, 17);
            this.checkBoxCrashLog.TabIndex = 31;
            this.checkBoxCrashLog.Text = "Send anonymous crash logs to developer to improve Sifon ";
            this.checkBoxCrashLog.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(260, 378);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Done";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkDownloadCDN);
            this.groupBox1.Controls.Add(this.checkBoxCrashLog);
            this.groupBox1.Location = new System.Drawing.Point(12, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other settings:";
            // 
            // checkDownloadCDN
            // 
            this.checkDownloadCDN.AutoSize = true;
            this.checkDownloadCDN.Checked = true;
            this.checkDownloadCDN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDownloadCDN.Location = new System.Drawing.Point(10, 49);
            this.checkDownloadCDN.Name = "checkDownloadCDN";
            this.checkDownloadCDN.Size = new System.Drawing.Size(300, 17);
            this.checkDownloadCDN.TabIndex = 32;
            this.checkDownloadCDN.Text = "Use Sitecore GEO-distributed CDN to download resources";
            this.checkDownloadCDN.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkFindMore);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonCustomPluginsLocation);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textCustomPluginsFolder);
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 133);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Non-shared user plugins folder:";
            // 
            // linkFindMore
            // 
            this.linkFindMore.AutoSize = true;
            this.linkFindMore.Location = new System.Drawing.Point(153, 79);
            this.linkFindMore.Name = "linkFindMore";
            this.linkFindMore.Size = new System.Drawing.Size(160, 13);
            this.linkFindMore.TabIndex = 21;
            this.linkFindMore.TabStop = true;
            this.linkFindMore.Text = "(click to find out how that works)";
            this.linkFindMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "control this folder on your own.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "with Sifon, but do not want to share. Of course you may source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "a local folder at your machine with plugins you may want using ";
            // 
            // buttonCustomPluginsLocation
            // 
            this.buttonCustomPluginsLocation.Location = new System.Drawing.Point(277, 98);
            this.buttonCustomPluginsLocation.Name = "buttonCustomPluginsLocation";
            this.buttonCustomPluginsLocation.Size = new System.Drawing.Size(30, 22);
            this.buttonCustomPluginsLocation.TabIndex = 23;
            this.buttonCustomPluginsLocation.Text = "...";
            this.buttonCustomPluginsLocation.UseVisualStyleBackColor = true;
            this.buttonCustomPluginsLocation.Click += new System.EventHandler(this.buttonCustomPluginsLocation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "In addition to a plugin repository, you may also want specifying";
            // 
            // textCustomPluginsFolder
            // 
            this.textCustomPluginsFolder.Location = new System.Drawing.Point(7, 99);
            this.textCustomPluginsFolder.Name = "textCustomPluginsFolder";
            this.textCustomPluginsFolder.Size = new System.Drawing.Size(272, 20);
            this.textCustomPluginsFolder.TabIndex = 22;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 413);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxCrashLog;
        private System.Windows.Forms.Label labelRepository;
        private System.Windows.Forms.TextBox textRepository;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBranching;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCustomPluginsFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCustomPluginsLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkFindMore;
        private System.Windows.Forms.CheckBox checkDownloadCDN;
    }
}