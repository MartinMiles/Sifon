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
            this.buttonTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboEditions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboVersions = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.loadingCircle = new Sifon.UserControls.LoadingCircle();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFolder = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textInstance = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboEditions);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboVersions);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.loadingCircle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelFolder);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.textInstance);
            this.groupBox1.Controls.Add(this.buttonInstall);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(600, 494);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Install new SQL Server instance:";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(268, 413);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(6);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(146, 44);
            this.buttonTest.TabIndex = 57;
            this.buttonTest.Text = "Test if exists";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTestIfExists);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 25);
            this.label3.TabIndex = 56;
            this.label3.Text = "SQL Server edition:";
            // 
            // comboEditions
            // 
            this.comboEditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEditions.FormattingEnabled = true;
            this.comboEditions.Location = new System.Drawing.Point(37, 81);
            this.comboEditions.Name = "comboEditions";
            this.comboEditions.Size = new System.Drawing.Size(519, 33);
            this.comboEditions.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 54;
            this.label1.Text = "SQL Server version:";
            // 
            // comboVersions
            // 
            this.comboVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVersions.FormattingEnabled = true;
            this.comboVersions.Location = new System.Drawing.Point(37, 162);
            this.comboVersions.Name = "comboVersions";
            this.comboVersions.Size = new System.Drawing.Size(519, 33);
            this.comboVersions.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 413);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 44);
            this.button1.TabIndex = 30;
            this.button1.Text = "Defaults";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.defaultsButton_Click);
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.InnerCircleRadius = 5;
            this.loadingCircle.Location = new System.Drawing.Point(179, 413);
            this.loadingCircle.Margin = new System.Windows.Forms.Padding(6);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.OuterCircleRadius = 11;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(96, 44);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.StylePreset = Sifon.UserControls.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.TabIndex = 51;
            this.loadingCircle.Text = "loadingCircle";
            this.loadingCircle.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 315);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "SA password:";
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(35, 226);
            this.labelFolder.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(158, 25);
            this.labelFolder.TabIndex = 4;
            this.labelFolder.Text = "Instance name:";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(37, 343);
            this.textPassword.Margin = new System.Windows.Forms.Padding(6);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(519, 31);
            this.textPassword.TabIndex = 25;
            // 
            // textInstance
            // 
            this.textInstance.Location = new System.Drawing.Point(37, 263);
            this.textInstance.Margin = new System.Windows.Forms.Padding(6);
            this.textInstance.Name = "textInstance";
            this.textInstance.Size = new System.Drawing.Size(519, 31);
            this.textInstance.TabIndex = 21;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(426, 413);
            this.buttonInstall.Margin = new System.Windows.Forms.Padding(6);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(130, 44);
            this.buttonInstall.TabIndex = 31;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // InstallSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 540);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallSQL";
            this.Text = "Install local SQL Server";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboEditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboVersions;
        private System.Windows.Forms.Button buttonTest;
    }
}