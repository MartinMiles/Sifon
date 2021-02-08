namespace Sifon.Shared.Forms.LocalFilePickerDialog
{
    partial class LocalFilePicker
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
            this.buttonLocation = new System.Windows.Forms.Button();
            this.pathTextbox = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.textInstanaceToBackup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLocation
            // 
            this.buttonLocation.Location = new System.Drawing.Point(340, 33);
            this.buttonLocation.Name = "buttonLocation";
            this.buttonLocation.Size = new System.Drawing.Size(47, 22);
            this.buttonLocation.TabIndex = 29;
            this.buttonLocation.Text = "...";
            this.buttonLocation.UseVisualStyleBackColor = true;
            this.buttonLocation.Click += new System.EventHandler(this.buttonBackupLocation_Click);
            // 
            // pathTextbox
            // 
            this.pathTextbox.AllowDrop = true;
            this.pathTextbox.Location = new System.Drawing.Point(12, 35);
            this.pathTextbox.MaxLength = 255;
            this.pathTextbox.Name = "pathTextbox";
            this.pathTextbox.Size = new System.Drawing.Size(330, 20);
            this.pathTextbox.TabIndex = 28;
            this.pathTextbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pathTextbox_DragDrop);
            this.pathTextbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pathTextbox_DragEnter);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(340, 61);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(47, 23);
            this.buttonInstall.TabIndex = 30;
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // textInstanaceToBackup
            // 
            this.textInstanaceToBackup.AutoSize = true;
            this.textInstanaceToBackup.Location = new System.Drawing.Point(9, 19);
            this.textInstanaceToBackup.Name = "textInstanaceToBackup";
            this.textInstanaceToBackup.Size = new System.Drawing.Size(0, 13);
            this.textInstanaceToBackup.TabIndex = 31;
            // 
            // LocalFilePicker
            // 
            this.AcceptButton = this.buttonInstall;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 99);
            this.Controls.Add(this.textInstanaceToBackup);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.buttonLocation);
            this.Controls.Add(this.pathTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalFilePicker";
            this.Load += new System.EventHandler(this.Form_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.LocalFilePicker_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.LocalFilePicker_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLocation;
        private System.Windows.Forms.TextBox pathTextbox;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Label textInstanaceToBackup;
    }
}