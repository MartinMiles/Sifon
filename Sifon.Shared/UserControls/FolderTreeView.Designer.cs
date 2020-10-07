namespace Sifon.Code.UserControls
{
    partial class FolderTreeView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderTreeView));
            this.fileExplorer = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // trwFileExplorer
            // 
            this.fileExplorer.ImageIndex = 0;
            this.fileExplorer.ImageList = this.imageList;
            this.fileExplorer.LabelEdit = true;
            this.fileExplorer.Location = new System.Drawing.Point(0, 0);
            this.fileExplorer.Name = "fileExplorer";
            this.fileExplorer.SelectedImageIndex = 0;
            this.fileExplorer.Size = new System.Drawing.Size(400, 360);
            this.fileExplorer.TabIndex = 1;
            this.fileExplorer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trwFileExplorer_BeforeExpand);
            this.fileExplorer.DoubleClick += new System.EventHandler(this.trwFileExplorer_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "FOLDER.ICO");
            this.imageList.Images.SetKeyName(1, "DVDFolderXP.ico");
            this.imageList.Images.SetKeyName(2, "DOCL.ICO");
            // 
            // FolderTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileExplorer);
            this.Name = "FolderTreeView";
            this.Size = new System.Drawing.Size(400, 360);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView fileExplorer;
        private System.Windows.Forms.ImageList imageList;
    }
}
