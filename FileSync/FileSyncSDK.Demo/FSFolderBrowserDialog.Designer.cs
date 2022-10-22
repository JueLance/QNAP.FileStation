namespace FileSyncDemo
{
    partial class FSFolderBrowserDialog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("/");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSFolderBrowserDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewFloder = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tvTree = new FileSyncDemo.FSTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.tbUrl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(419, 15);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(47, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(50, 17);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(362, 20);
            this.tbUrl.TabIndex = 1;
            this.tbUrl.Text = "/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNewFloder);
            this.panel2.Controls.Add(this.btnCancle);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 450);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 42);
            this.panel2.TabIndex = 1;
            // 
            // btnNewFloder
            // 
            this.btnNewFloder.Image = global::FileSyncSDK.Demo.Properties.Resources.folder_add;
            this.btnNewFloder.Location = new System.Drawing.Point(14, 9);
            this.btnNewFloder.Name = "btnNewFloder";
            this.btnNewFloder.Size = new System.Drawing.Size(97, 29);
            this.btnNewFloder.TabIndex = 2;
            this.btnNewFloder.Text = "New Folder";
            this.btnNewFloder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewFloder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewFloder.UseVisualStyleBackColor = true;
            this.btnNewFloder.Click += new System.EventHandler(this.btnNewFloder_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(390, 12);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "Cancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(289, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tvTree
            // 
            this.tvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTree.FileSync = null;
            this.tvTree.ImageKey = "folder.gif";
            this.tvTree.ImageList = this.imageList1;
            this.tvTree.Location = new System.Drawing.Point(0, 52);
            this.tvTree.Name = "tvTree";
            treeNode1.Name = "Node0";
            treeNode1.Tag = "share_root";
            treeNode1.Text = "/";
            this.tvTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvTree.SelectedImageKey = "folder.gif";
            this.tvTree.Size = new System.Drawing.Size(478, 398);
            this.tvTree.TabIndex = 2;
            this.tvTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterExpand);
            this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "excel.gif");
            this.imageList1.Images.SetKeyName(1, "exe.gif");
            this.imageList1.Images.SetKeyName(2, "folder.gif");
            this.imageList1.Images.SetKeyName(3, "image.gif");
            this.imageList1.Images.SetKeyName(4, "music.gif");
            this.imageList1.Images.SetKeyName(5, "pdf.gif");
            this.imageList1.Images.SetKeyName(6, "ppt.gif");
            this.imageList1.Images.SetKeyName(7, "rar.gif");
            this.imageList1.Images.SetKeyName(8, "txt.gif");
            this.imageList1.Images.SetKeyName(9, "undefind.gif");
            this.imageList1.Images.SetKeyName(10, "video.gif");
            this.imageList1.Images.SetKeyName(11, "word.gif");
            // 
            // FSFolderBrowserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(478, 492);
            this.Controls.Add(this.tvTree);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FSFolderBrowserDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FSFileBrowserDialog";
            this.Load += new System.EventHandler(this.FSFileBrowserDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FSFileBrowserDialog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        private FileSyncDemo.FSTreeView tvTree;
        private System.Windows.Forms.Button btnNewFloder;
        private System.Windows.Forms.ImageList imageList1;
    }
}