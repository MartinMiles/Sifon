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
            this.checkBoxCrashLog = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textRepository = new System.Windows.Forms.TextBox();
            this.labelRepository = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.labelRepository);
            this.groupBox.Controls.Add(this.textRepository);
            this.groupBox.Controls.Add(this.checkBoxCrashLog);
            this.groupBox.Controls.Add(this.buttonSave);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(331, 163);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Application settings:";
            // 
            // checkBoxCrashLog
            // 
            this.checkBoxCrashLog.AutoSize = true;
            this.checkBoxCrashLog.Checked = true;
            this.checkBoxCrashLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrashLog.Location = new System.Drawing.Point(17, 28);
            this.checkBoxCrashLog.Name = "checkBoxCrashLog";
            this.checkBoxCrashLog.Size = new System.Drawing.Size(303, 17);
            this.checkBoxCrashLog.TabIndex = 1;
            this.checkBoxCrashLog.Text = "Send anonymous crash logs to developer to improve Sifon ";
            this.checkBoxCrashLog.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(245, 123);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Done";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textRepository
            // 
            this.textRepository.Location = new System.Drawing.Point(17, 84);
            this.textRepository.Name = "textRepository";
            this.textRepository.Size = new System.Drawing.Size(303, 20);
            this.textRepository.TabIndex = 2;
            // 
            // labelRepository
            // 
            this.labelRepository.AutoSize = true;
            this.labelRepository.Location = new System.Drawing.Point(17, 65);
            this.labelRepository.Name = "labelRepository";
            this.labelRepository.Size = new System.Drawing.Size(305, 13);
            this.labelRepository.TabIndex = 3;
            this.labelRepository.Text = "Plugins repository (which gets cloned under the \'Plugins\' menu):";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 187);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxCrashLog;
        private System.Windows.Forms.Label labelRepository;
        private System.Windows.Forms.TextBox textRepository;
    }
}