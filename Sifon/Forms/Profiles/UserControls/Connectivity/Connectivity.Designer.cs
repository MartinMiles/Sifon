namespace Sifon.Forms.Profiles.UserControls.Connectivity
{
    partial class Connectivity
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
            this.groupSQL = new System.Windows.Forms.GroupBox();
            this.buttonInstallSolr = new System.Windows.Forms.Button();
            this.loadingCircle = new Sifon.UserControls.LoadingCircle();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textSolr = new System.Windows.Forms.TextBox();
            this.labelSolr = new System.Windows.Forms.Label();
            this.labelSolrGrid = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.labelSolrInstances = new System.Windows.Forms.Label();
            this.comboSqlServers = new System.Windows.Forms.ComboBox();
            this.comboSolrInstances = new System.Windows.Forms.ComboBox();
            this.labelSqlServers = new System.Windows.Forms.Label();
            this.buttonSqlConnection = new System.Windows.Forms.Button();
            this.groupSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSQL
            // 
            this.groupSQL.Controls.Add(this.buttonInstallSolr);
            this.groupSQL.Controls.Add(this.loadingCircle);
            this.groupSQL.Controls.Add(this.buttonTest);
            this.groupSQL.Controls.Add(this.textSolr);
            this.groupSQL.Controls.Add(this.labelSolr);
            this.groupSQL.Controls.Add(this.labelSolrGrid);
            this.groupSQL.Controls.Add(this.dataGrid);
            this.groupSQL.Controls.Add(this.labelSolrInstances);
            this.groupSQL.Controls.Add(this.comboSqlServers);
            this.groupSQL.Controls.Add(this.comboSolrInstances);
            this.groupSQL.Controls.Add(this.labelSqlServers);
            this.groupSQL.Controls.Add(this.buttonSqlConnection);
            this.groupSQL.Location = new System.Drawing.Point(5, 10);
            this.groupSQL.Name = "groupSQL";
            this.groupSQL.Size = new System.Drawing.Size(305, 295);
            this.groupSQL.TabIndex = 30;
            this.groupSQL.TabStop = false;
            this.groupSQL.Text = "Connectivity:";
            // 
            // buttonInstallSolr
            // 
            this.buttonInstallSolr.Location = new System.Drawing.Point(224, 86);
            this.buttonInstallSolr.Name = "buttonInstallSolr";
            this.buttonInstallSolr.Size = new System.Drawing.Size(65, 23);
            this.buttonInstallSolr.TabIndex = 51;
            this.buttonInstallSolr.Text = "Install Solr";
            this.buttonInstallSolr.UseVisualStyleBackColor = true;
            this.buttonInstallSolr.Click += new System.EventHandler(this.buttonInstallSolr_Click);
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = false;
            this.loadingCircle.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle.InnerCircleRadius = 5;
            this.loadingCircle.Location = new System.Drawing.Point(109, 218);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.OuterCircleRadius = 11;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(75, 23);
            this.loadingCircle.SpokeThickness = 2;
            this.loadingCircle.StylePreset = Sifon.UserControls.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.TabIndex = 50;
            this.loadingCircle.Text = "loadingCircle1";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(224, 135);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(65, 22);
            this.buttonTest.TabIndex = 49;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.test_Click);
            // 
            // textSolr
            // 
            this.textSolr.Location = new System.Drawing.Point(19, 136);
            this.textSolr.Name = "textSolr";
            this.textSolr.Size = new System.Drawing.Size(199, 20);
            this.textSolr.TabIndex = 48;
            // 
            // labelSolr
            // 
            this.labelSolr.AutoSize = true;
            this.labelSolr.Location = new System.Drawing.Point(16, 120);
            this.labelSolr.Name = "labelSolr";
            this.labelSolr.Size = new System.Drawing.Size(197, 13);
            this.labelSolr.TabIndex = 47;
            this.labelSolr.Text = "Solr URL (selected or manually entered):";
            // 
            // labelSolrGrid
            // 
            this.labelSolrGrid.AutoSize = true;
            this.labelSolrGrid.Location = new System.Drawing.Point(16, 174);
            this.labelSolrGrid.Name = "labelSolrGrid";
            this.labelSolrGrid.Size = new System.Drawing.Size(0, 13);
            this.labelSolrGrid.TabIndex = 46;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(19, 190);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.Size = new System.Drawing.Size(270, 87);
            this.dataGrid.TabIndex = 45;
            this.dataGrid.Visible = false;
            // 
            // labelSolrInstances
            // 
            this.labelSolrInstances.AutoSize = true;
            this.labelSolrInstances.Location = new System.Drawing.Point(16, 72);
            this.labelSolrInstances.Name = "labelSolrInstances";
            this.labelSolrInstances.Size = new System.Drawing.Size(145, 13);
            this.labelSolrInstances.TabIndex = 6;
            this.labelSolrInstances.Text = "Solr instances auto-detected:";
            // 
            // comboSqlServers
            // 
            this.comboSqlServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSqlServers.FormattingEnabled = true;
            this.comboSqlServers.Location = new System.Drawing.Point(19, 39);
            this.comboSqlServers.Name = "comboSqlServers";
            this.comboSqlServers.Size = new System.Drawing.Size(199, 21);
            this.comboSqlServers.TabIndex = 16;
            // 
            // comboSolrInstances
            // 
            this.comboSolrInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSolrInstances.FormattingEnabled = true;
            this.comboSolrInstances.Location = new System.Drawing.Point(19, 88);
            this.comboSolrInstances.Name = "comboSolrInstances";
            this.comboSolrInstances.Size = new System.Drawing.Size(199, 21);
            this.comboSolrInstances.TabIndex = 20;
            this.comboSolrInstances.SelectedIndexChanged += new System.EventHandler(this.comboSolr_SelectedIndexChanged);
            // 
            // labelSqlServers
            // 
            this.labelSqlServers.AutoSize = true;
            this.labelSqlServers.Location = new System.Drawing.Point(16, 23);
            this.labelSqlServers.Name = "labelSqlServers";
            this.labelSqlServers.Size = new System.Drawing.Size(105, 13);
            this.labelSqlServers.TabIndex = 10;
            this.labelSqlServers.Text = "SQL Server instance";
            // 
            // buttonSqlConnection
            // 
            this.buttonSqlConnection.Location = new System.Drawing.Point(224, 38);
            this.buttonSqlConnection.Name = "buttonSqlConnection";
            this.buttonSqlConnection.Size = new System.Drawing.Size(65, 23);
            this.buttonSqlConnection.TabIndex = 17;
            this.buttonSqlConnection.Text = "Edit";
            this.buttonSqlConnection.UseVisualStyleBackColor = true;
            this.buttonSqlConnection.Click += new System.EventHandler(this.buttonSqlConnection_Click);
            // 
            // Connectivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupSQL);
            this.Name = "Connectivity";
            this.Size = new System.Drawing.Size(316, 312);
            this.groupSQL.ResumeLayout(false);
            this.groupSQL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSQL;
        private System.Windows.Forms.Label labelSolrInstances;
        private System.Windows.Forms.ComboBox comboSqlServers;
        private System.Windows.Forms.ComboBox comboSolrInstances;
        private System.Windows.Forms.Label labelSqlServers;
        private System.Windows.Forms.Button buttonSqlConnection;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label labelSolrGrid;
        public System.Windows.Forms.TextBox textSolr;
        private System.Windows.Forms.Label labelSolr;
        private System.Windows.Forms.Button buttonTest;
        private Sifon.UserControls.LoadingCircle loadingCircle;
        private System.Windows.Forms.Button buttonInstallSolr;
    }
}
