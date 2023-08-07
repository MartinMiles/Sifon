namespace Sifon.Forms.SQL
{
    partial class InstallSQL
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFolder = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textInstance = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.loadingCircle = new Sifon.UserControls.LoadingCircle();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.loadingCircle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelFolder);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.textInstance);
            this.groupBox1.Controls.Add(this.buttonInstall);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Install new SQL Express instance:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 52;
            this.button1.Text = "Defaults";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.defaultsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "SA password:";
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(19, 24);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(80, 13);
            this.labelFolder.TabIndex = 4;
            this.labelFolder.Text = "Instance name:";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(22, 85);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(144, 20);
            this.textPassword.TabIndex = 25;
            // 
            // textInstance
            // 
            this.textInstance.Location = new System.Drawing.Point(20, 43);
            this.textInstance.Name = "textInstance";
            this.textInstance.Size = new System.Drawing.Size(180, 20);
            this.textInstance.TabIndex = 21;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(220, 83);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(65, 23);
            this.buttonInstall.TabIndex = 26;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.InnerCircleRadius = 5;
            this.loadingCircle.Location = new System.Drawing.Point(166, 83);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.OuterCircleRadius = 11;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(48, 23);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.TabIndex = 51;
            this.loadingCircle.Text = "loadingCircle";
            this.loadingCircle.Visible = false;
            // 
            // InstallSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 155);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallSQL";
            this.Text = "Install SQL Server Express";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.LoadingCircle loadingCircle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textInstance;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button button1;
    }
}