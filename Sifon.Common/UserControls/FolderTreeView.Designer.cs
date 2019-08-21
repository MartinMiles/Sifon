namespace Ex_TreeView
{
    partial class FolderTreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderTreeView));
            this.trwFileExplorer = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // trwFileExplorer
            // 
            this.trwFileExplorer.ImageIndex = 0;
            this.trwFileExplorer.ImageList = this.imageList1;
            this.trwFileExplorer.Location = new System.Drawing.Point(3, 0);
            this.trwFileExplorer.Name = "trwFileExplorer";
            this.trwFileExplorer.SelectedImageIndex = 0;
            this.trwFileExplorer.Size = new System.Drawing.Size(236, 341);
            this.trwFileExplorer.TabIndex = 1;
            this.trwFileExplorer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trwFileExplorer_BeforeExpand);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FOLDER.ICO");
            this.imageList1.Images.SetKeyName(1, "DVDFolderXP.ico");
            this.imageList1.Images.SetKeyName(2, "DOCL.ICO");
            // 
            // FolderTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trwFileExplorer);
            this.Name = "FolderTreeView";
            this.Size = new System.Drawing.Size(243, 346);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trwFileExplorer;
        private System.Windows.Forms.ImageList imageList1;
    }
}
