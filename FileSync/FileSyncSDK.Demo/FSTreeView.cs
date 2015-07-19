using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSyncDemo
{
    public partial class FSTreeView : TreeView
    {
        public FSTreeView()
        {
            InitializeComponent();

            //TreeNode tn = new TreeNode();
            //tn.Tag = "share_root";
            //tn.Text = "/";
            //this.Nodes.Add(tn);
            this.BeforeExpand += new TreeViewCancelEventHandler(FSTreeView_BeforeExpand);
            this.AfterSelect += new TreeViewEventHandler(FSTreeView_AfterSelect);
        }

        void FSTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            GetFolder(e.Node.Tag.ToString());
        }

        void FSTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetFolder(e.Node.Tag.ToString());
        }

        private void GetFolder(string path)
        {
            if (path == "/")
            {
                path = "share_root";
            }

            if (this.FileSync != null)
            {
                FileManager fm = new FileManager(this.FileSync);
                fm.GetTree(false, path, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(GetTreeFinish));
            }
        }

        private void GetTreeFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    List<Folder> list = new List<Folder>();

                    list = JsonHelper.DeserializeObject<List<Folder>>(arg.Response);

                    AddFolder(list);

                    break;
                case FileSyncAPIRequestResult.Fail:
                    //SetResult(arg.Error.error_msg);
                    break;
                default:

                    break;
            }
        }

        public void AddFolder(List<Folder> list)
        {
            if (list != null && list.Count > 0)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((EventHandler)delegate
                    {
                        TreeNode node = this.SelectedNode;
                        if (node != null)
                        {
                            node.Nodes.Clear();

                            this.SuspendLayout();

                            foreach (Folder item in list)
                            {
                                if (item != null && !string.IsNullOrEmpty(item.Text))
                                {
                                    TreeNode tn = new TreeNode();
                                    tn.Text = item.Text;
                                    tn.Tag = Path.Combine(node.Tag.ToString(), item.Text).Replace("share_root", "/").Replace("\\", "/").Replace("//", "/");
                                    node.Nodes.Add(tn);
                                }
                            }

                            this.PerformLayout();
                        }
                    });
                }
                else
                {
                    TreeNode node = this.SelectedNode;
                    if (node != null)
                    {
                        node.Nodes.Clear();

                        this.SuspendLayout();

                        foreach (Folder item in list)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.Text))
                            {
                                TreeNode tn = new TreeNode();
                                tn.Text = item.Text;
                                tn.Tag = Path.Combine(node.Tag.ToString(), item.Text).Replace("share_root", "/").Replace("\\", "/").Replace("//", "/");
                                node.Nodes.Add(tn);
                            }
                        }

                        this.PerformLayout();
                    }
                }
            }
        }

        public FileSync FileSync { get; set; }
    }
}
