namespace Sifon.Shared.Forms.PackageVersionSelectorDialog
{
    partial class PackageVersionSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageVersionSelector));
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.comboVersions = new System.Windows.Forms.ComboBox();
            this.groupParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupParameters
            // 
            this.groupParameters.Controls.Add(this.buttonSelect);
            this.groupParameters.Controls.Add(this.versionLabel);
            this.groupParameters.Controls.Add(this.comboVersions);
            this.groupParameters.Location = new System.Drawing.Point(12, 12);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(370, 129);
            this.groupParameters.TabIndex = 2;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Which version of package would you like to install?";
            // 
            // buttonSelect
            // 
            this.buttonSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSelect.Location = new System.Drawing.Point(273, 88);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(18, 31);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(73, 13);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "Please select:";
            // 
            // comboVersions
            // 
            this.comboVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVersions.FormattingEnabled = true;
            this.comboVersions.Location = new System.Drawing.Point(21, 47);
            this.comboVersions.Name = "comboVersions";
            this.comboVersions.Size = new System.Drawing.Size(327, 21);
            this.comboVersions.TabIndex = 0;
            // 
            // PackageVersionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 152);
            this.Controls.Add(this.groupParameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PackageVersionSelector";
            this.Text = "Package Version Selector";
            this.Load += new System.EventHandler(this.PackageVersionSelector_Load);
            this.groupParameters.ResumeLayout(false);
            this.groupParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupParameters;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox comboVersions;
    }
}