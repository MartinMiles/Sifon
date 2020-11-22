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
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Plugins repository:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 5;
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
            this.labelRepository.TabIndex = 3;
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
            this.checkBoxCrashLog.Location = new System.Drawing.Point(10, 29);
            this.checkBoxCrashLog.Name = "checkBoxCrashLog";
            this.checkBoxCrashLog.Size = new System.Drawing.Size(303, 17);
            this.checkBoxCrashLog.TabIndex = 1;
            this.checkBoxCrashLog.Text = "Send anonymous crash logs to developer to improve Sifon ";
            this.checkBoxCrashLog.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(260, 240);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Done";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCrashLog);
            this.groupBox1.Location = new System.Drawing.Point(12, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 74);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other settings:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 279);
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
    }
}