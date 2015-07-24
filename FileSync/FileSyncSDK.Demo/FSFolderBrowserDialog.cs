using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace FileSyncDemo
{
    public partial class FSFolderBrowserDialog : Form
    {
        public FSFolderBrowserDialog()
        {
            InitializeComponent();
        }

        public string SelectedPath { get; set; }
        private string newFolderName = string.Empty;

        private void FSFileBrowserDialog_Load(object sender, EventArgs e)
        {
            tvTree.FileSync = Program.fsConnect;
            tvTree.Select();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lknNewFloder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //this.SelectedPath = tbUrl.Text;
            this.Close();
        }

        private void FSFileBrowserDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This function is not completed yet.");
        }

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetUrl(e.Node.Tag.ToString());
        }

        private void SetUrl(string url)
        {
            if (tbUrl.InvokeRequired)
            {
                this.Invoke((EventHandler)delegate
                {
                    tbUrl.Text = url;
                    this.SelectedPath = url;
                });
            }
            else
            {
                tbUrl.Text = url;
                this.SelectedPath = url;
            }
        }

        private void btnNewFloder_Click(object sender, EventArgs e)
        {
            FSTypingDialog dlg = new FSTypingDialog();
            dlg.Owner = this;
            dlg.Text = "New Folder";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                newFolderName = dlg.InputText;

                FileManager fm = new FileManager(Program.fsConnect);
                fm.CreateDir(dlg.InputText, tbUrl.Text, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(CreateDirFinish));
            }
        }

        private void CreateDirFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        BaseResponse response = JsonConvert.DeserializeObject<BaseResponse>(arg.Response);

                        if (response.Status == 1)
                        {
                            SetUrl(LinuxEnvironment.ToPath(Path.Combine(SelectedPath, newFolderName)));

                            SyncFolderViewState();

                            UiLog.Log("创建文件夹成功");
                        }
                        else
                        {
                            UiLog.Log("创建文件夹失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        UiLog.Log(ex.Message);
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    MessageBox.Show("调用API时发生错误， 错误消息：" + arg.Error.error_msg);
                    break;
                default:
                    break;
            }
        }

        private void SyncFolderViewState()
        {
            if (tvTree.InvokeRequired)
            {
                tvTree.Invoke((EventHandler)delegate
                {
                    if (tvTree.SelectedNode != null)
                    {
                        tvTree.SelectedNode.Collapse(false);
                        tvTree.SelectedNode.Expand();
                    }
                });
            }
            else
            {
                if (tvTree.SelectedNode != null)
                {
                    tvTree.SelectedNode.Collapse(false);
                    tvTree.SelectedNode.Expand();
                }
            }
        }

        private void tvTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (tvTree.InvokeRequired)
            {
                tvTree.Invoke((EventHandler)delegate
                {
                    if (e.Node != null && e.Node.Nodes != null && e.Node.Nodes.Count > 0)
                    {
                        foreach (TreeNode node in e.Node.Nodes)
                        {
                            if (node.Text == newFolderName)
                            {
                                tvTree.SelectedNode = node;

                                break;
                            }
                        }
                    }
                });
            }
            else
            {
                if (e.Node != null && e.Node.Nodes != null && e.Node.Nodes.Count > 0)
                {
                    foreach (TreeNode node in tvTree.SelectedNode.Nodes)
                    {
                        if (node.Text == newFolderName)
                        {
                            tvTree.SelectedNode = node;

                            break;
                        }
                    }
                }
            }
        }
    }
}
