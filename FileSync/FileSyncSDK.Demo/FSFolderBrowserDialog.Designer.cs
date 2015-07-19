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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("/");
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lknNewFloder = new System.Windows.Forms.LinkLabel();
            this.tvTree = new FileSyncDemo.FSTreeView();
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
            this.panel2.Controls.Add(this.btnCancle);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.lknNewFloder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 450);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 42);
            this.panel2.TabIndex = 1;
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(391, 12);
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
            this.btnOK.Location = new System.Drawing.Point(290, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lknNewFloder
            // 
            this.lknNewFloder.AutoSize = true;
            this.lknNewFloder.Location = new System.Drawing.Point(15, 17);
            this.lknNewFloder.Name = "lknNewFloder";
            this.lknNewFloder.Size = new System.Drawing.Size(61, 13);
            this.lknNewFloder.TabIndex = 0;
            this.lknNewFloder.TabStop = true;
            this.lknNewFloder.Text = "New Folder";
            this.lknNewFloder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknNewFloder_LinkClicked);
            // 
            // tvTree
            // 
            this.tvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTree.FileSync = null;
            this.tvTree.Location = new System.Drawing.Point(0, 52);
            this.tvTree.Name = "tvTree";
            treeNode1.Name = "Node0";
            treeNode1.Tag = "share_root";
            treeNode1.Text = "/";
            this.tvTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvTree.Size = new System.Drawing.Size(478, 398);
            this.tvTree.TabIndex = 2;
            this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
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
            this.Text = "FSFileBrowserDialog";
            this.Load += new System.EventHandler(this.FSFileBrowserDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FSFileBrowserDialog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.LinkLabel lknNewFloder;
        private FileSyncDemo.FSTreeView tvTree;
    }
}