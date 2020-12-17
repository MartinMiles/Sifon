namespace Sifon.Shared.Forms.DownloaderDialog
{
    partial class Downloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloader));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboVersion = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkProdBlobAndCDN = new System.Windows.Forms.CheckBox();
            this.checkProdUpgrade = new System.Windows.Forms.CheckBox();
            this.checkProdReleaseInfo = new System.Windows.Forms.CheckBox();
            this.checkProdAzure = new System.Windows.Forms.CheckBox();
            this.checkProdOnPrem = new System.Windows.Forms.CheckBox();
            this.checkProdSIF = new System.Windows.Forms.CheckBox();
            this.checkProdContainers = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkModMigrationXDB = new System.Windows.Forms.CheckBox();
            this.checkModPublishing = new System.Windows.Forms.CheckBox();
            this.checkModJSS = new System.Windows.Forms.CheckBox();
            this.checkModIdentity = new System.Windows.Forms.CheckBox();
            this.checkModHorizon = new System.Windows.Forms.CheckBox();
            this.checkModHeadless = new System.Windows.Forms.CheckBox();
            this.checkModSXA = new System.Windows.Forms.CheckBox();
            this.checkModDEF = new System.Windows.Forms.CheckBox();
            this.checkModCMP = new System.Windows.Forms.CheckBox();
            this.checkModSalesforceCloud = new System.Windows.Forms.CheckBox();
            this.checkModSalesforce = new System.Windows.Forms.CheckBox();
            this.checkModDynamics = new System.Windows.Forms.CheckBox();
            this.checkModCLI = new System.Windows.Forms.CheckBox();
            this.buttonLocation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.linkAll = new System.Windows.Forms.LinkLabel();
            this.textDestinationFolder = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboVersion);
            this.groupBox1.Location = new System.Drawing.Point(11, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 60);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product versions";
            // 
            // comboVersion
            // 
            this.comboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVersion.FormattingEnabled = true;
            this.comboVersion.Location = new System.Drawing.Point(15, 24);
            this.comboVersion.Name = "comboVersion";
            this.comboVersion.Size = new System.Drawing.Size(164, 21);
            this.comboVersion.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkProdBlobAndCDN);
            this.groupBox2.Controls.Add(this.checkProdUpgrade);
            this.groupBox2.Controls.Add(this.checkProdReleaseInfo);
            this.groupBox2.Controls.Add(this.checkProdAzure);
            this.groupBox2.Controls.Add(this.checkProdOnPrem);
            this.groupBox2.Controls.Add(this.checkProdSIF);
            this.groupBox2.Controls.Add(this.checkProdContainers);
            this.groupBox2.Location = new System.Drawing.Point(11, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 185);
            this.groupBox2.TabIndex = 200;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product resources";
            // 
            // checkProdBlobAndCDN
            // 
            this.checkProdBlobAndCDN.AutoSize = true;
            this.checkProdBlobAndCDN.Location = new System.Drawing.Point(14, 112);
            this.checkProdBlobAndCDN.Name = "checkProdBlobAndCDN";
            this.checkProdBlobAndCDN.Size = new System.Drawing.Size(134, 17);
            this.checkProdBlobAndCDN.TabIndex = 8;
            this.checkProdBlobAndCDN.Text = "Blob Storage and CDN";
            this.checkProdBlobAndCDN.UseVisualStyleBackColor = true;
            // 
            // checkProdUpgrade
            // 
            this.checkProdUpgrade.AutoSize = true;
            this.checkProdUpgrade.Location = new System.Drawing.Point(14, 158);
            this.checkProdUpgrade.Name = "checkProdUpgrade";
            this.checkProdUpgrade.Size = new System.Drawing.Size(104, 17);
            this.checkProdUpgrade.TabIndex = 10;
            this.checkProdUpgrade.Text = "Upgrade options";
            this.checkProdUpgrade.UseVisualStyleBackColor = true;
            // 
            // checkProdReleaseInfo
            // 
            this.checkProdReleaseInfo.AutoSize = true;
            this.checkProdReleaseInfo.Location = new System.Drawing.Point(14, 135);
            this.checkProdReleaseInfo.Name = "checkProdReleaseInfo";
            this.checkProdReleaseInfo.Size = new System.Drawing.Size(119, 17);
            this.checkProdReleaseInfo.TabIndex = 9;
            this.checkProdReleaseInfo.Text = "Release information";
            this.checkProdReleaseInfo.UseVisualStyleBackColor = true;
            // 
            // checkProdAzure
            // 
            this.checkProdAzure.AutoSize = true;
            this.checkProdAzure.Location = new System.Drawing.Point(14, 89);
            this.checkProdAzure.Name = "checkProdAzure";
            this.checkProdAzure.Size = new System.Drawing.Size(111, 17);
            this.checkProdAzure.TabIndex = 7;
            this.checkProdAzure.Text = "Azure AppService";
            this.checkProdAzure.UseVisualStyleBackColor = true;
            // 
            // checkProdOnPrem
            // 
            this.checkProdOnPrem.AutoSize = true;
            this.checkProdOnPrem.Location = new System.Drawing.Point(14, 66);
            this.checkProdOnPrem.Name = "checkProdOnPrem";
            this.checkProdOnPrem.Size = new System.Drawing.Size(142, 17);
            this.checkProdOnPrem.TabIndex = 6;
            this.checkProdOnPrem.Text = "On Premises deployment";
            this.checkProdOnPrem.UseVisualStyleBackColor = true;
            // 
            // checkProdSIF
            // 
            this.checkProdSIF.AutoSize = true;
            this.checkProdSIF.Location = new System.Drawing.Point(14, 43);
            this.checkProdSIF.Name = "checkProdSIF";
            this.checkProdSIF.Size = new System.Drawing.Size(81, 17);
            this.checkProdSIF.TabIndex = 5;
            this.checkProdSIF.Text = "SIF and etc";
            this.checkProdSIF.UseVisualStyleBackColor = true;
            // 
            // checkProdContainers
            // 
            this.checkProdContainers.AutoSize = true;
            this.checkProdContainers.Location = new System.Drawing.Point(14, 20);
            this.checkProdContainers.Name = "checkProdContainers";
            this.checkProdContainers.Size = new System.Drawing.Size(133, 17);
            this.checkProdContainers.TabIndex = 4;
            this.checkProdContainers.Text = "Container deployments";
            this.checkProdContainers.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkModMigrationXDB);
            this.groupBox3.Controls.Add(this.checkModPublishing);
            this.groupBox3.Controls.Add(this.checkModJSS);
            this.groupBox3.Controls.Add(this.checkModIdentity);
            this.groupBox3.Controls.Add(this.checkModHorizon);
            this.groupBox3.Controls.Add(this.checkModHeadless);
            this.groupBox3.Controls.Add(this.checkModSXA);
            this.groupBox3.Controls.Add(this.checkModDEF);
            this.groupBox3.Controls.Add(this.checkModCMP);
            this.groupBox3.Controls.Add(this.checkModSalesforceCloud);
            this.groupBox3.Controls.Add(this.checkModSalesforce);
            this.groupBox3.Controls.Add(this.checkModDynamics);
            this.groupBox3.Controls.Add(this.checkModCLI);
            this.groupBox3.Location = new System.Drawing.Point(220, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 334);
            this.groupBox3.TabIndex = 300;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modules";
            // 
            // checkModMigrationXDB
            // 
            this.checkModMigrationXDB.AutoSize = true;
            this.checkModMigrationXDB.Location = new System.Drawing.Point(15, 301);
            this.checkModMigrationXDB.Name = "checkModMigrationXDB";
            this.checkModMigrationXDB.Size = new System.Drawing.Size(184, 17);
            this.checkModMigrationXDB.TabIndex = 23;
            this.checkModMigrationXDB.Text = "Sitecore xDB Data Migration Tool";
            this.checkModMigrationXDB.UseVisualStyleBackColor = true;
            // 
            // checkModPublishing
            // 
            this.checkModPublishing.AutoSize = true;
            this.checkModPublishing.Location = new System.Drawing.Point(15, 275);
            this.checkModPublishing.Name = "checkModPublishing";
            this.checkModPublishing.Size = new System.Drawing.Size(193, 17);
            this.checkModPublishing.TabIndex = 22;
            this.checkModPublishing.Text = "Sitecore Publishing Service Module";
            this.checkModPublishing.UseVisualStyleBackColor = true;
            // 
            // checkModJSS
            // 
            this.checkModJSS.AutoSize = true;
            this.checkModJSS.Location = new System.Drawing.Point(15, 252);
            this.checkModJSS.Name = "checkModJSS";
            this.checkModJSS.Size = new System.Drawing.Size(162, 17);
            this.checkModJSS.TabIndex = 21;
            this.checkModJSS.Text = "Sitecore JavaScript Services";
            this.checkModJSS.UseVisualStyleBackColor = true;
            // 
            // checkModIdentity
            // 
            this.checkModIdentity.AutoSize = true;
            this.checkModIdentity.Location = new System.Drawing.Point(15, 229);
            this.checkModIdentity.Name = "checkModIdentity";
            this.checkModIdentity.Size = new System.Drawing.Size(102, 17);
            this.checkModIdentity.TabIndex = 20;
            this.checkModIdentity.Text = "Sitecore Identity";
            this.checkModIdentity.UseVisualStyleBackColor = true;
            // 
            // checkModHorizon
            // 
            this.checkModHorizon.AutoSize = true;
            this.checkModHorizon.Location = new System.Drawing.Point(15, 206);
            this.checkModHorizon.Name = "checkModHorizon";
            this.checkModHorizon.Size = new System.Drawing.Size(104, 17);
            this.checkModHorizon.TabIndex = 19;
            this.checkModHorizon.Text = "Sitecore Horizon";
            this.checkModHorizon.UseVisualStyleBackColor = true;
            // 
            // checkModHeadless
            // 
            this.checkModHeadless.AutoSize = true;
            this.checkModHeadless.Location = new System.Drawing.Point(15, 183);
            this.checkModHeadless.Name = "checkModHeadless";
            this.checkModHeadless.Size = new System.Drawing.Size(164, 17);
            this.checkModHeadless.TabIndex = 18;
            this.checkModHeadless.Text = "Sitecore Headless Rendering";
            this.checkModHeadless.UseVisualStyleBackColor = true;
            // 
            // checkModSXA
            // 
            this.checkModSXA.AutoSize = true;
            this.checkModSXA.Location = new System.Drawing.Point(15, 160);
            this.checkModSXA.Name = "checkModSXA";
            this.checkModSXA.Size = new System.Drawing.Size(178, 17);
            this.checkModSXA.TabIndex = 17;
            this.checkModSXA.Text = "Sitecore Experience Accelerator";
            this.checkModSXA.UseVisualStyleBackColor = true;
            // 
            // checkModDEF
            // 
            this.checkModDEF.AutoSize = true;
            this.checkModDEF.Location = new System.Drawing.Point(15, 137);
            this.checkModDEF.Name = "checkModDEF";
            this.checkModDEF.Size = new System.Drawing.Size(197, 17);
            this.checkModDEF.TabIndex = 16;
            this.checkModDEF.Text = "Sitecore Data Exchange Framework";
            this.checkModDEF.UseVisualStyleBackColor = true;
            // 
            // checkModCMP
            // 
            this.checkModCMP.AutoSize = true;
            this.checkModCMP.Location = new System.Drawing.Point(15, 114);
            this.checkModCMP.Name = "checkModCMP";
            this.checkModCMP.Size = new System.Drawing.Size(191, 17);
            this.checkModCMP.TabIndex = 15;
            this.checkModCMP.Text = "Sitecore Connect for Sitecore CMP";
            this.checkModCMP.UseVisualStyleBackColor = true;
            // 
            // checkModSalesforceCloud
            // 
            this.checkModSalesforceCloud.AutoSize = true;
            this.checkModSalesforceCloud.Location = new System.Drawing.Point(15, 91);
            this.checkModSalesforceCloud.Name = "checkModSalesforceCloud";
            this.checkModSalesforceCloud.Size = new System.Drawing.Size(256, 17);
            this.checkModSalesforceCloud.TabIndex = 14;
            this.checkModSalesforceCloud.Text = "Sitecore Connect for Salesforce Marketing Cloud";
            this.checkModSalesforceCloud.UseVisualStyleBackColor = true;
            // 
            // checkModSalesforce
            // 
            this.checkModSalesforce.AutoSize = true;
            this.checkModSalesforce.Location = new System.Drawing.Point(15, 68);
            this.checkModSalesforce.Name = "checkModSalesforce";
            this.checkModSalesforce.Size = new System.Drawing.Size(203, 17);
            this.checkModSalesforce.TabIndex = 13;
            this.checkModSalesforce.Text = "Sitecore Connect for Salesforce CRM";
            this.checkModSalesforce.UseVisualStyleBackColor = true;
            // 
            // checkModDynamics
            // 
            this.checkModDynamics.AutoSize = true;
            this.checkModDynamics.Location = new System.Drawing.Point(15, 45);
            this.checkModDynamics.Name = "checkModDynamics";
            this.checkModDynamics.Size = new System.Drawing.Size(283, 17);
            this.checkModDynamics.TabIndex = 12;
            this.checkModDynamics.Text = "Sitecore Connect for Microsoft Dynamics 365 for Sales";
            this.checkModDynamics.UseVisualStyleBackColor = true;
            // 
            // checkModCLI
            // 
            this.checkModCLI.AutoSize = true;
            this.checkModCLI.Location = new System.Drawing.Point(15, 22);
            this.checkModCLI.Name = "checkModCLI";
            this.checkModCLI.Size = new System.Drawing.Size(84, 17);
            this.checkModCLI.TabIndex = 11;
            this.checkModCLI.Text = "Sitecore CLI";
            this.checkModCLI.UseVisualStyleBackColor = true;
            // 
            // buttonLocation
            // 
            this.buttonLocation.Location = new System.Drawing.Point(185, 30);
            this.buttonLocation.Name = "buttonLocation";
            this.buttonLocation.Size = new System.Drawing.Size(21, 22);
            this.buttonLocation.TabIndex = 2;
            this.buttonLocation.Text = "...";
            this.buttonLocation.UseVisualStyleBackColor = true;
            this.buttonLocation.Click += new System.EventHandler(this.buttonLocation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Download folder:";
            // 
            // buttonDownload
            // 
            this.buttonDownload.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDownload.Location = new System.Drawing.Point(100, 326);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(107, 23);
            this.buttonDownload.TabIndex = 24;
            this.buttonDownload.Text = "Download selected resources";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // linkAll
            // 
            this.linkAll.AutoSize = true;
            this.linkAll.Location = new System.Drawing.Point(22, 330);
            this.linkAll.Name = "linkAll";
            this.linkAll.Size = new System.Drawing.Size(64, 13);
            this.linkAll.TabIndex = 301;
            this.linkAll.TabStop = true;
            this.linkAll.Text = "Uncheck all";
            this.linkAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAll_LinkClicked);
            // 
            // textDestinationFolder
            // 
            this.textDestinationFolder.Location = new System.Drawing.Point(11, 31);
            this.textDestinationFolder.MaxLength = 255;
            this.textDestinationFolder.Name = "textDestinationFolder";
            this.textDestinationFolder.Size = new System.Drawing.Size(175, 20);
            this.textDestinationFolder.TabIndex = 1;
            this.textDestinationFolder.TextChanged += new System.EventHandler(this.textDestinationFolder_TextChanged);
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.linkAll);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.textDestinationFolder);
            this.Controls.Add(this.buttonLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Downloader";
            this.Text = "Download Sitecore Resources";
            this.Load += new System.EventHandler(this.Downloader_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkProdUpgrade;
        private System.Windows.Forms.CheckBox checkProdReleaseInfo;
        private System.Windows.Forms.CheckBox checkProdAzure;
        private System.Windows.Forms.CheckBox checkProdOnPrem;
        private System.Windows.Forms.CheckBox checkProdSIF;
        private System.Windows.Forms.CheckBox checkProdContainers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkModMigrationXDB;
        private System.Windows.Forms.CheckBox checkModPublishing;
        private System.Windows.Forms.CheckBox checkModJSS;
        private System.Windows.Forms.CheckBox checkModHeadless;
        private System.Windows.Forms.CheckBox checkModIdentity;
        private System.Windows.Forms.CheckBox checkModHorizon;
        private System.Windows.Forms.CheckBox checkModSXA;
        private System.Windows.Forms.CheckBox checkModDEF;
        private System.Windows.Forms.CheckBox checkModCMP;
        private System.Windows.Forms.CheckBox checkModSalesforceCloud;
        private System.Windows.Forms.CheckBox checkModSalesforce;
        private System.Windows.Forms.CheckBox checkModDynamics;
        private System.Windows.Forms.CheckBox checkModCLI;
        private System.Windows.Forms.Button buttonLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ComboBox comboVersion;
        private System.Windows.Forms.CheckBox checkProdBlobAndCDN;
        private System.Windows.Forms.LinkLabel linkAll;
        private System.Windows.Forms.TextBox textDestinationFolder;
    }
}