namespace Sifon.Forms.Profiles.UserControls.Parameters
{
    partial class Parameters
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
            this.groupBoxRemote = new System.Windows.Forms.GroupBox();
            this.buttonAddPair = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.linkLabelSampleDownload = new System.Windows.Forms.LinkLabel();
            this.groupBoxRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRemote
            // 
            this.groupBoxRemote.Controls.Add(this.linkLabelSampleDownload);
            this.groupBoxRemote.Controls.Add(this.buttonAddPair);
            this.groupBoxRemote.Controls.Add(this.panel);
            this.groupBoxRemote.Location = new System.Drawing.Point(5, 10);
            this.groupBoxRemote.Name = "groupBoxRemote";
            this.groupBoxRemote.Size = new System.Drawing.Size(305, 295);
            this.groupBoxRemote.TabIndex = 49;
            this.groupBoxRemote.TabStop = false;
            this.groupBoxRemote.Text = "Additional parameters to be passed into scripts and plugins";
            // 
            // buttonAddPair
            // 
            this.buttonAddPair.Location = new System.Drawing.Point(200, 265);
            this.buttonAddPair.Name = "buttonAddPair";
            this.buttonAddPair.Size = new System.Drawing.Size(81, 23);
            this.buttonAddPair.TabIndex = 25;
            this.buttonAddPair.Text = "Add new pair";
            this.buttonAddPair.UseVisualStyleBackColor = true;
            this.buttonAddPair.Click += new System.EventHandler(this.buttonAddPair_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Location = new System.Drawing.Point(6, 19);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(293, 243);
            this.panel.TabIndex = 0;
            // 
            // linkLabelSampleDownload
            // 
            this.linkLabelSampleDownload.AutoSize = true;
            this.linkLabelSampleDownload.Location = new System.Drawing.Point(6, 269);
            this.linkLabelSampleDownload.Name = "linkLabelSampleDownload";
            this.linkLabelSampleDownload.Size = new System.Drawing.Size(191, 13);
            this.linkLabelSampleDownload.TabIndex = 26;
            this.linkLabelSampleDownload.TabStop = true;
            this.linkLabelSampleDownload.Text = "Download script sample with all params";
            this.linkLabelSampleDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxRemote);
            this.Name = "Parameters";
            this.Size = new System.Drawing.Size(317, 305);
            this.groupBoxRemote.ResumeLayout(false);
            this.groupBoxRemote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRemote;
        private System.Windows.Forms.Button buttonAddPair;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.LinkLabel linkLabelSampleDownload;
    }
}
