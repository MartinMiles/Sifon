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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonWebrootCD = new System.Windows.Forms.Button();
            this.textWebrootCD = new System.Windows.Forms.TextBox();
            this.comboWebsitesCD = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.labelWebsiteCM = new System.Windows.Forms.Label();
            this.labelWebrootCM = new System.Windows.Forms.Label();
            this.labelGrid = new System.Windows.Forms.Label();
            this.comboWebsites = new System.Windows.Forms.ComboBox();
            this.buttonWebroot = new System.Windows.Forms.Button();
            this.textWebroot = new System.Windows.Forms.TextBox();
            this.labelWebsiteCD = new System.Windows.Forms.Label();
            this.labelWebrootCD = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelWebrootCD);
            this.groupBox3.Controls.Add(this.labelWebsiteCD);
            this.groupBox3.Controls.Add(this.buttonWebrootCD);
            this.groupBox3.Controls.Add(this.textWebrootCD);
            this.groupBox3.Controls.Add(this.comboWebsitesCD);
            this.groupBox3.Controls.Add(this.dataGrid);
            this.groupBox3.Controls.Add(this.labelWebsiteCM);
            this.groupBox3.Controls.Add(this.labelWebrootCM);
            this.groupBox3.Controls.Add(this.labelGrid);
            this.groupBox3.Controls.Add(this.comboWebsites);
            this.groupBox3.Controls.Add(this.buttonWebroot);
            this.groupBox3.Controls.Add(this.textWebroot);
            this.groupBox3.Location = new System.Drawing.Point(10, 19);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(610, 567);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instance info:";
            // 
            // buttonWebrootCD
            // 
            this.buttonWebrootCD.Location = new System.Drawing.Point(516, 174);
            this.buttonWebrootCD.Margin = new System.Windows.Forms.Padding(6);
            this.buttonWebrootCD.Name = "buttonWebrootCD";
            this.buttonWebrootCD.Size = new System.Drawing.Size(78, 42);
            this.buttonWebrootCD.TabIndex = 47;
            this.buttonWebrootCD.Text = "...";
            this.buttonWebrootCD.UseVisualStyleBackColor = true;
            this.buttonWebrootCD.Click += new System.EventHandler(this.buttonWebrootCD_Click);
            // 
            // textWebrootCD
            // 
            this.textWebrootCD.Location = new System.Drawing.Point(270, 174);
            this.textWebrootCD.Margin = new System.Windows.Forms.Padding(6);
            this.textWebrootCD.Name = "textWebrootCD";
            this.textWebrootCD.Size = new System.Drawing.Size(225, 20);
            this.textWebrootCD.TabIndex = 46;
            // 
            // comboWebsitesCD
            // 
            this.comboWebsitesCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWebsitesCD.FormattingEnabled = true;
            this.comboWebsitesCD.Location = new System.Drawing.Point(38, 174);
            this.comboWebsitesCD.Margin = new System.Windows.Forms.Padding(6);
            this.comboWebsitesCD.Name = "comboWebsitesCD";
            this.comboWebsitesCD.Size = new System.Drawing.Size(225, 33);
            this.comboWebsitesCD.TabIndex = 45;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGrid.Location = new System.Drawing.Point(38, 306);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(6);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidth = 82;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.Size = new System.Drawing.Size(526, 212);
            this.dataGrid.TabIndex = 44;
            // 
            // labelWebsiteCM
            // 
            this.labelWebsiteCM.AutoSize = true;
            this.labelWebsiteCM.Location = new System.Drawing.Point(30, 39);
            this.labelWebsiteCM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelWebsiteCM.Name = "labelWebsiteCM";
            this.labelWebsiteCM.Size = new System.Drawing.Size(65, 13);
            this.labelWebsiteCM.TabIndex = 3;
            this.labelWebsiteCM.Text = "CM website:";
            // 
            // labelWebrootCM
            // 
            this.labelWebrootCM.AutoSize = true;
            this.labelWebrootCM.Location = new System.Drawing.Point(267, 47);
            this.labelWebrootCM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelWebrootCM.Name = "labelWebrootCM";
            this.labelWebrootCM.Size = new System.Drawing.Size(115, 13);
            this.labelWebrootCM.TabIndex = 11;
            this.labelWebrootCM.Text = "CM website root folder:";
            // 
            // labelGrid
            // 
            this.labelGrid.AutoSize = true;
            this.labelGrid.Location = new System.Drawing.Point(30, 256);
            this.labelGrid.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelGrid.Name = "labelGrid";
            this.labelGrid.Size = new System.Drawing.Size(169, 13);
            this.labelGrid.TabIndex = 9;
            this.labelGrid.Text = "Bindings for the selected instance:";
            // 
            // comboWebsites
            // 
            this.comboWebsites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWebsites.FormattingEnabled = true;
            this.comboWebsites.Location = new System.Drawing.Point(38, 87);
            this.comboWebsites.Margin = new System.Windows.Forms.Padding(6);
            this.comboWebsites.Name = "comboWebsites";
            this.comboWebsites.Size = new System.Drawing.Size(225, 33);
            this.comboWebsites.TabIndex = 30;
            // 
            // buttonWebroot
            // 
            this.buttonWebroot.Location = new System.Drawing.Point(521, 87);
            this.buttonWebroot.Margin = new System.Windows.Forms.Padding(6);
            this.buttonWebroot.Name = "buttonWebroot";
            this.buttonWebroot.Size = new System.Drawing.Size(78, 42);
            this.buttonWebroot.TabIndex = 41;
            this.buttonWebroot.Text = "...";
            this.buttonWebroot.UseVisualStyleBackColor = true;
            this.buttonWebroot.Click += new System.EventHandler(this.buttonWebroot_Click);
            // 
            // textWebroot
            // 
            this.textWebroot.Location = new System.Drawing.Point(275, 87);
            this.textWebroot.Margin = new System.Windows.Forms.Padding(6);
            this.textWebroot.Name = "textWebroot";
            this.textWebroot.Size = new System.Drawing.Size(225, 20);
            this.textWebroot.TabIndex = 40;
            // 
            // labelWebsiteCD
            // 
            this.labelWebsiteCD.AutoSize = true;
            this.labelWebsiteCD.Location = new System.Drawing.Point(30, 145);
            this.labelWebsiteCD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelWebsiteCD.Name = "labelWebsiteCD";
            this.labelWebsiteCD.Size = new System.Drawing.Size(64, 13);
            this.labelWebsiteCD.TabIndex = 48;
            this.labelWebsiteCD.Text = "CD website:";
            // 
            // labelWebrootCD
            // 
            this.labelWebrootCD.AutoSize = true;
            this.labelWebrootCD.Location = new System.Drawing.Point(267, 145);
            this.labelWebrootCD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelWebrootCD.Name = "labelWebrootCD";
            this.labelWebrootCD.Size = new System.Drawing.Size(114, 13);
            this.labelWebrootCD.TabIndex = 49;
            this.labelWebrootCD.Text = "CD website root folder:";
            // 
            // Website
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Website";
            this.Size = new System.Drawing.Size(634, 596);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelWebsiteCM;
        private System.Windows.Forms.Label labelWebrootCM;
        private System.Windows.Forms.Label labelGrid;
        private System.Windows.Forms.ComboBox comboWebsites;
        private System.Windows.Forms.Button buttonWebroot;
        private System.Windows.Forms.TextBox textWebroot;
        private DataGridView dataGrid;
        private ComboBox comboWebsitesCD;
        private Button buttonWebrootCD;
        private TextBox textWebrootCD;
        private Label labelWebsiteCD;
        private Label labelWebrootCD;
    }
}
