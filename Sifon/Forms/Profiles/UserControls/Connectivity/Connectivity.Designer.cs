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
            this.loadingCircle = new MRG.Controls.UI.LoadingCircle();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textSolr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelSolrGrid = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSqlServers = new System.Windows.Forms.ComboBox();
            this.comboSolr = new System.Windows.Forms.ComboBox();
            this.labelSqlConnection = new System.Windows.Forms.Label();
            this.buttonSqlConnection = new System.Windows.Forms.Button();
            this.groupSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSQL
            // 
            this.groupSQL.Controls.Add(this.loadingCircle);
            this.groupSQL.Controls.Add(this.buttonTest);
            this.groupSQL.Controls.Add(this.textSolr);
            this.groupSQL.Controls.Add(this.label10);
            this.groupSQL.Controls.Add(this.labelSolrGrid);
            this.groupSQL.Controls.Add(this.dataGrid);
            this.groupSQL.Controls.Add(this.label4);
            this.groupSQL.Controls.Add(this.comboSqlServers);
            this.groupSQL.Controls.Add(this.comboSolr);
            this.groupSQL.Controls.Add(this.labelSqlConnection);
            this.groupSQL.Controls.Add(this.buttonSqlConnection);
            this.groupSQL.Location = new System.Drawing.Point(5, 10);
            this.groupSQL.Name = "groupSQL";
            this.groupSQL.Size = new System.Drawing.Size(305, 295);
            this.groupSQL.TabIndex = 30;
            this.groupSQL.TabStop = false;
            this.groupSQL.Text = "Connectivity:";
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
            this.loadingCircle.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loadingCircle.TabIndex = 50;
            this.loadingCircle.Text = "loadingCircle1";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(224, 133);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(62, 23);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Solr URL (selected or manually entered):";
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
            this.dataGrid.Size = new System.Drawing.Size(267, 87);
            this.dataGrid.TabIndex = 45;
            this.dataGrid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Solr instances:";
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
            // comboSolr
            // 
            this.comboSolr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSolr.FormattingEnabled = true;
            this.comboSolr.Location = new System.Drawing.Point(19, 88);
            this.comboSolr.Name = "comboSolr";
            this.comboSolr.Size = new System.Drawing.Size(267, 21);
            this.comboSolr.TabIndex = 20;
            this.comboSolr.SelectedIndexChanged += new System.EventHandler(this.comboSolr_SelectedIndexChanged);
            // 
            // labelSqlConnection
            // 
            this.labelSqlConnection.AutoSize = true;
            this.labelSqlConnection.Location = new System.Drawing.Point(16, 23);
            this.labelSqlConnection.Name = "labelSqlConnection";
            this.labelSqlConnection.Size = new System.Drawing.Size(105, 13);
            this.labelSqlConnection.TabIndex = 10;
            this.labelSqlConnection.Text = "SQL Server instance";
            // 
            // buttonSqlConnection
            // 
            this.buttonSqlConnection.Location = new System.Drawing.Point(224, 38);
            this.buttonSqlConnection.Name = "buttonSqlConnection";
            this.buttonSqlConnection.Size = new System.Drawing.Size(62, 23);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboSqlServers;
        private System.Windows.Forms.ComboBox comboSolr;
        private System.Windows.Forms.Label labelSqlConnection;
        private System.Windows.Forms.Button buttonSqlConnection;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label labelSolrGrid;
        public System.Windows.Forms.TextBox textSolr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonTest;
        private MRG.Controls.UI.LoadingCircle loadingCircle;
    }
}
