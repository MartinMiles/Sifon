namespace Sifon.Forms.Prerequsites
{
    partial class Prerequsites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prerequsites));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkSqlServer = new System.Windows.Forms.CheckBox();
            this.checkNetCore = new System.Windows.Forms.CheckBox();
            this.checkSif = new System.Windows.Forms.CheckBox();
            this.checkRemoting = new System.Windows.Forms.CheckBox();
            this.labelCheckResult = new System.Windows.Forms.Label();
            this.checkChocolatey = new System.Windows.Forms.CheckBox();
            this.checkGit = new System.Windows.Forms.CheckBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkSqlServer);
            this.groupBox1.Controls.Add(this.checkNetCore);
            this.groupBox1.Controls.Add(this.checkSif);
            this.groupBox1.Controls.Add(this.checkRemoting);
            this.groupBox1.Controls.Add(this.labelCheckResult);
            this.groupBox1.Controls.Add(this.checkChocolatey);
            this.groupBox1.Controls.Add(this.checkGit);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Host-level preprequites:";
            // 
            // checkSqlServer
            // 
            this.checkSqlServer.AutoSize = true;
            this.checkSqlServer.Location = new System.Drawing.Point(15, 125);
            this.checkSqlServer.Name = "checkSqlServer";
            this.checkSqlServer.Size = new System.Drawing.Size(168, 17);
            this.checkSqlServer.TabIndex = 6;
            this.checkSqlServer.Text = "Sql Server PowerShell module";
            this.checkSqlServer.UseVisualStyleBackColor = true;
            // 
            // checkNetCore
            // 
            this.checkNetCore.AutoSize = true;
            this.checkNetCore.Location = new System.Drawing.Point(15, 148);
            this.checkNetCore.Name = "checkNetCore";
            this.checkNetCore.Size = new System.Drawing.Size(101, 17);
            this.checkNetCore.TabIndex = 5;
            this.checkNetCore.Text = ".NET Core SDK";
            this.checkNetCore.UseVisualStyleBackColor = true;
            // 
            // checkSif
            // 
            this.checkSif.AutoSize = true;
            this.checkSif.Location = new System.Drawing.Point(15, 102);
            this.checkSif.Name = "checkSif";
            this.checkSif.Size = new System.Drawing.Size(207, 17);
            this.checkSif.TabIndex = 4;
            this.checkSif.Text = "Latest Sitecore Install Framework (SIF)";
            this.checkSif.UseVisualStyleBackColor = true;
            // 
            // checkRemoting
            // 
            this.checkRemoting.AutoSize = true;
            this.checkRemoting.Location = new System.Drawing.Point(15, 79);
            this.checkRemoting.Name = "checkRemoting";
            this.checkRemoting.Size = new System.Drawing.Size(182, 17);
            this.checkRemoting.TabIndex = 3;
            this.checkRemoting.Text = "WinRM (for PowerShell remoting)";
            this.checkRemoting.UseVisualStyleBackColor = true;
            // 
            // labelCheckResult
            // 
            this.labelCheckResult.AutoSize = true;
            this.labelCheckResult.Location = new System.Drawing.Point(12, 173);
            this.labelCheckResult.Name = "labelCheckResult";
            this.labelCheckResult.Size = new System.Drawing.Size(0, 13);
            this.labelCheckResult.TabIndex = 3;
            // 
            // checkChocolatey
            // 
            this.checkChocolatey.AutoSize = true;
            this.checkChocolatey.Location = new System.Drawing.Point(16, 33);
            this.checkChocolatey.Name = "checkChocolatey";
            this.checkChocolatey.Size = new System.Drawing.Size(79, 17);
            this.checkChocolatey.TabIndex = 1;
            this.checkChocolatey.Text = "Chocolatey";
            this.checkChocolatey.UseVisualStyleBackColor = true;
            this.checkChocolatey.CheckedChanged += new System.EventHandler(this.checkChocolatey_CheckedChanged);
            // 
            // checkGit
            // 
            this.checkGit.AutoSize = true;
            this.checkGit.Location = new System.Drawing.Point(16, 56);
            this.checkGit.Name = "checkGit";
            this.checkGit.Size = new System.Drawing.Size(131, 17);
            this.checkGit.TabIndex = 2;
            this.checkGit.Text = "Git (for getting plugins)";
            this.checkGit.UseVisualStyleBackColor = true;
            this.checkGit.CheckedChanged += new System.EventHandler(this.checkGit_CheckedChanged);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(137, 282);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 23);
            this.buttonInstall.TabIndex = 6;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.Install_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(10, 228);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(51, 13);
            this.progressLabel.TabIndex = 12;
            this.progressLabel.Text = "Progress:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(13, 244);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(280, 23);
            this.progressBar.TabIndex = 11;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(218, 282);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Prerequsites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 319);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prerequsites";
            this.Text = "Install Prerequsites";
            this.Load += new System.EventHandler(this.Prerequsites_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.CheckBox checkChocolatey;
        private System.Windows.Forms.CheckBox checkGit;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelCheckResult;
        private System.Windows.Forms.CheckBox checkRemoting;
        private System.Windows.Forms.CheckBox checkSif;
        private System.Windows.Forms.CheckBox checkNetCore;
        private System.Windows.Forms.CheckBox checkSqlServer;
    }
}