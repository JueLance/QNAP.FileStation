using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSyncDemo;
using System.IO;
using Newtonsoft.Json;

namespace FileSyncDemo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();

            UiLog.Instance.RichTextBox = richTextBox1;
            UiLog.Instance.AutoWrap = true;
        }

        FSFolderBrowserDialog folderdlg = null;
        FileManager fm = null;

        private void MainFrm_Load(object sender, EventArgs e)
        {
            ShowLoginWindow();
        }

        private void ShowLoginWindow()
        {
            this.Hide();

            LoginFrm loginFrm = new LoginFrm();
            loginFrm.Owner = this;
            DialogResult result = loginFrm.ShowDialog();

            if (result == DialogResult.OK)
            {
                tvTree.FileSync = Program.fsConnect;
                fm = new FileManager(Program.fsConnect);
                loginFrm.Close();
                this.Show();

                //SetResult(FileSyncSDK.FileSync.CurrentUser.SessionID);
            }
            else
            {
                this.Close();
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
                            listView1.Items.Clear();

                            if (fileList != null && fileList.datas != null && fileList.datas.Length > 0)
                            {
                                string filePath = arg.RequestParams["path"].ToString();

                                foreach (FileMeta file in fileList.datas)
                                {
                                    ListViewItem item = new ListViewItem(file.filename);
                                    file.FilePath = filePath;
                                    file.FullPath = LinuxEnvironment.ToPath(Path.Combine(file.FilePath, file.filename));
                                    item.Tag = file;

                                    string key = "";
                                    if (file.isfolder == "1")
                                    {
                                        key = "folder.gif";

                                        if (file.filename.Contains("@Recycle"))
                                        {
                                            key = file.filename.Remove(0, 1) + ".gif";
                                        }
                                    }
                                    else
                                    {
                                        key = "undefind.gif";

                                        ImageList il = listView1.LargeImageList;

                                        string ext = Path.GetExtension(file.filename);
                                        if (!string.IsNullOrEmpty(ext) && ext.Length > 0)
                                        {
                                            key = ext.Remove(0, 1) + ".gif";
                                        }

                                        if (!il.Images.ContainsKey(key))
                                        {
                                            key = "undefind.gif";
                                        }
                                    }

                                    item.ImageKey = key;

                                    listView1.Items.Add(item);
                                }
                            }
                        });
                    }
                    else
                    {
                        listView1.Items.Clear();

                        if (fileList != null && fileList.datas != null && fileList.datas.Length > 0)
                        {
                            string filePath = arg.RequestParams["path"].ToString();

                            foreach (FileMeta file in fileList.datas)
                            {
                                ListViewItem item = new ListViewItem(file.filename);
                                file.FilePath = filePath;
                                file.FullPath = LinuxEnvironment.ToPath(Path.Combine(file.FilePath, file.filename));
                                item.Tag = file;
                                string key = "folder.gif";
                                if (file.isfolder == "1")
                                {
                                    if (file.filename.Contains("@Recycle"))
                                    {
                                        key = file.filename.Remove(0, 1) + ".gif";
                                    }
                                }
                                else
                                {
                                    ImageList il = listView1.LargeImageList;

                                    string ext = Path.GetExtension(file.filename);
                                    if (!string.IsNullOrEmpty(ext) && ext.Length > 0)
                                    {
                                        key = ext.Remove(0, 1) + ".gif";
                                    }

                                    if (!il.Images.ContainsKey(key))
                                    {
                                        key = "undefind.gif";
                                    }
                                }

                                item.ImageKey = key;
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

                        BaseResponse resp = JsonConvert.DeserializeObject<BaseResponse>(arg.Response);

                        if (resp.Status == 1)
                        {
                            SyncFileViewState();

                            UiLog.Log("上传文件成功");
                        }
                        else
                        {
                            UiLog.Log("上传文件失败");
                        }
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

        private void MoveFileFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        BaseResponse response = JsonConvert.DeserializeObject<BaseResponse>(arg.Response);

                        if (response.Status == 1)
                        {
                            SyncFolderViewState();
                            SyncFileViewState();

                            UiLog.Log("移动文件成功");
                        }
                        else
                        {
                            UiLog.Log("移动文件失败");
                        }
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

        private void DeleteFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        BaseResponse response = JsonConvert.DeserializeObject<BaseResponse>(arg.Response);

                        if (response.Status == 1)
                        {
                            SyncFolderViewState();
                            SyncFileViewState();
                            UiLog.Log("删除文件/文件夹成功");
                        }
                        else
                        {
                            UiLog.Log("删除文件/文件夹失败");
                        }
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

        private void RenameFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        BaseResponse response = JsonConvert.DeserializeObject<BaseResponse>(arg.Response);

                        if (response.Status == 1)
                        {
                            SyncFileViewState();

                            UiLog.Log("重命名文件/文件夹成功");
                        }
                        else
                        {
                            UiLog.Log("重命名文件/文件夹失败");
                        }
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

        private void SyncFileViewState()
        {
            if (tvTree.InvokeRequired)
            {
                tvTree.Invoke((EventHandler)delegate
                {
                    if (tvTree.SelectedNode != null)
                    {
                        tvTree_AfterSelect(this, new TreeViewEventArgs(tvTree.SelectedNode));
                    }
                });
            }
            else
            {
                if (tvTree.SelectedNode != null)
                {
                    tvTree_AfterSelect(this, new TreeViewEventArgs(tvTree.SelectedNode));
                }
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


        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag.ToString();

            SetUrl(path);

            fm.GetList(path, false, 0, 500, SortField.FileName, SortDirection.Asc, FileHidden.Hidden, FileType.All, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(GetListFinish));
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                FileMeta meta = item.Tag as FileMeta;
                PropertyFrm frm = new PropertyFrm(meta);

                frm.ShowDialog();
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                if (folderdlg == null)
                {
                    folderdlg = new FSFolderBrowserDialog();
                }

                if (folderdlg.ShowDialog() == DialogResult.OK)
                {
                    FileManager fm = new FileManager(Program.fsConnect);

                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                        ListViewItem lvItem = listView1.SelectedItems[i];
                        FileMeta meta = lvItem.Tag as FileMeta;
                        fm.Move(meta.filename, 1, meta.FilePath, folderdlg.SelectedPath, 1, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(MoveFileFinish));
                    }
                }
            }
        }

        private void tsbNewFolder_Click(object sender, EventArgs e)
        {
            FSTypingDialog dlg = new FSTypingDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileManager fm = new FileManager(Program.fsConnect);
                fm.CreateDir(dlg.InputText, tbUrl.Text, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(CreateDirFinish));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除文件吗？\r\n文件一经删除，将无法找回。请谨慎操作。", Program.AppName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
                {
                    FileManager fm = new FileManager(Program.fsConnect);

                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                        ListViewItem lvItem = listView1.SelectedItems[i];
                        FileMeta meta = lvItem.Tag as FileMeta;
                        fm.Delete(meta.FilePath, 1, meta.filename, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(DeleteFinish));
                    }
                }
            }
        }

        private void RenametoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                FileMeta meta = item.Tag as FileMeta;

                FSTypingDialog dlg = new FSTypingDialog();
                dlg.InputText = meta.filename;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileManager fm = new FileManager(Program.fsConnect);
                    fm.Rename(meta.FilePath, meta.filename, dlg.InputText, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(RenameFinish));
                }
            }
        }

        private void tsmList_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void tsmIcon_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void tsViewMode_ButtonClick(object sender, EventArgs e)
        {
            switch (listView1.View)
            {
                case View.Details:
                    listView1.View = View.LargeIcon;
                    break;
                case View.LargeIcon:
                    listView1.View = View.List;
                    break;
                case View.List:
                    listView1.View = View.LargeIcon;
                    break;
                case View.SmallIcon:
                    listView1.View = View.LargeIcon;
                    break;
                case View.Tile:
                    listView1.View = View.List;
                    break;
                default:
                    break;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncFolderViewState();
            SyncFileViewState();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tsmDisconnect_Click(object sender, EventArgs e)
        {
            Program.fsConnect = null;
            ShowLoginWindow();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
