namespace Sifon.Shared.Forms.UrlPickerDialog
{
    partial class UrlPicker
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
            this.buttonInstall = new System.Windows.Forms.Button();
            this.UrlTextbox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonInstall
            // 
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(319, 64);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(67, 23);
            this.buttonInstall.TabIndex = 32;
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // UrlTextbox
            // 
            this.UrlTextbox.Location = new System.Drawing.Point(11, 38);
            this.UrlTextbox.MaxLength = 255;
            this.UrlTextbox.Name = "UrlTextbox";
            this.UrlTextbox.Size = new System.Drawing.Size(375, 20);
            this.UrlTextbox.TabIndex = 31;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(12, 19);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(0, 13);
            this.textLabel.TabIndex = 33;
            // 
            // UrlPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 110);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.UrlTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlPicker";
            this.Load += new System.EventHandler(this.UrlPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.TextBox UrlTextbox;
        private System.Windows.Forms.Label textLabel;
    }
}