namespace Sifon.Shared.Forms.SitecoreVersionSelectorDialog
{
    partial class SitecoreVersionSelector
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
            this.groupParameters.Size = new System.Drawing.Size(265, 129);
            this.groupParameters.TabIndex = 1;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Please select Sitecore version:";
            // 
            // buttonSelect
            // 
            this.buttonSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSelect.Location = new System.Drawing.Point(172, 87);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonPatch_Click);
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
            this.comboVersions.Size = new System.Drawing.Size(226, 21);
            this.comboVersions.TabIndex = 0;
            // 
            // VersionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 153);
            this.Controls.Add(this.groupParameters);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SitecoreVersionSelector";
            this.Text = "Sitecore version selector";
            this.Load += new System.EventHandler(this.Form_Load);
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