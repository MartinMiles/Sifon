namespace Sifon.Forms.Other
{
    partial class FirstTimeRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstTimeRun));
            this.labelWarn3 = new System.Windows.Forms.Label();
            this.labelWarn2 = new System.Windows.Forms.Label();
            this.labelWarn1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonPrerequsites = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonUnderstand = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWarn3
            // 
            this.labelWarn3.AutoSize = true;
            this.labelWarn3.ForeColor = System.Drawing.Color.Red;
            this.labelWarn3.Location = new System.Drawing.Point(16, 73);
            this.labelWarn3.Name = "labelWarn3";
            this.labelWarn3.Size = new System.Drawing.Size(281, 13);
            this.labelWarn3.TabIndex = 14;
            this.labelWarn3.Text = "as well as other parameters before the first run and save it.";
            // 
            // labelWarn2
            // 
            this.labelWarn2.AutoSize = true;
            this.labelWarn2.ForeColor = System.Drawing.Color.Red;
            this.labelWarn2.Location = new System.Drawing.Point(16, 57);
            this.labelWarn2.Name = "labelWarn2";
            this.labelWarn2.Size = new System.Drawing.Size(279, 13);
            this.labelWarn2.TabIndex = 13;
            this.labelWarn2.Text = "Please change the profile name, prefix, website root folder";
            // 
            // labelWarn1
            // 
            this.labelWarn1.AutoSize = true;
            this.labelWarn1.ForeColor = System.Drawing.Color.Red;
            this.labelWarn1.Location = new System.Drawing.Point(16, 31);
            this.labelWarn1.Name = "labelWarn1";
            this.labelWarn1.Size = new System.Drawing.Size(151, 13);
            this.labelWarn1.TabIndex = 12;
            this.labelWarn1.Text = "Since this is your first time run..";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Once done, you\'ll be able to process with the rest of the";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(16, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "settings - as the bare minimun requres choosing a website ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "folder, setting and testing SQL and Solr connectivity. ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPrerequsites);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonUnderstand);
            this.groupBox1.Controls.Add(this.labelWarn1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelWarn2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelWarn3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 254);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "May I have your attention, please?";
            // 
            // buttonPrerequsites
            // 
            this.buttonPrerequsites.Location = new System.Drawing.Point(19, 214);
            this.buttonPrerequsites.Name = "buttonPrerequsites";
            this.buttonPrerequsites.Size = new System.Drawing.Size(114, 23);
            this.buttonPrerequsites.TabIndex = 1;
            this.buttonPrerequsites.Text = "Prerequsites check";
            this.buttonPrerequsites.UseVisualStyleBackColor = true;
            this.buttonPrerequsites.Click += new System.EventHandler(this.buttonPrerequsites_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(16, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "one profile (local or remote) set up correctly and selected.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(16, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Most Sifon features will not become available until at least ";
            // 
            // buttonUnderstand
            // 
            this.buttonUnderstand.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonUnderstand.Location = new System.Drawing.Point(183, 214);
            this.buttonUnderstand.Name = "buttonUnderstand";
            this.buttonUnderstand.Size = new System.Drawing.Size(114, 23);
            this.buttonUnderstand.TabIndex = 2;
            this.buttonUnderstand.Text = "I understand that";
            this.buttonUnderstand.UseVisualStyleBackColor = true;
            this.buttonUnderstand.Click += new System.EventHandler(this.buttonUnderstand_Click);
            // 
            // FirstTimeRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 286);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstTimeRun";
            this.Text = "Welcome to Sifon!";
            this.Load += new System.EventHandler(this.FirstTimeRun_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWarn3;
        private System.Windows.Forms.Label labelWarn2;
        private System.Windows.Forms.Label labelWarn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonUnderstand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPrerequsites;
    }
}