namespace FileSyncDemo
{
    partial class MainFrm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("12345678");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("12345678");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("12345678");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("/");
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cmFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.tsView = new System.Windows.Forms.ToolStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenametoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpload = new System.Windows.Forms.ToolStripButton();
            this.tsbNewFolder = new System.Windows.Forms.ToolStripButton();
            this.tsViewMode = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tvTree = new FileSyncDemo.FSTreeView();
            this.cmFile.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tsView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(931, 92);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.cmFile;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.LargeImageList = this.imgLarge;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(690, 369);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // cmFile
            // 
            this.cmFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator3,
            this.deleteToolStripMenuItem,
            this.RenametoolStripMenuItem,
            this.toolStripSeparator1,
            this.propertyToolStripMenuItem});
            this.cmFile.Name = "cmFile";
            this.cmFile.Size = new System.Drawing.Size(120, 198);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(116, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(116, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // propertyToolStripMenuItem
            // 
            this.propertyToolStripMenuItem.Name = "propertyToolStripMenuItem";
            this.propertyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.propertyToolStripMenuItem.Text = "Property";
            this.propertyToolStripMenuItem.Click += new System.EventHandler(this.propertyToolStripMenuItem_Click);
            // 
            // imgLarge
            // 
            this.imgLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLarge.ImageStream")));
            this.imgLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLarge.Images.SetKeyName(0, "access.gif");
            this.imgLarge.Images.SetKeyName(1, "chm.gif");
            this.imgLarge.Images.SetKeyName(2, "excel.gif");
            this.imgLarge.Images.SetKeyName(3, "exe.gif");
            this.imgLarge.Images.SetKeyName(4, "favorite.gif");
            this.imgLarge.Images.SetKeyName(5, "flash.gif");
            this.imgLarge.Images.SetKeyName(6, "folder.gif");
            this.imgLarge.Images.SetKeyName(7, "folder_document.gif");
            this.imgLarge.Images.SetKeyName(8, "folder_file.gif");
            this.imgLarge.Images.SetKeyName(9, "folder_music.gif");
            this.imgLarge.Images.SetKeyName(10, "folder_photo.gif");
            this.imgLarge.Images.SetKeyName(11, "folder_video.gif");
            this.imgLarge.Images.SetKeyName(12, "image.gif");
            this.imgLarge.Images.SetKeyName(13, "location.png");
            this.imgLarge.Images.SetKeyName(14, "multi.gif");
            this.imgLarge.Images.SetKeyName(15, "music.gif");
            this.imgLarge.Images.SetKeyName(16, "pdf.gif");
            this.imgLarge.Images.SetKeyName(17, "ppt.gif");
            this.imgLarge.Images.SetKeyName(18, "publicfolder.gif");
            this.imgLarge.Images.SetKeyName(19, "rar.gif");
            this.imgLarge.Images.SetKeyName(20, "recent.gif");
            this.imgLarge.Images.SetKeyName(21, "recycle.gif");
            this.imgLarge.Images.SetKeyName(22, "shared.gif");
            this.imgLarge.Images.SetKeyName(23, "txt.gif");
            this.imgLarge.Images.SetKeyName(24, "undefind.gif");
            this.imgLarge.Images.SetKeyName(25, "video.gif");
            this.imgLarge.Images.SetKeyName(26, "word.gif");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "mime_folder.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tsView
            // 
            this.tsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpload,
            this.tsbNewFolder,
            this.tsViewMode});
            this.tsView.Location = new System.Drawing.Point(0, 39);
            this.tsView.Name = "tsView";
            this.tsView.Size = new System.Drawing.Size(931, 25);
            this.tsView.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.tsView);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(931, 551);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 64);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvTree);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listView1);
            this.splitContainer2.Size = new System.Drawing.Size(931, 369);
            this.splitContainer2.SplitterDistance = 237;
            this.splitContainer2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbUrl);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 39);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(866, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(11, 10);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(836, 20);
            this.tbUrl.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 92);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDisconnect,
            this.toolStripSeparator4,
            this.tsmExit});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(51, 20);
            this.tsmFile.Text = "File(&F)";
            // 
            // tsmDisconnect
            // 
            this.tsmDisconnect.Name = "tsmDisconnect";
            this.tsmDisconnect.Size = new System.Drawing.Size(133, 22);
            this.tsmDisconnect.Text = "Disconnect";
            this.tsmDisconnect.Click += new System.EventHandler(this.tsmDisconnect_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(130, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::FileSyncDemo.Demo.Properties.Resources.arrow_refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::FileSyncDemo.Demo.Properties.Resources.page_copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Image = global::FileSyncDemo.Demo.Properties.Resources.folder_go;
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::FileSyncDemo.Demo.Properties.Resources.disk;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem1.Text = "Save As";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::FileSyncDemo.Demo.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // RenametoolStripMenuItem
            // 
            this.RenametoolStripMenuItem.Image = global::FileSyncDemo.Demo.Properties.Resources.drive_rename;
            this.RenametoolStripMenuItem.Name = "RenametoolStripMenuItem";
            this.RenametoolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.RenametoolStripMenuItem.Text = "Rename";
            this.RenametoolStripMenuItem.Click += new System.EventHandler(this.RenametoolStripMenuItem_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Image = global::FileSyncDemo.Demo.Properties.Resources.add;
            this.btnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(65, 22);
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tsbNewFolder
            // 
            this.tsbNewFolder.Image = global::FileSyncDemo.Demo.Properties.Resources.folder_add;
            this.tsbNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewFolder.Name = "tsbNewFolder";
            this.tsbNewFolder.Size = new System.Drawing.Size(84, 22);
            this.tsbNewFolder.Text = "NewFolder";
            this.tsbNewFolder.ToolTipText = "NewFolder";
            this.tsbNewFolder.Click += new System.EventHandler(this.tsbNewFolder_Click);
            // 
            // tsViewMode
            // 
            this.tsViewMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmList,
            this.tsmIcon});
            this.tsViewMode.Image = ((System.Drawing.Image)(resources.GetObject("tsViewMode.Image")));
            this.tsViewMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsViewMode.Name = "tsViewMode";
            this.tsViewMode.Size = new System.Drawing.Size(98, 22);
            this.tsViewMode.Text = "View Mode";
            this.tsViewMode.ButtonClick += new System.EventHandler(this.tsViewMode_ButtonClick);
            // 
            // tsmList
            // 
            this.tsmList.Name = "tsmList";
            this.tsmList.Size = new System.Drawing.Size(97, 22);
            this.tsmList.Text = "List";
            this.tsmList.Click += new System.EventHandler(this.tsmList_Click);
            // 
            // tsmIcon
            // 
            this.tsmIcon.Name = "tsmIcon";
            this.tsmIcon.Size = new System.Drawing.Size(97, 22);
            this.tsmIcon.Text = "Icon";
            this.tsmIcon.Click += new System.EventHandler(this.tsmIcon_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(853, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 39);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tsmExit
            // 
            this.tsmExit.Image = global::FileSyncDemo.Demo.Properties.Resources.exit;
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(133, 22);
            this.tsmExit.Text = "Exit(&E)";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tvTree
            // 
            this.tvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTree.FileSync = null;
            this.tvTree.ImageIndex = 0;
            this.tvTree.ImageList = this.imageList1;
            this.tvTree.ItemHeight = 18;
            this.tvTree.Location = new System.Drawing.Point(0, 0);
            this.tvTree.Name = "tvTree";
            treeNode1.Name = "";
            treeNode1.Tag = "share_root";
            treeNode1.Text = "/";
            this.tvTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvTree.SelectedImageIndex = 0;
            this.tvTree.Size = new System.Drawing.Size(237, 369);
            this.tvTree.TabIndex = 0;
            this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 575);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Station Explorer";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.cmFile.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tsView.ResumeLayout(false);
            this.tsView.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ToolStrip tsView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnUpload;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip cmFile;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem RenametoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbNewFolder;
        private System.Windows.Forms.ImageList imageList1;
        private FileSyncDemo.FSTreeView tvTree;
        private System.Windows.Forms.ToolStripSplitButton tsViewMode;
        private System.Windows.Forms.ToolStripMenuItem tsmList;
        private System.Windows.Forms.ToolStripMenuItem tsmIcon;
        private System.Windows.Forms.ImageList imgLarge;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
    }
}