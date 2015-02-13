using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSyncSDK;

namespace FileSync
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
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
                    SetResult(arg.Response);

                    List<Folder> list = new List<Folder>();

                    list = JsonHelper.DeserializeObject<List<Folder>>(arg.Response);

                    if (list != null && list.Count > 0)
                    {
                        foreach (Folder item in list)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.Text))
                            {
                                SetResult(item.Text);
                            }
                        }
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    SetResult(arg.Error.error_msg);
                    break;
                default:

                    break;
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

                        SetResult(arg.Response);
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

        private void btnGetTree_Click(object sender, EventArgs e)
        {
            FileManager fm = new FileManager(Program.fsConnect);
            fm.GetTree(false, "/Public", new FileSyncAPIRequest.FileSyncRequestCompletedHandler(GetTreeFinish));
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                string newFileName = Guid.NewGuid().ToString() + "_" + System.IO.Path.GetFileName(selectedFile);

                FileManager mgr = new FileManager(Program.fsConnect);
                mgr.Upload(@"/Public", false, selectedFile, newFileName, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(UploadFinish));
            }
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string url = string.Format("http://192.168.1.85:8080/cgi-bin/filemanager/utilRequest.cgi/baidu.png?sid={0}&func=get_viewer&source_path=/BaiduYun/test&source_file=baidu.PNG", Setting.SessionID);
            //    pictureBox1.Image = HttpHelper.GetWithStream(url);
            //}
            //catch (Exception ex)
            //{
            //    SetResult(ex.Message);
            //}
        }
    }
}
