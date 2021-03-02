namespace Sifon.Forms.Install
{
    partial class Install
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.revealSitecoreAdminPassword = new System.Windows.Forms.LinkLabel();
            this.adminPasswordText = new System.Windows.Forms.TextBox();
            this.textDestinationFolder = new System.Windows.Forms.TextBox();
            this.targetFolderButton = new System.Windows.Forms.Button();
            this.licenseFileButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.licenseTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.createSifonProfile = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sitecoreSiteLabel = new System.Windows.Forms.Label();
            this.sitecoreSiteText = new System.Windows.Forms.TextBox();
            this.identityServerLabel = new System.Windows.Forms.Label();
            this.identityServerText = new System.Windows.Forms.TextBox();
            this.xconnectLabel = new System.Windows.Forms.Label();
            this.xconnectText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.prefixText = new System.Windows.Forms.TextBox();
            this.SQLGroupbox = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.sqlServerPasswordText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sqlServerUsernameText = new System.Windows.Forms.TextBox();
            this.sqlServerLabel = new System.Windows.Forms.Label();
            this.sqlServerText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.solrRootFolderText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.solrServiceLabel = new System.Windows.Forms.Label();
            this.solrServiceText = new System.Windows.Forms.TextBox();
            this.solrUrlLabel = new System.Windows.Forms.Label();
            this.solrUrlText = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonTestRemoting = new System.Windows.Forms.Button();
            this.checkBoxRemote = new System.Windows.Forms.CheckBox();
            this.textHostname = new System.Windows.Forms.TextBox();
            this.labelHostname = new System.Windows.Forms.Label();
            this.linkRevealRemoting = new System.Windows.Forms.LinkLabel();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.installPrerequisites = new System.Windows.Forms.CheckBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.comboVersions = new System.Windows.Forms.ComboBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SQLGroupbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.revealSitecoreAdminPassword);
            this.groupBox3.Controls.Add(this.adminPasswordText);
            this.groupBox3.Controls.Add(this.textDestinationFolder);
            this.groupBox3.Controls.Add(this.targetFolderButton);
            this.groupBox3.Controls.Add(this.licenseFileButton);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.licenseTextbox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(309, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 218);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instance";
            // 
            // revealSitecoreAdminPassword
            // 
            this.revealSitecoreAdminPassword.AutoSize = true;
            this.revealSitecoreAdminPassword.Location = new System.Drawing.Point(179, 141);
            this.revealSitecoreAdminPassword.Name = "revealSitecoreAdminPassword";
            this.revealSitecoreAdminPassword.Size = new System.Drawing.Size(42, 13);
            this.revealSitecoreAdminPassword.TabIndex = 33;
            this.revealSitecoreAdminPassword.TabStop = true;
            this.revealSitecoreAdminPassword.Text = "(reveal)";
            this.revealSitecoreAdminPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.revealSitecoreAdminPassword_LinkClicked);
            // 
            // adminPasswordText
            // 
            this.adminPasswordText.Location = new System.Drawing.Point(21, 158);
            this.adminPasswordText.Name = "adminPasswordText";
            this.adminPasswordText.PasswordChar = '*';
            this.adminPasswordText.Size = new System.Drawing.Size(198, 20);
            this.adminPasswordText.TabIndex = 32;
            // 
            // textDestinationFolder
            // 
            this.textDestinationFolder.Location = new System.Drawing.Point(24, 50);
            this.textDestinationFolder.MaxLength = 255;
            this.textDestinationFolder.Name = "textDestinationFolder";
            this.textDestinationFolder.Size = new System.Drawing.Size(175, 20);
            this.textDestinationFolder.TabIndex = 10;
            // 
            // targetFolderButton
            // 
            this.targetFolderButton.Location = new System.Drawing.Point(198, 49);
            this.targetFolderButton.Name = "targetFolderButton";
            this.targetFolderButton.Size = new System.Drawing.Size(21, 22);
            this.targetFolderButton.TabIndex = 11;
            this.targetFolderButton.Text = "...";
            this.targetFolderButton.UseVisualStyleBackColor = true;
            this.targetFolderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // licenseFileButton
            // 
            this.licenseFileButton.Location = new System.Drawing.Point(198, 107);
            this.licenseFileButton.Name = "licenseFileButton";
            this.licenseFileButton.Size = new System.Drawing.Size(21, 22);
            this.licenseFileButton.TabIndex = 31;
            this.licenseFileButton.Text = "...";
            this.licenseFileButton.UseVisualStyleBackColor = true;
            this.licenseFileButton.Click += new System.EventHandler(this.licenseFileButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sitecore admin password";
            // 
            // licenseTextbox
            // 
            this.licenseTextbox.AllowDrop = true;
            this.licenseTextbox.Location = new System.Drawing.Point(24, 108);
            this.licenseTextbox.MaxLength = 255;
            this.licenseTextbox.Name = "licenseTextbox";
            this.licenseTextbox.Size = new System.Drawing.Size(175, 20);
            this.licenseTextbox.TabIndex = 30;
            this.licenseTextbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.licenseTextbox_DragDrop);
            this.licenseTextbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.licenseTextbox_DragEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "License file:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Target folder to install into:";
            // 
            // createSifonProfile
            // 
            this.createSifonProfile.AutoSize = true;
            this.createSifonProfile.Checked = true;
            this.createSifonProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createSifonProfile.Location = new System.Drawing.Point(21, 109);
            this.createSifonProfile.Name = "createSifonProfile";
            this.createSifonProfile.Size = new System.Drawing.Size(115, 17);
            this.createSifonProfile.TabIndex = 8;
            this.createSifonProfile.Text = "Create Sifon profile";
            this.createSifonProfile.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sitecoreSiteLabel);
            this.groupBox2.Controls.Add(this.sitecoreSiteText);
            this.groupBox2.Controls.Add(this.identityServerLabel);
            this.groupBox2.Controls.Add(this.identityServerText);
            this.groupBox2.Controls.Add(this.xconnectLabel);
            this.groupBox2.Controls.Add(this.xconnectText);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.prefixText);
            this.groupBox2.Location = new System.Drawing.Point(555, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 218);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Names and prefixes:";
            // 
            // sitecoreSiteLabel
            // 
            this.sitecoreSiteLabel.AutoSize = true;
            this.sitecoreSiteLabel.Location = new System.Drawing.Point(19, 80);
            this.sitecoreSiteLabel.Name = "sitecoreSiteLabel";
            this.sitecoreSiteLabel.Size = new System.Drawing.Size(68, 13);
            this.sitecoreSiteLabel.TabIndex = 7;
            this.sitecoreSiteLabel.Text = "Sitecore site:";
            // 
            // sitecoreSiteText
            // 
            this.sitecoreSiteText.Location = new System.Drawing.Point(19, 96);
            this.sitecoreSiteText.Name = "sitecoreSiteText";
            this.sitecoreSiteText.Size = new System.Drawing.Size(177, 20);
            this.sitecoreSiteText.TabIndex = 6;
            // 
            // identityServerLabel
            // 
            this.identityServerLabel.AutoSize = true;
            this.identityServerLabel.Location = new System.Drawing.Point(21, 168);
            this.identityServerLabel.Name = "identityServerLabel";
            this.identityServerLabel.Size = new System.Drawing.Size(75, 13);
            this.identityServerLabel.TabIndex = 5;
            this.identityServerLabel.Text = "IdentityServer:";
            // 
            // identityServerText
            // 
            this.identityServerText.Location = new System.Drawing.Point(21, 186);
            this.identityServerText.Name = "identityServerText";
            this.identityServerText.Size = new System.Drawing.Size(175, 20);
            this.identityServerText.TabIndex = 4;
            // 
            // xconnectLabel
            // 
            this.xconnectLabel.AutoSize = true;
            this.xconnectLabel.Location = new System.Drawing.Point(21, 124);
            this.xconnectLabel.Name = "xconnectLabel";
            this.xconnectLabel.Size = new System.Drawing.Size(76, 13);
            this.xconnectLabel.TabIndex = 3;
            this.xconnectLabel.Text = "XConnect site:";
            // 
            // xconnectText
            // 
            this.xconnectText.Location = new System.Drawing.Point(21, 142);
            this.xconnectText.Name = "xconnectText";
            this.xconnectText.Size = new System.Drawing.Size(175, 20);
            this.xconnectText.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Instance prefix:";
            // 
            // prefixText
            // 
            this.prefixText.Location = new System.Drawing.Point(21, 50);
            this.prefixText.Name = "prefixText";
            this.prefixText.Size = new System.Drawing.Size(175, 20);
            this.prefixText.TabIndex = 0;
            // 
            // SQLGroupbox
            // 
            this.SQLGroupbox.Controls.Add(this.linkLabel1);
            this.SQLGroupbox.Controls.Add(this.sqlServerPasswordText);
            this.SQLGroupbox.Controls.Add(this.label2);
            this.SQLGroupbox.Controls.Add(this.label3);
            this.SQLGroupbox.Controls.Add(this.sqlServerUsernameText);
            this.SQLGroupbox.Controls.Add(this.sqlServerLabel);
            this.SQLGroupbox.Controls.Add(this.sqlServerText);
            this.SQLGroupbox.Location = new System.Drawing.Point(309, 241);
            this.SQLGroupbox.Name = "SQLGroupbox";
            this.SQLGroupbox.Size = new System.Drawing.Size(230, 209);
            this.SQLGroupbox.TabIndex = 5;
            this.SQLGroupbox.TabStop = false;
            this.SQLGroupbox.Text = "SQL";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(179, 144);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(42, 13);
            this.linkLabel1.TabIndex = 29;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "(reveal)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // sqlServerPasswordText
            // 
            this.sqlServerPasswordText.Location = new System.Drawing.Point(21, 161);
            this.sqlServerPasswordText.Name = "sqlServerPasswordText";
            this.sqlServerPasswordText.PasswordChar = '*';
            this.sqlServerPasswordText.Size = new System.Drawing.Size(198, 20);
            this.sqlServerPasswordText.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "SQL Server admin password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "SQL Server admin username:";
            // 
            // sqlServerUsernameText
            // 
            this.sqlServerUsernameText.Location = new System.Drawing.Point(21, 106);
            this.sqlServerUsernameText.Name = "sqlServerUsernameText";
            this.sqlServerUsernameText.Size = new System.Drawing.Size(198, 20);
            this.sqlServerUsernameText.TabIndex = 2;
            // 
            // sqlServerLabel
            // 
            this.sqlServerLabel.AutoSize = true;
            this.sqlServerLabel.Location = new System.Drawing.Point(21, 32);
            this.sqlServerLabel.Name = "sqlServerLabel";
            this.sqlServerLabel.Size = new System.Drawing.Size(65, 13);
            this.sqlServerLabel.TabIndex = 1;
            this.sqlServerLabel.Text = "SQL Server:";
            // 
            // sqlServerText
            // 
            this.sqlServerText.Location = new System.Drawing.Point(21, 50);
            this.sqlServerText.Name = "sqlServerText";
            this.sqlServerText.Size = new System.Drawing.Size(198, 20);
            this.sqlServerText.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.solrRootFolderText);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.solrServiceLabel);
            this.groupBox1.Controls.Add(this.solrServiceText);
            this.groupBox1.Controls.Add(this.solrUrlLabel);
            this.groupBox1.Controls.Add(this.solrUrlText);
            this.groupBox1.Location = new System.Drawing.Point(555, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 209);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solr";
            // 
            // solrRootFolderText
            // 
            this.solrRootFolderText.Location = new System.Drawing.Point(21, 160);
            this.solrRootFolderText.MaxLength = 255;
            this.solrRootFolderText.Name = "solrRootFolderText";
            this.solrRootFolderText.Size = new System.Drawing.Size(175, 20);
            this.solrRootFolderText.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(195, 159);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 22);
            this.button4.TabIndex = 14;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Solr root folder:";
            // 
            // solrServiceLabel
            // 
            this.solrServiceLabel.AutoSize = true;
            this.solrServiceLabel.Location = new System.Drawing.Point(21, 88);
            this.solrServiceLabel.Name = "solrServiceLabel";
            this.solrServiceLabel.Size = new System.Drawing.Size(94, 13);
            this.solrServiceLabel.TabIndex = 3;
            this.solrServiceLabel.Text = "Solr service name:";
            // 
            // solrServiceText
            // 
            this.solrServiceText.Location = new System.Drawing.Point(21, 106);
            this.solrServiceText.Name = "solrServiceText";
            this.solrServiceText.Size = new System.Drawing.Size(175, 20);
            this.solrServiceText.TabIndex = 2;
            // 
            // solrUrlLabel
            // 
            this.solrUrlLabel.AutoSize = true;
            this.solrUrlLabel.Location = new System.Drawing.Point(21, 32);
            this.solrUrlLabel.Name = "solrUrlLabel";
            this.solrUrlLabel.Size = new System.Drawing.Size(50, 13);
            this.solrUrlLabel.TabIndex = 1;
            this.solrUrlLabel.Text = "Solr URL";
            // 
            // solrUrlText
            // 
            this.solrUrlText.Location = new System.Drawing.Point(21, 50);
            this.solrUrlText.Name = "solrUrlText";
            this.solrUrlText.Size = new System.Drawing.Size(175, 20);
            this.solrUrlText.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonTestRemoting);
            this.groupBox4.Controls.Add(this.checkBoxRemote);
            this.groupBox4.Controls.Add(this.textHostname);
            this.groupBox4.Controls.Add(this.labelHostname);
            this.groupBox4.Controls.Add(this.linkRevealRemoting);
            this.groupBox4.Controls.Add(this.textPassword);
            this.groupBox4.Controls.Add(this.labelPassword);
            this.groupBox4.Controls.Add(this.textUsername);
            this.groupBox4.Controls.Add(this.labelUsername);
            this.groupBox4.Location = new System.Drawing.Point(12, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 251);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remoting";
            // 
            // buttonTestRemoting
            // 
            this.buttonTestRemoting.Enabled = false;
            this.buttonTestRemoting.Location = new System.Drawing.Point(198, 205);
            this.buttonTestRemoting.Name = "buttonTestRemoting";
            this.buttonTestRemoting.Size = new System.Drawing.Size(75, 23);
            this.buttonTestRemoting.TabIndex = 29;
            this.buttonTestRemoting.Text = "Test";
            this.buttonTestRemoting.UseVisualStyleBackColor = true;
            this.buttonTestRemoting.Click += new System.EventHandler(this.buttonTestRemoting_Click);
            // 
            // checkBoxRemote
            // 
            this.checkBoxRemote.AutoSize = true;
            this.checkBoxRemote.Enabled = false;
            this.checkBoxRemote.Location = new System.Drawing.Point(15, 28);
            this.checkBoxRemote.Name = "checkBoxRemote";
            this.checkBoxRemote.Size = new System.Drawing.Size(165, 17);
            this.checkBoxRemote.TabIndex = 23;
            this.checkBoxRemote.Text = "This profile executes remotely";
            this.checkBoxRemote.UseVisualStyleBackColor = true;
            this.checkBoxRemote.CheckedChanged += new System.EventHandler(this.checkBoxRemote_CheckedChanged);
            // 
            // textHostname
            // 
            this.textHostname.Enabled = false;
            this.textHostname.Location = new System.Drawing.Point(15, 75);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(256, 20);
            this.textHostname.TabIndex = 24;
            // 
            // labelHostname
            // 
            this.labelHostname.AutoSize = true;
            this.labelHostname.Location = new System.Drawing.Point(12, 59);
            this.labelHostname.Name = "labelHostname";
            this.labelHostname.Size = new System.Drawing.Size(70, 13);
            this.labelHostname.TabIndex = 32;
            this.labelHostname.Text = "Remote host:";
            // 
            // linkRevealRemoting
            // 
            this.linkRevealRemoting.AutoSize = true;
            this.linkRevealRemoting.Enabled = false;
            this.linkRevealRemoting.Location = new System.Drawing.Point(231, 155);
            this.linkRevealRemoting.Name = "linkRevealRemoting";
            this.linkRevealRemoting.Size = new System.Drawing.Size(42, 13);
            this.linkRevealRemoting.TabIndex = 27;
            this.linkRevealRemoting.TabStop = true;
            this.linkRevealRemoting.Text = "(reveal)";
            this.linkRevealRemoting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReveal_LinkClicked);
            // 
            // textPassword
            // 
            this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(17, 172);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(254, 20);
            this.textPassword.TabIndex = 26;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(14, 155);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 31;
            this.labelPassword.Text = "Password:";
            // 
            // textUsername
            // 
            this.textUsername.Enabled = false;
            this.textUsername.Location = new System.Drawing.Point(15, 123);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(256, 20);
            this.textUsername.TabIndex = 25;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(12, 107);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 30;
            this.labelUsername.Text = "Username:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Set Defaults";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SetDefaults_Click);
            // 
            // groupParameters
            // 
            this.groupParameters.Controls.Add(this.installPrerequisites);
            this.groupParameters.Controls.Add(this.versionLabel);
            this.groupParameters.Controls.Add(this.comboVersions);
            this.groupParameters.Controls.Add(this.createSifonProfile);
            this.groupParameters.Location = new System.Drawing.Point(12, 13);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(291, 137);
            this.groupParameters.TabIndex = 11;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Please select Sitecore version:";
            // 
            // installPrerequisites
            // 
            this.installPrerequisites.AutoSize = true;
            this.installPrerequisites.Checked = true;
            this.installPrerequisites.CheckState = System.Windows.Forms.CheckState.Checked;
            this.installPrerequisites.Location = new System.Drawing.Point(21, 81);
            this.installPrerequisites.Name = "installPrerequisites";
            this.installPrerequisites.Size = new System.Drawing.Size(116, 17);
            this.installPrerequisites.TabIndex = 12;
            this.installPrerequisites.Text = "Install Prerequisites";
            this.installPrerequisites.UseVisualStyleBackColor = true;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(18, 31);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(91, 13);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Sitecore versions:";
            // 
            // comboVersions
            // 
            this.comboVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVersions.FormattingEnabled = true;
            this.comboVersions.Location = new System.Drawing.Point(21, 47);
            this.comboVersions.Name = "comboVersions";
            this.comboVersions.Size = new System.Drawing.Size(250, 21);
            this.comboVersions.TabIndex = 11;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(210, 427);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 23);
            this.buttonInstall.TabIndex = 12;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.install_Click);
            // 
            // Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 464);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.groupParameters);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SQLGroupbox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Install";
            this.Text = "Siteore XP0 Installer";
            this.Load += new System.EventHandler(this.Installer_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SQLGroupbox.ResumeLayout(false);
            this.SQLGroupbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupParameters.ResumeLayout(false);
            this.groupParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label identityServerLabel;
        private System.Windows.Forms.TextBox identityServerText;
        private System.Windows.Forms.Label xconnectLabel;
        private System.Windows.Forms.TextBox xconnectText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox prefixText;
        private System.Windows.Forms.GroupBox SQLGroupbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sqlServerUsernameText;
        private System.Windows.Forms.Label sqlServerLabel;
        private System.Windows.Forms.TextBox sqlServerText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label solrServiceLabel;
        private System.Windows.Forms.TextBox solrServiceText;
        private System.Windows.Forms.Label solrUrlLabel;
        private System.Windows.Forms.TextBox solrUrlText;
        private System.Windows.Forms.Button licenseFileButton;
        private System.Windows.Forms.TextBox licenseTextbox;
        private System.Windows.Forms.CheckBox createSifonProfile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonTestRemoting;
        private System.Windows.Forms.CheckBox checkBoxRemote;
        public System.Windows.Forms.TextBox textHostname;
        private System.Windows.Forms.Label labelHostname;
        private System.Windows.Forms.LinkLabel linkRevealRemoting;
        public System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPassword;
        public System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textDestinationFolder;
        private System.Windows.Forms.Button targetFolderButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupParameters;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox comboVersions;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.LinkLabel revealSitecoreAdminPassword;
        public System.Windows.Forms.TextBox adminPasswordText;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.TextBox sqlServerPasswordText;
        private System.Windows.Forms.TextBox solrRootFolderText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label sitecoreSiteLabel;
        private System.Windows.Forms.TextBox sitecoreSiteText;
        private System.Windows.Forms.CheckBox installPrerequisites;
    }
}