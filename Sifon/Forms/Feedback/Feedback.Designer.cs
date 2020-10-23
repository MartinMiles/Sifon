namespace Sifon.Forms.Feedback
{
    partial class Feedback
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.textFeedback = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.labelFullnme = new System.Windows.Forms.Label();
            this.textFullname = new System.Windows.Forms.TextBox();
            this.labelGiudance = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.labelFeedback);
            this.groupBox.Controls.Add(this.textFeedback);
            this.groupBox.Controls.Add(this.labelEmail);
            this.groupBox.Controls.Add(this.textEmail);
            this.groupBox.Controls.Add(this.labelFullnme);
            this.groupBox.Controls.Add(this.textFullname);
            this.groupBox.Controls.Add(this.labelGiudance);
            this.groupBox.Controls.Add(this.buttonSubmit);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(335, 308);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Program settings:";
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Location = new System.Drawing.Point(25, 157);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(125, 13);
            this.labelFeedback.TabIndex = 7;
            this.labelFeedback.Text = "Your feedback message:";
            // 
            // textFeedback
            // 
            this.textFeedback.Location = new System.Drawing.Point(28, 173);
            this.textFeedback.Multiline = true;
            this.textFeedback.Name = "textFeedback";
            this.textFeedback.Size = new System.Drawing.Size(288, 79);
            this.textFeedback.TabIndex = 6;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(25, 110);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(99, 13);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "Your email address:";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(28, 126);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(288, 20);
            this.textEmail.TabIndex = 4;
            // 
            // labelFullnme
            // 
            this.labelFullnme.AutoSize = true;
            this.labelFullnme.Location = new System.Drawing.Point(25, 59);
            this.labelFullnme.Name = "labelFullnme";
            this.labelFullnme.Size = new System.Drawing.Size(61, 13);
            this.labelFullnme.TabIndex = 3;
            this.labelFullnme.Text = "Your name:";
            // 
            // textFullname
            // 
            this.textFullname.Location = new System.Drawing.Point(28, 75);
            this.textFullname.Name = "textFullname";
            this.textFullname.Size = new System.Drawing.Size(288, 20);
            this.textFullname.TabIndex = 2;
            // 
            // labelGiudance
            // 
            this.labelGiudance.AutoSize = true;
            this.labelGiudance.Location = new System.Drawing.Point(25, 32);
            this.labelGiudance.Name = "labelGiudance";
            this.labelGiudance.Size = new System.Drawing.Size(288, 13);
            this.labelGiudance.TabIndex = 1;
            this.labelGiudance.Text = "Please enter your feedback. I do respond to your proposals.";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(241, 270);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 0;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 332);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Feedback";
            this.Text = "Feedback";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.TextBox textFeedback;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label labelFullnme;
        private System.Windows.Forms.TextBox textFullname;
        private System.Windows.Forms.Label labelGiudance;
    }
}