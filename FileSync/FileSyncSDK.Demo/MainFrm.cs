using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSyncSDK;
using System.IO;

namespace FileSync
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();

            TreeNode tn = new TreeNode();
            tn.Tag = "share_root";
            tn.Text = "/";
            treeView1.Nodes.Add(tn);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.Hide();

            LoginFrm loginFrm = new LoginFrm();
            loginFrm.Owner = this;
            DialogResult result = loginFrm.ShowDialog();

            if (result == DialogResult.OK)
            {
                loginFrm.Close();

                this.Show();

                SetResult(FileSyncSDK.FileSync.CurrentUser.SessionID);
            }
            else
            {
                this.Close();
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
                    SetResult(arg.Error.error_msg);
                    break;
                default:

                    break;
            }
        }

        private void GetListFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    FileListResponse fileList = JsonHelper.DeserializeObject<FileListResponse>(arg.Response);

                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke((EventHandler)delegate
                        {
                            if (fileList != null && fileList.datas != null && fileList.datas.Length > 0)
                            {
                                listView1.Items.Clear();
                                foreach (FileMeta file in fileList.datas)
                                {
                                    ListViewItem item = new ListViewItem(file.filename);
                                    item.Tag = file;
                                    listView1.Items.Add(item);
                                }
                            }
                        });
                    }
                    else
                    {
                        if (fileList != null && fileList.datas != null && fileList.datas.Length > 0)
                        {
                            listView1.Items.Clear();
                            foreach (FileMeta file in fileList.datas)
                            {
                                ListViewItem item = new ListViewItem(file.filename);
                                item.Tag = file;
                                listView1.Items.Add(item);
                            }
                        }
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    MessageBox.Show(arg.Error.error_msg);
                    break;
                default:
                    break;
            }
        }

        public void AddFolder(List<Folder> list)
        {
            if (list != null && list.Count > 0)
            {

                if (treeView1.InvokeRequired)
                {
                    treeView1.Invoke((EventHandler)delegate
                    {
                        TreeNode node = treeView1.SelectedNode;
                        if (node != null)
                        {
                            node.Nodes.Clear();

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
                        }
                    });
                }
                else
                {
                    TreeNode node = treeView1.SelectedNode;
                    if (node != null)
                    {
                        node.Nodes.Clear();

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
                    }
                }
            }
        }

        private void SetUrl(string url)
        {
            if (tbUrl.InvokeRequired)
            {
                this.Invoke((EventHandler)delegate
                {
                    tbUrl.Text = url;
                });
            }
            else
            {
                tbUrl.Text = url;
            }
        }

        private void SetResult(string result)
        {
            if (richTextBox1.InvokeRequired)
            {
                //Invoke(new dgvDelegate(SetDgvDataSource), new object[] { table });
                this.Invoke((EventHandler)delegate
                {
                    richTextBox1.AppendText(result + "\r\n");
                });
            }
            else
            {
                richTextBox1.AppendText(result + "\r\n");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fm = new FileManager(Program.fsConnect);
            fm.GetDomainIPList(new FileSyncAPIRequest.FileSyncRequestCompletedHandler(GetDomainIPListFinish));
        }

        private void UploadFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    FileManagerResponse response = new FileManagerResponse();

                    if (!string.IsNullOrEmpty(arg.Response))
                    {
                        response = JsonHelper.DeserializeObject<FileManagerResponse>(arg.Response);

                        response.RawResponse = arg.Response;

                        UploadResponse resp = JsonHelper.DeserializeObject<UploadResponse>(arg.Response);

                        SetResult(arg.Response);

                        SetResult(resp.status.ToString());
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    MessageBox.Show("调用API时发生错误， 错误消息：" + arg.Error.error_msg);
                    break;
                default:
                    break;
            }
        }

        private void GetDomainIPListFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        AboutMeFrm frm = new AboutMeFrm();
                        frm.Content = arg.Response;
                        frm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        SetResult(ex.Message);
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    MessageBox.Show("调用API时发生错误， 错误消息：" + arg.Error.error_msg);
                    break;
                default:
                    break;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                string newFileName = Guid.NewGuid().ToString() + "_" + System.IO.Path.GetFileName(selectedFile);

                FileManager mgr = new FileManager(Program.fsConnect);
                mgr.Upload(tbUrl.Text, false, selectedFile, newFileName, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(UploadFinish));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetUrl(e.Node.Tag.ToString());

            string path = "";

            if (e.Node.Text == "/")
            {
                path = "share_root";
            }
            else
            {
                path = e.Node.Tag.ToString();
            }

            FileManager fm = new FileManager(Program.fsConnect);
            fm.GetTree(false, path, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(GetTreeFinish));
            fm.GetList(path, false, 0, 500, SortField.FileName, SortDirection.Asc, FileHidden.Hidden, FileType.All, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(GetListFinish));
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                FileMeta meta = item.Tag as FileMeta;
                meta.FilePath = tbUrl.Text;

                PropertyFrm frm = new PropertyFrm(meta);

                frm.ShowDialog();
            }
        }
    }
}
