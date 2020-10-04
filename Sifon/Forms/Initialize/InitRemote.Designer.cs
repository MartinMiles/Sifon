namespace Sifon.Forms.Initialize
{
    partial class InitRemote
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
            this.resultHeading = new System.Windows.Forms.Label();
            this.labelModuleRemoteFolder = new System.Windows.Forms.Label();
            this.labelScriptsRemoteFolder = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // resultHeading
            // 
            this.resultHeading.AutoSize = true;
            this.resultHeading.Location = new System.Drawing.Point(12, 15);
            this.resultHeading.Name = "resultHeading";
            this.resultHeading.Size = new System.Drawing.Size(236, 13);
            this.resultHeading.TabIndex = 15;
            this.resultHeading.Text = "Copying the required files to a remote machine ...";
            // 
            // labelModuleRemoteFolder
            // 
            this.labelModuleRemoteFolder.AutoSize = true;
            this.labelModuleRemoteFolder.Location = new System.Drawing.Point(30, 65);
            this.labelModuleRemoteFolder.Name = "labelModuleRemoteFolder";
            this.labelModuleRemoteFolder.Size = new System.Drawing.Size(0, 13);
            this.labelModuleRemoteFolder.TabIndex = 14;
            // 
            // labelScriptsRemoteFolder
            // 
            this.labelScriptsRemoteFolder.AutoSize = true;
            this.labelScriptsRemoteFolder.Location = new System.Drawing.Point(30, 45);
            this.labelScriptsRemoteFolder.Name = "labelScriptsRemoteFolder";
            this.labelScriptsRemoteFolder.Size = new System.Drawing.Size(0, 13);
            this.labelScriptsRemoteFolder.TabIndex = 13;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 159);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(95, 13);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Aceess remote OK";
            // 
            // buttonDone
            // 
            this.buttonDone.Enabled = false;
            this.buttonDone.Location = new System.Drawing.Point(423, 159);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 11;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.done_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 97);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(51, 13);
            this.progressLabel.TabIndex = 10;
            this.progressLabel.Text = "Progress:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(15, 113);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(484, 23);
            this.progressBar.TabIndex = 9;
            // 
            // InitRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 197);
            this.Controls.Add(this.resultHeading);
            this.Controls.Add(this.labelModuleRemoteFolder);
            this.Controls.Add(this.labelScriptsRemoteFolder);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitRemote";
            this.Load += new System.EventHandler(this.InitRemote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelScriptsRemoteFolder;
        private System.Windows.Forms.Label labelModuleRemoteFolder;
        private System.Windows.Forms.Label resultHeading;
    }
}