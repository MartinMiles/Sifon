namespace Sifon.Forms.Updates
{
    partial class CheckUpdates
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkDownload = new System.Windows.Forms.LinkLabel();
            this.labelMain = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkDownload);
            this.groupBox1.Controls.Add(this.labelMain);
            this.groupBox1.Controls.Add(this.buttonCheck);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Checking for the product update:";
            // 
            // linkDownload
            // 
            this.linkDownload.AutoSize = true;
            this.linkDownload.Location = new System.Drawing.Point(19, 53);
            this.linkDownload.Name = "linkDownload";
            this.linkDownload.Size = new System.Drawing.Size(228, 13);
            this.linkDownload.TabIndex = 2;
            this.linkDownload.TabStop = true;
            this.linkDownload.Text = "http://beta.sifon.uk/download/Sifon_0.99a.zip";
            this.linkDownload.Visible = false;
            this.linkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownload_LinkClicked);
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Location = new System.Drawing.Point(19, 28);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(331, 13);
            this.labelMain.TabIndex = 1;
            this.labelMain.Text = "Please click the button below to find out if newer version  is available";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(275, 68);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 0;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // CheckUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 136);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckUpdates";
            this.Text = "Product Upgrade";
            this.Load += new System.EventHandler(this.CheckUpdates_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.LinkLabel linkDownload;
        private System.Windows.Forms.Label labelMain;
    }
}