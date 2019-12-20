namespace Sifon.Forms.Profiles.UserControls.Remote
{
    partial class Remote
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
            this.buttonTest = new System.Windows.Forms.Button();
            this.textRemoteFolder = new System.Windows.Forms.TextBox();
            this.labelRemoteFolder = new System.Windows.Forms.Label();
            this.buttonInitialize = new System.Windows.Forms.Button();
            this.checkBoxRemote = new System.Windows.Forms.CheckBox();
            this.textHostname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.linkReveal = new System.Windows.Forms.LinkLabel();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRemote
            // 
            this.groupBoxRemote.Controls.Add(this.buttonTest);
            this.groupBoxRemote.Controls.Add(this.textRemoteFolder);
            this.groupBoxRemote.Controls.Add(this.labelRemoteFolder);
            this.groupBoxRemote.Controls.Add(this.buttonInitialize);
            this.groupBoxRemote.Controls.Add(this.checkBoxRemote);
            this.groupBoxRemote.Controls.Add(this.textHostname);
            this.groupBoxRemote.Controls.Add(this.label10);
            this.groupBoxRemote.Controls.Add(this.linkReveal);
            this.groupBoxRemote.Controls.Add(this.textPassword);
            this.groupBoxRemote.Controls.Add(this.label7);
            this.groupBoxRemote.Controls.Add(this.textUsername);
            this.groupBoxRemote.Controls.Add(this.label8);
            this.groupBoxRemote.Location = new System.Drawing.Point(5, 10);
            this.groupBoxRemote.Name = "groupBoxRemote";
            this.groupBoxRemote.Size = new System.Drawing.Size(305, 295);
            this.groupBoxRemote.TabIndex = 48;
            this.groupBoxRemote.TabStop = false;
            this.groupBoxRemote.Text = "PowerShell remoting settings:";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(119, 259);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 7;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textRemoteFolder
            // 
            this.textRemoteFolder.Enabled = false;
            this.textRemoteFolder.Location = new System.Drawing.Point(20, 222);
            this.textRemoteFolder.Name = "textRemoteFolder";
            this.textRemoteFolder.Size = new System.Drawing.Size(256, 20);
            this.textRemoteFolder.TabIndex = 6;
            // 
            // labelRemoteFolder
            // 
            this.labelRemoteFolder.AutoSize = true;
            this.labelRemoteFolder.Location = new System.Drawing.Point(19, 206);
            this.labelRemoteFolder.Name = "labelRemoteFolder";
            this.labelRemoteFolder.Size = new System.Drawing.Size(0, 13);
            this.labelRemoteFolder.TabIndex = 26;
            // 
            // buttonInitialize
            // 
            this.buttonInitialize.Location = new System.Drawing.Point(200, 259);
            this.buttonInitialize.Name = "buttonInitialize";
            this.buttonInitialize.Size = new System.Drawing.Size(75, 23);
            this.buttonInitialize.TabIndex = 8;
            this.buttonInitialize.Text = "Initialize";
            this.buttonInitialize.UseVisualStyleBackColor = true;
            this.buttonInitialize.Click += new System.EventHandler(this.buttonInitialize_Click);
            // 
            // checkBoxRemote
            // 
            this.checkBoxRemote.AutoSize = true;
            this.checkBoxRemote.Location = new System.Drawing.Point(20, 29);
            this.checkBoxRemote.Name = "checkBoxRemote";
            this.checkBoxRemote.Size = new System.Drawing.Size(165, 17);
            this.checkBoxRemote.TabIndex = 1;
            this.checkBoxRemote.Text = "This profile executes remotely";
            this.checkBoxRemote.UseVisualStyleBackColor = true;
            this.checkBoxRemote.CheckedChanged += new System.EventHandler(this.checkBoxRemote_CheckedChanged);
            // 
            // textHostname
            // 
            this.textHostname.Location = new System.Drawing.Point(20, 76);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(256, 20);
            this.textHostname.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Remote host:";
            // 
            // linkReveal
            // 
            this.linkReveal.AutoSize = true;
            this.linkReveal.Location = new System.Drawing.Point(236, 156);
            this.linkReveal.Name = "linkReveal";
            this.linkReveal.Size = new System.Drawing.Size(42, 13);
            this.linkReveal.TabIndex = 5;
            this.linkReveal.TabStop = true;
            this.linkReveal.Text = "(reveal)";
            this.linkReveal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReveal_LinkClicked);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(22, 173);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(254, 20);
            this.textPassword.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Password:";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(20, 124);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(256, 20);
            this.textUsername.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Username:";
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxRemote);
            this.Name = "Remote";
            this.Size = new System.Drawing.Size(319, 307);
            this.groupBoxRemote.ResumeLayout(false);
            this.groupBoxRemote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRemote;
        public System.Windows.Forms.TextBox textHostname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel linkReveal;
        public System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxRemote;
        private System.Windows.Forms.Button buttonInitialize;
        public System.Windows.Forms.TextBox textRemoteFolder;
        private System.Windows.Forms.Label labelRemoteFolder;
        private System.Windows.Forms.Button buttonTest;
    }
}
