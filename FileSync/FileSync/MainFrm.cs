using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSync.Library;

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
                this.Show();

                richTextBox1.AppendText(Setting.SessionID);
            }
            else
            {
                this.Close();
            }
        }

        //Get folder list
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string content = HttpHelper.Get(string.Format("http://192.168.1.85:8080/cgi-bin/filemanager/utilRequest.cgi?func=get_tree&sid={0}&is_iso=0&node=/Public", Setting.SessionID));

                FileManager file = new FileManager();
                FileManagerResponse response = file.GetTree(Setting.SessionID, false, "/Public");

                richTextBox1.AppendText(response.RawResponse);

                if (response.FolderList != null && response.FolderList.Count > 0)
                {
                    foreach (Folder item in response.FolderList)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.Text))
                        {
                            richTextBox1.AppendText(item.Text + "\r\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Format("http://192.168.1.85:8080/cgi-bin/filemanager/utilRequest.cgi?func=upload&type=standard&sid={0}&dest_path=/BaiduYun&overwrite=1&progress=-login.htm", Setting.SessionID);
                //string url = string.Format("http://192.168.1.85:8080/cgi-bin/filemanager/utilRequest.cgi?func=createdir&sid={0}&dest_folder=test&dest_path=/BaiduYun", Setting.SessionID);
                //richTextBox1.AppendText(HttpHelper.Get(url));

                FileManager mgr = new FileManager();
                FileManagerResponse response = mgr.Upload(Setting.SessionID, @"/targetfolder", false, @"D:\1.txt", Guid.NewGuid().ToString() + ".txt");

                if (response != null)
                {
                    richTextBox1.AppendText(response.RawResponse);
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string url = string.Format("http://192.168.1.85:8080/cgi-bin/filemanager/utilRequest.cgi/baidu.png?sid={0}&func=get_viewer&source_path=/BaiduYun/test&source_file=baidu.PNG", Setting.SessionID);
            //    pictureBox1.Image = HttpHelper.GetWithStream(url);
            //}
            //catch (Exception ex)
            //{
            //    richTextBox1.AppendText(ex.Message);
            //}
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Format("http://192.168.1.85:8080/cgi-bin/filemanager/utilRequest.cgi?func=get_domain_ip_list&sid={0}", Setting.SessionID);
                AboutMeFrm frm = new AboutMeFrm();
                frm.Content = HttpHelper.Get(url);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
