﻿namespace Sifon.Forms.Install
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Install));
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
            this.groupBoxSql = new System.Windows.Forms.GroupBox();
            this.buttonInstallSQL = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonTestSQL = new System.Windows.Forms.Button();
            this.linkRevealSqlPassword = new System.Windows.Forms.LinkLabel();
            this.sqlServerPasswordText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sqlServerUsernameText = new System.Windows.Forms.TextBox();
            this.sqlServerLabel = new System.Windows.Forms.Label();
            this.sqlServerText = new System.Windows.Forms.TextBox();
            this.groupBoxSolr = new System.Windows.Forms.GroupBox();
            this.buttonTestSolr = new System.Windows.Forms.Button();
            this.solrRootFolderText = new System.Windows.Forms.TextBox();
            this.buttonSolrFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.solrServiceLabel = new System.Windows.Forms.Label();
            this.solrServiceText = new System.Windows.Forms.TextBox();
            this.solrUrlLabel = new System.Windows.Forms.Label();
            this.solrUrlText = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonTestRemoting = new System.Windows.Forms.Button();
            this.checkBoxRemote = new System.Windows.Forms.CheckBox();
            this.textRemoteHostname = new System.Windows.Forms.TextBox();
            this.labelHostname = new System.Windows.Forms.Label();
            this.linkRevealRemoting = new System.Windows.Forms.LinkLabel();
            this.textRemotePassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textRemoteUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonSetDefaults = new System.Windows.Forms.Button();
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.installPrerequisites = new System.Windows.Forms.CheckBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.comboVersions = new System.Windows.Forms.ComboBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.loadingCircle = new Sifon.UserControls.LoadingCircle();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSql.SuspendLayout();
            this.groupBoxSolr.SuspendLayout();
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
            this.groupBox3.Location = new System.Drawing.Point(550, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 187);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instance";
            // 
            // revealSitecoreAdminPassword
            // 
            this.revealSitecoreAdminPassword.AutoSize = true;
            this.revealSitecoreAdminPassword.Location = new System.Drawing.Point(179, 131);
            this.revealSitecoreAdminPassword.Name = "revealSitecoreAdminPassword";
            this.revealSitecoreAdminPassword.Size = new System.Drawing.Size(42, 13);
            this.revealSitecoreAdminPassword.TabIndex = 56;
            this.revealSitecoreAdminPassword.TabStop = true;
            this.revealSitecoreAdminPassword.Text = "(reveal)";
            this.revealSitecoreAdminPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.revealSitecoreAdminPassword_LinkClicked);
            // 
            // adminPasswordText
            // 
            this.adminPasswordText.Location = new System.Drawing.Point(21, 148);
            this.adminPasswordText.Name = "adminPasswordText";
            this.adminPasswordText.PasswordChar = '*';
            this.adminPasswordText.Size = new System.Drawing.Size(198, 20);
            this.adminPasswordText.TabIndex = 55;
            // 
            // textDestinationFolder
            // 
            this.textDestinationFolder.Location = new System.Drawing.Point(21, 44);
            this.textDestinationFolder.MaxLength = 255;
            this.textDestinationFolder.Name = "textDestinationFolder";
            this.textDestinationFolder.Size = new System.Drawing.Size(179, 20);
            this.textDestinationFolder.TabIndex = 51;
            // 
            // targetFolderButton
            // 
            this.targetFolderButton.Location = new System.Drawing.Point(198, 43);
            this.targetFolderButton.Name = "targetFolderButton";
            this.targetFolderButton.Size = new System.Drawing.Size(21, 22);
            this.targetFolderButton.TabIndex = 52;
            this.targetFolderButton.Text = "...";
            this.targetFolderButton.UseVisualStyleBackColor = true;
            this.targetFolderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // licenseFileButton
            // 
            this.licenseFileButton.Location = new System.Drawing.Point(198, 95);
            this.licenseFileButton.Name = "licenseFileButton";
            this.licenseFileButton.Size = new System.Drawing.Size(21, 22);
            this.licenseFileButton.TabIndex = 54;
            this.licenseFileButton.Text = "...";
            this.licenseFileButton.UseVisualStyleBackColor = true;
            this.licenseFileButton.Click += new System.EventHandler(this.licenseFileButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sitecore admin password";
            // 
            // licenseTextbox
            // 
            this.licenseTextbox.AllowDrop = true;
            this.licenseTextbox.Location = new System.Drawing.Point(21, 96);
            this.licenseTextbox.MaxLength = 255;
            this.licenseTextbox.Name = "licenseTextbox";
            this.licenseTextbox.Size = new System.Drawing.Size(178, 20);
            this.licenseTextbox.TabIndex = 53;
            this.licenseTextbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.licenseTextbox_DragDrop);
            this.licenseTextbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.licenseTextbox_DragEnter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "License file:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 27);
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
            this.createSifonProfile.Location = new System.Drawing.Point(15, 201);
            this.createSifonProfile.Name = "createSifonProfile";
            this.createSifonProfile.Size = new System.Drawing.Size(227, 27);
            this.createSifonProfile.TabIndex = 13;
            this.createSifonProfile.Text = "Create Sifon profile for installed instance";
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
            this.groupBox2.Location = new System.Drawing.Point(314, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 246);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Names and prefixes:";
            // 
            // sitecoreSiteLabel
            // 
            this.sitecoreSiteLabel.AutoSize = true;
            this.sitecoreSiteLabel.Location = new System.Drawing.Point(16, 81);
            this.sitecoreSiteLabel.Name = "sitecoreSiteLabel";
            this.sitecoreSiteLabel.Size = new System.Drawing.Size(68, 13);
            this.sitecoreSiteLabel.TabIndex = 7;
            this.sitecoreSiteLabel.Text = "Sitecore site:";
            // 
            // sitecoreSiteText
            // 
            this.sitecoreSiteText.Location = new System.Drawing.Point(18, 97);
            this.sitecoreSiteText.Name = "sitecoreSiteText";
            this.sitecoreSiteText.Size = new System.Drawing.Size(180, 20);
            this.sitecoreSiteText.TabIndex = 32;
            // 
            // identityServerLabel
            // 
            this.identityServerLabel.AutoSize = true;
            this.identityServerLabel.Location = new System.Drawing.Point(16, 184);
            this.identityServerLabel.Name = "identityServerLabel";
            this.identityServerLabel.Size = new System.Drawing.Size(75, 13);
            this.identityServerLabel.TabIndex = 5;
            this.identityServerLabel.Text = "IdentityServer:";
            // 
            // identityServerText
            // 
            this.identityServerText.Location = new System.Drawing.Point(18, 201);
            this.identityServerText.Name = "identityServerText";
            this.identityServerText.Size = new System.Drawing.Size(180, 20);
            this.identityServerText.TabIndex = 34;
            // 
            // xconnectLabel
            // 
            this.xconnectLabel.AutoSize = true;
            this.xconnectLabel.Location = new System.Drawing.Point(16, 132);
            this.xconnectLabel.Name = "xconnectLabel";
            this.xconnectLabel.Size = new System.Drawing.Size(76, 13);
            this.xconnectLabel.TabIndex = 3;
            this.xconnectLabel.Text = "XConnect site:";
            // 
            // xconnectText
            // 
            this.xconnectText.Location = new System.Drawing.Point(18, 148);
            this.xconnectText.Name = "xconnectText";
            this.xconnectText.Size = new System.Drawing.Size(180, 20);
            this.xconnectText.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Instance prefix:";
            // 
            // prefixText
            // 
            this.prefixText.Location = new System.Drawing.Point(18, 44);
            this.prefixText.Name = "prefixText";
            this.prefixText.Size = new System.Drawing.Size(180, 20);
            this.prefixText.TabIndex = 31;
            // 
            // groupBoxSql
            // 
            this.groupBoxSql.Controls.Add(this.buttonInstallSQL);
            this.groupBoxSql.Controls.Add(this.label4);
            this.groupBoxSql.Controls.Add(this.buttonTestSQL);
            this.groupBoxSql.Controls.Add(this.linkRevealSqlPassword);
            this.groupBoxSql.Controls.Add(this.sqlServerPasswordText);
            this.groupBoxSql.Controls.Add(this.label2);
            this.groupBoxSql.Controls.Add(this.label3);
            this.groupBoxSql.Controls.Add(this.sqlServerUsernameText);
            this.groupBoxSql.Controls.Add(this.sqlServerLabel);
            this.groupBoxSql.Controls.Add(this.sqlServerText);
            this.groupBoxSql.Location = new System.Drawing.Point(314, 268);
            this.groupBoxSql.Name = "groupBoxSql";
            this.groupBoxSql.Size = new System.Drawing.Size(225, 240);
            this.groupBoxSql.TabIndex = 4;
            this.groupBoxSql.TabStop = false;
            this.groupBoxSql.Text = "SQL Server:";
            // 
            // buttonInstallSQL
            // 
            this.buttonInstallSQL.Location = new System.Drawing.Point(18, 201);
            this.buttonInstallSQL.Name = "buttonInstallSQL";
            this.buttonInstallSQL.Size = new System.Drawing.Size(78, 23);
            this.buttonInstallSQL.TabIndex = 46;
            this.buttonInstallSQL.Text = "Install SQL";
            this.buttonInstallSQL.UseVisualStyleBackColor = true;
            this.buttonInstallSQL.Click += new System.EventHandler(this.buttonInstallSQL_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 31;
            // 
            // buttonTestSQL
            // 
            this.buttonTestSQL.Enabled = false;
            this.buttonTestSQL.Location = new System.Drawing.Point(102, 201);
            this.buttonTestSQL.Name = "buttonTestSQL";
            this.buttonTestSQL.Size = new System.Drawing.Size(96, 23);
            this.buttonTestSQL.TabIndex = 45;
            this.buttonTestSQL.Text = "Test Connection";
            this.buttonTestSQL.UseVisualStyleBackColor = true;
            this.buttonTestSQL.Click += new System.EventHandler(this.buttonTestSQL_Click);
            // 
            // linkRevealSqlPassword
            // 
            this.linkRevealSqlPassword.AutoSize = true;
            this.linkRevealSqlPassword.Location = new System.Drawing.Point(159, 140);
            this.linkRevealSqlPassword.Name = "linkRevealSqlPassword";
            this.linkRevealSqlPassword.Size = new System.Drawing.Size(42, 13);
            this.linkRevealSqlPassword.TabIndex = 44;
            this.linkRevealSqlPassword.TabStop = true;
            this.linkRevealSqlPassword.Text = "(reveal)";
            this.linkRevealSqlPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // sqlServerPasswordText
            // 
            this.sqlServerPasswordText.Location = new System.Drawing.Point(18, 157);
            this.sqlServerPasswordText.Name = "sqlServerPasswordText";
            this.sqlServerPasswordText.PasswordChar = '*';
            this.sqlServerPasswordText.Size = new System.Drawing.Size(180, 20);
            this.sqlServerPasswordText.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "SQL Server admin password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "SQL Server admin username:";
            // 
            // sqlServerUsernameText
            // 
            this.sqlServerUsernameText.Location = new System.Drawing.Point(18, 109);
            this.sqlServerUsernameText.Name = "sqlServerUsernameText";
            this.sqlServerUsernameText.Size = new System.Drawing.Size(180, 20);
            this.sqlServerUsernameText.TabIndex = 42;
            // 
            // sqlServerLabel
            // 
            this.sqlServerLabel.AutoSize = true;
            this.sqlServerLabel.Location = new System.Drawing.Point(15, 44);
            this.sqlServerLabel.Name = "sqlServerLabel";
            this.sqlServerLabel.Size = new System.Drawing.Size(65, 13);
            this.sqlServerLabel.TabIndex = 1;
            this.sqlServerLabel.Text = "SQL Server:";
            // 
            // sqlServerText
            // 
            this.sqlServerText.Location = new System.Drawing.Point(18, 60);
            this.sqlServerText.Name = "sqlServerText";
            this.sqlServerText.Size = new System.Drawing.Size(180, 20);
            this.sqlServerText.TabIndex = 41;
            // 
            // groupBoxSolr
            // 
            this.groupBoxSolr.Controls.Add(this.buttonTestSolr);
            this.groupBoxSolr.Controls.Add(this.solrRootFolderText);
            this.groupBoxSolr.Controls.Add(this.buttonSolrFolder);
            this.groupBoxSolr.Controls.Add(this.label1);
            this.groupBoxSolr.Controls.Add(this.solrServiceLabel);
            this.groupBoxSolr.Controls.Add(this.solrServiceText);
            this.groupBoxSolr.Controls.Add(this.solrUrlLabel);
            this.groupBoxSolr.Controls.Add(this.solrUrlText);
            this.groupBoxSolr.Location = new System.Drawing.Point(550, 214);
            this.groupBoxSolr.Name = "groupBoxSolr";
            this.groupBoxSolr.Size = new System.Drawing.Size(230, 239);
            this.groupBoxSolr.TabIndex = 6;
            this.groupBoxSolr.TabStop = false;
            this.groupBoxSolr.Text = "Solr:";
            // 
            // buttonTestSolr
            // 
            this.buttonTestSolr.Enabled = false;
            this.buttonTestSolr.Location = new System.Drawing.Point(98, 207);
            this.buttonTestSolr.Name = "buttonTestSolr";
            this.buttonTestSolr.Size = new System.Drawing.Size(121, 23);
            this.buttonTestSolr.TabIndex = 65;
            this.buttonTestSolr.Text = "Test Solr Connection";
            this.buttonTestSolr.UseVisualStyleBackColor = true;
            this.buttonTestSolr.Click += new System.EventHandler(this.buttonTestSolr_Click);
            // 
            // solrRootFolderText
            // 
            this.solrRootFolderText.Location = new System.Drawing.Point(21, 162);
            this.solrRootFolderText.MaxLength = 255;
            this.solrRootFolderText.Name = "solrRootFolderText";
            this.solrRootFolderText.Size = new System.Drawing.Size(179, 20);
            this.solrRootFolderText.TabIndex = 63;
            // 
            // buttonSolrFolder
            // 
            this.buttonSolrFolder.Location = new System.Drawing.Point(198, 161);
            this.buttonSolrFolder.Name = "buttonSolrFolder";
            this.buttonSolrFolder.Size = new System.Drawing.Size(21, 22);
            this.buttonSolrFolder.TabIndex = 64;
            this.buttonSolrFolder.Text = "...";
            this.buttonSolrFolder.UseVisualStyleBackColor = true;
            this.buttonSolrFolder.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Solr root folder:";
            // 
            // solrServiceLabel
            // 
            this.solrServiceLabel.AutoSize = true;
            this.solrServiceLabel.Location = new System.Drawing.Point(18, 90);
            this.solrServiceLabel.Name = "solrServiceLabel";
            this.solrServiceLabel.Size = new System.Drawing.Size(94, 13);
            this.solrServiceLabel.TabIndex = 3;
            this.solrServiceLabel.Text = "Solr service name:";
            // 
            // solrServiceText
            // 
            this.solrServiceText.Location = new System.Drawing.Point(21, 106);
            this.solrServiceText.Name = "solrServiceText";
            this.solrServiceText.Size = new System.Drawing.Size(198, 20);
            this.solrServiceText.TabIndex = 62;
            // 
            // solrUrlLabel
            // 
            this.solrUrlLabel.AutoSize = true;
            this.solrUrlLabel.Location = new System.Drawing.Point(18, 32);
            this.solrUrlLabel.Name = "solrUrlLabel";
            this.solrUrlLabel.Size = new System.Drawing.Size(50, 13);
            this.solrUrlLabel.TabIndex = 1;
            this.solrUrlLabel.Text = "Solr URL";
            // 
            // solrUrlText
            // 
            this.solrUrlText.Location = new System.Drawing.Point(21, 50);
            this.solrUrlText.Name = "solrUrlText";
            this.solrUrlText.Size = new System.Drawing.Size(198, 20);
            this.solrUrlText.TabIndex = 61;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonTestRemoting);
            this.groupBox4.Controls.Add(this.checkBoxRemote);
            this.groupBox4.Controls.Add(this.textRemoteHostname);
            this.groupBox4.Controls.Add(this.labelHostname);
            this.groupBox4.Controls.Add(this.linkRevealRemoting);
            this.groupBox4.Controls.Add(this.textRemotePassword);
            this.groupBox4.Controls.Add(this.labelPassword);
            this.groupBox4.Controls.Add(this.textRemoteUsername);
            this.groupBox4.Controls.Add(this.labelUsername);
            this.groupBox4.Location = new System.Drawing.Point(12, 253);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 255);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remoting";
            // 
            // buttonTestRemoting
            // 
            this.buttonTestRemoting.Enabled = false;
            this.buttonTestRemoting.Location = new System.Drawing.Point(111, 216);
            this.buttonTestRemoting.Name = "buttonTestRemoting";
            this.buttonTestRemoting.Size = new System.Drawing.Size(162, 23);
            this.buttonTestRemoting.TabIndex = 26;
            this.buttonTestRemoting.Text = "Test and Initialize Remote Host";
            this.buttonTestRemoting.UseVisualStyleBackColor = true;
            this.buttonTestRemoting.Click += new System.EventHandler(this.buttonTestRemoting_Click);
            // 
            // checkBoxRemote
            // 
            this.checkBoxRemote.AutoSize = true;
            this.checkBoxRemote.Location = new System.Drawing.Point(17, 29);
            this.checkBoxRemote.Name = "checkBoxRemote";
            this.checkBoxRemote.Size = new System.Drawing.Size(246, 27);
            this.checkBoxRemote.TabIndex = 21;
            this.checkBoxRemote.Text = "Install Sitecore into a remote machine or VM";
            this.checkBoxRemote.UseVisualStyleBackColor = true;
            this.checkBoxRemote.CheckedChanged += new System.EventHandler(this.checkBoxRemote_CheckedChanged);
            // 
            // textRemoteHostname
            // 
            this.textRemoteHostname.Enabled = false;
            this.textRemoteHostname.Location = new System.Drawing.Point(17, 75);
            this.textRemoteHostname.Name = "textRemoteHostname";
            this.textRemoteHostname.Size = new System.Drawing.Size(256, 20);
            this.textRemoteHostname.TabIndex = 22;
            // 
            // labelHostname
            // 
            this.labelHostname.AutoSize = true;
            this.labelHostname.Location = new System.Drawing.Point(14, 59);
            this.labelHostname.Name = "labelHostname";
            this.labelHostname.Size = new System.Drawing.Size(161, 13);
            this.labelHostname.TabIndex = 32;
            this.labelHostname.Text = "Remote hostname or IP address:";
            // 
            // linkRevealRemoting
            // 
            this.linkRevealRemoting.AutoSize = true;
            this.linkRevealRemoting.Enabled = false;
            this.linkRevealRemoting.Location = new System.Drawing.Point(232, 155);
            this.linkRevealRemoting.Name = "linkRevealRemoting";
            this.linkRevealRemoting.Size = new System.Drawing.Size(42, 13);
            this.linkRevealRemoting.TabIndex = 25;
            this.linkRevealRemoting.TabStop = true;
            this.linkRevealRemoting.Text = "(reveal)";
            this.linkRevealRemoting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReveal_LinkClicked);
            // 
            // textRemotePassword
            // 
            this.textRemotePassword.Enabled = false;
            this.textRemotePassword.Location = new System.Drawing.Point(17, 172);
            this.textRemotePassword.Name = "textRemotePassword";
            this.textRemotePassword.PasswordChar = '*';
            this.textRemotePassword.Size = new System.Drawing.Size(256, 20);
            this.textRemotePassword.TabIndex = 24;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(14, 155);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(138, 13);
            this.labelPassword.TabIndex = 31;
            this.labelPassword.Text = "Remote machine password:";
            // 
            // textRemoteUsername
            // 
            this.textRemoteUsername.Enabled = false;
            this.textRemoteUsername.Location = new System.Drawing.Point(17, 123);
            this.textRemoteUsername.Name = "textRemoteUsername";
            this.textRemoteUsername.Size = new System.Drawing.Size(256, 20);
            this.textRemoteUsername.TabIndex = 23;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(14, 107);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(139, 13);
            this.labelUsername.TabIndex = 30;
            this.labelUsername.Text = "Remote machine username:";
            // 
            // buttonSetDefaults
            // 
            this.buttonSetDefaults.Location = new System.Drawing.Point(550, 469);
            this.buttonSetDefaults.Name = "buttonSetDefaults";
            this.buttonSetDefaults.Size = new System.Drawing.Size(75, 23);
            this.buttonSetDefaults.TabIndex = 7;
            this.buttonSetDefaults.Text = "Set Defaults";
            this.buttonSetDefaults.UseVisualStyleBackColor = true;
            this.buttonSetDefaults.Click += new System.EventHandler(this.SetDefaults_Click);
            // 
            // groupParameters
            // 
            this.groupParameters.Controls.Add(this.label13);
            this.groupParameters.Controls.Add(this.label12);
            this.groupParameters.Controls.Add(this.label11);
            this.groupParameters.Controls.Add(this.label10);
            this.groupParameters.Controls.Add(this.label5);
            this.groupParameters.Controls.Add(this.installPrerequisites);
            this.groupParameters.Controls.Add(this.versionLabel);
            this.groupParameters.Controls.Add(this.comboVersions);
            this.groupParameters.Controls.Add(this.createSifonProfile);
            this.groupParameters.Location = new System.Drawing.Point(12, 13);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(291, 234);
            this.groupParameters.TabIndex = 1;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Parameters";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(263, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "if choosing creating Sifon profile with checkbox below.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(266, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "You may benefit from Sifon immediately after installation";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(264, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "available over the network via WinRM protocol for PS.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(265, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "your choice, either on a local machine, or any PC / VM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "This dialog will download and install Sitecore version of";
            // 
            // installPrerequisites
            // 
            this.installPrerequisites.AutoSize = true;
            this.installPrerequisites.Checked = true;
            this.installPrerequisites.CheckState = System.Windows.Forms.CheckState.Checked;
            this.installPrerequisites.Location = new System.Drawing.Point(15, 178);
            this.installPrerequisites.Name = "installPrerequisites";
            this.installPrerequisites.Size = new System.Drawing.Size(242, 27);
            this.installPrerequisites.TabIndex = 12;
            this.installPrerequisites.Text = "Install Prerequisites for this Sitecore version";
            this.installPrerequisites.UseVisualStyleBackColor = true;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(12, 131);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(152, 13);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Please select Sitecore version:";
            // 
            // comboVersions
            // 
            this.comboVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVersions.FormattingEnabled = true;
            this.comboVersions.Location = new System.Drawing.Point(15, 147);
            this.comboVersions.Name = "comboVersions";
            this.comboVersions.Size = new System.Drawing.Size(256, 21);
            this.comboVersions.TabIndex = 11;
            this.comboVersions.SelectedIndexChanged += new System.EventHandler(this.comboVersions_SelectedIndexChanged);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(712, 469);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(68, 23);
            this.buttonInstall.TabIndex = 8;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.install_Click);
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.InnerCircleRadius = 5;
            this.loadingCircle.Location = new System.Drawing.Point(631, 469);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.OuterCircleRadius = 11;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(75, 23);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.StylePreset = Sifon.UserControls.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.TabIndex = 51;
            this.loadingCircle.Text = "loadingCircle1";
            this.loadingCircle.Visible = false;
            // 
            // Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 520);
            this.Controls.Add(this.loadingCircle);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.groupParameters);
            this.Controls.Add(this.buttonSetDefaults);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxSql);
            this.Controls.Add(this.groupBoxSolr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Install";
            this.Text = "Siteore XP0 Installer";
            this.Load += new System.EventHandler(this.Installer_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxSql.ResumeLayout(false);
            this.groupBoxSql.PerformLayout();
            this.groupBoxSolr.ResumeLayout(false);
            this.groupBoxSolr.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxSql;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sqlServerUsernameText;
        private System.Windows.Forms.Label sqlServerLabel;
        private System.Windows.Forms.TextBox sqlServerText;
        private System.Windows.Forms.GroupBox groupBoxSolr;
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
        public System.Windows.Forms.TextBox textRemoteHostname;
        private System.Windows.Forms.Label labelHostname;
        private System.Windows.Forms.LinkLabel linkRevealRemoting;
        public System.Windows.Forms.TextBox textRemotePassword;
        private System.Windows.Forms.Label labelPassword;
        public System.Windows.Forms.TextBox textRemoteUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textDestinationFolder;
        private System.Windows.Forms.Button targetFolderButton;
        private System.Windows.Forms.Button buttonSetDefaults;
        private System.Windows.Forms.GroupBox groupParameters;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox comboVersions;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.LinkLabel revealSitecoreAdminPassword;
        public System.Windows.Forms.TextBox adminPasswordText;
        private System.Windows.Forms.LinkLabel linkRevealSqlPassword;
        public System.Windows.Forms.TextBox sqlServerPasswordText;
        private System.Windows.Forms.TextBox solrRootFolderText;
        private System.Windows.Forms.Button buttonSolrFolder;
        private System.Windows.Forms.Label sitecoreSiteLabel;
        private System.Windows.Forms.TextBox sitecoreSiteText;
        private System.Windows.Forms.CheckBox installPrerequisites;
        private System.Windows.Forms.Button buttonTestSQL;
        private System.Windows.Forms.Button buttonTestSolr;
        private System.Windows.Forms.Label label4;
        private UserControls.LoadingCircle loadingCircle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonInstallSQL;
    }
}