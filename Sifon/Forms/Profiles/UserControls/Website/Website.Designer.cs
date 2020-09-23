using System.Windows.Forms;

namespace Sifon.Forms.Profiles.UserControls.Website
{
    partial class Website
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.labelWebsites = new System.Windows.Forms.Label();
            this.labelWebroot = new System.Windows.Forms.Label();
            this.labelGrid = new System.Windows.Forms.Label();
            this.comboWebsites = new System.Windows.Forms.ComboBox();
            this.buttonWebroot = new System.Windows.Forms.Button();
            this.textWebroot = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGrid);
            this.groupBox3.Controls.Add(this.labelWebsites);
            this.groupBox3.Controls.Add(this.labelWebroot);
            this.groupBox3.Controls.Add(this.labelGrid);
            this.groupBox3.Controls.Add(this.comboWebsites);
            this.groupBox3.Controls.Add(this.buttonWebroot);
            this.groupBox3.Controls.Add(this.textWebroot);
            this.groupBox3.Location = new System.Drawing.Point(5, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 295);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instance info:";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(19, 159);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.Size = new System.Drawing.Size(263, 110);
            this.dataGrid.TabIndex = 44;
            // 
            // labelWebsites
            // 
            this.labelWebsites.AutoSize = true;
            this.labelWebsites.Location = new System.Drawing.Point(15, 26);
            this.labelWebsites.Name = "labelWebsites";
            this.labelWebsites.Size = new System.Drawing.Size(62, 13);
            this.labelWebsites.TabIndex = 3;
            this.labelWebsites.Text = "IIS website:";
            // 
            // labelWebroot
            // 
            this.labelWebroot.AutoSize = true;
            this.labelWebroot.Location = new System.Drawing.Point(15, 87);
            this.labelWebroot.Name = "labelWebroot";
            this.labelWebroot.Size = new System.Drawing.Size(99, 13);
            this.labelWebroot.TabIndex = 11;
            this.labelWebroot.Text = "Website root folder:";
            // 
            // labelGrid
            // 
            this.labelGrid.AutoSize = true;
            this.labelGrid.Location = new System.Drawing.Point(15, 139);
            this.labelGrid.Name = "labelGrid";
            this.labelGrid.Size = new System.Drawing.Size(169, 13);
            this.labelGrid.TabIndex = 9;
            this.labelGrid.Text = "Bindings for the selected instance:";
            // 
            // comboWebsites
            // 
            this.comboWebsites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWebsites.FormattingEnabled = true;
            this.comboWebsites.Location = new System.Drawing.Point(19, 45);
            this.comboWebsites.Name = "comboWebsites";
            this.comboWebsites.Size = new System.Drawing.Size(263, 21);
            this.comboWebsites.TabIndex = 30;
            this.comboWebsites.SelectedIndexChanged += new System.EventHandler(this.comboWebsites_SelectedIndexChanged);
            // 
            // buttonWebroot
            // 
            this.buttonWebroot.Location = new System.Drawing.Point(243, 101);
            this.buttonWebroot.Name = "buttonWebroot";
            this.buttonWebroot.Size = new System.Drawing.Size(39, 22);
            this.buttonWebroot.TabIndex = 41;
            this.buttonWebroot.Text = "...";
            this.buttonWebroot.UseVisualStyleBackColor = true;
            this.buttonWebroot.Click += new System.EventHandler(this.buttonWebroot_Click);
            // 
            // textWebroot
            // 
            this.textWebroot.Location = new System.Drawing.Point(19, 102);
            this.textWebroot.Name = "textWebroot";
            this.textWebroot.Size = new System.Drawing.Size(225, 20);
            this.textWebroot.TabIndex = 40;
            this.textWebroot.TextChanged += new System.EventHandler(this.textWebroot_TextChanged);
            // 
            // Website
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "Website";
            this.Size = new System.Drawing.Size(317, 310);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelWebsites;
        private System.Windows.Forms.Label labelWebroot;
        private System.Windows.Forms.Label labelGrid;
        private System.Windows.Forms.ComboBox comboWebsites;
        private System.Windows.Forms.Button buttonWebroot;
        private System.Windows.Forms.TextBox textWebroot;
        private DataGridView dataGrid;
    }
}
