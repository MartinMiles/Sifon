using Sifon.Forms.Profiles.UserControls.Connectivity;
using Sifon.Forms.Profiles.UserControls.Profile;
using Sifon.Forms.Profiles.UserControls.Remote;
using Sifon.Forms.Profiles.UserControls.Website;

namespace Sifon.Forms.Profiles
{
    partial class Profiles
    {
        private System.ComponentModel.IContainer components = null;

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
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tabRemote = new System.Windows.Forms.TabPage();
            this.tabWebsite = new System.Windows.Forms.TabPage();
            this.tabConnectivity = new System.Windows.Forms.TabPage();
            this.tabParameters = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(239, 354);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(95, 26);
            this.buttonSave.TabIndex = 45;
            this.buttonSave.Text = "Save and close";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Controls.Add(this.tabRemote);
            this.tabControl1.Controls.Add(this.tabWebsite);
            this.tabControl1.Controls.Add(this.tabConnectivity);
            this.tabControl1.Controls.Add(this.tabParameters);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(325, 335);
            this.tabControl1.TabIndex = 46;
            // 
            // tabProfile
            // 
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(317, 309);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // tabRemote
            // 
            this.tabRemote.Location = new System.Drawing.Point(4, 22);
            this.tabRemote.Name = "tabRemote";
            this.tabRemote.Padding = new System.Windows.Forms.Padding(3);
            this.tabRemote.Size = new System.Drawing.Size(317, 309);
            this.tabRemote.TabIndex = 1;
            this.tabRemote.Text = "Remote";
            this.tabRemote.UseVisualStyleBackColor = true;
            // 
            // tabWebsite
            // 
            this.tabWebsite.Location = new System.Drawing.Point(4, 22);
            this.tabWebsite.Name = "tabWebsite";
            this.tabWebsite.Size = new System.Drawing.Size(317, 309);
            this.tabWebsite.TabIndex = 2;
            this.tabWebsite.Text = "Website";
            this.tabWebsite.UseVisualStyleBackColor = true;
            // 
            // tabConnectivity
            // 
            this.tabConnectivity.Location = new System.Drawing.Point(4, 22);
            this.tabConnectivity.Name = "tabConnectivity";
            this.tabConnectivity.Size = new System.Drawing.Size(317, 309);
            this.tabConnectivity.TabIndex = 3;
            this.tabConnectivity.Text = "Connectivity";
            this.tabConnectivity.UseVisualStyleBackColor = true;
            // 
            // tabParameters
            // 
            this.tabParameters.Location = new System.Drawing.Point(4, 22);
            this.tabParameters.Name = "tabParameters";
            this.tabParameters.Size = new System.Drawing.Size(317, 309);
            this.tabParameters.TabIndex = 4;
            this.tabParameters.Text = "Additional params";
            this.tabParameters.UseVisualStyleBackColor = true;
            // 
            // Profiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 392);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Profiles";
            this.Text = "Profiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Profiles_FormClosing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabRemote;
        private System.Windows.Forms.TabPage tabWebsite;
        private System.Windows.Forms.TabPage tabConnectivity;
        private System.Windows.Forms.TabPage tabParameters;
    }
}