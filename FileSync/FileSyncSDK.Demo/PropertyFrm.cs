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

namespace FileSyncDemo
{
    public partial class PropertyFrm : Form
    {
        public PropertyFrm()
        {
            InitializeComponent();
        }

        public PropertyFrm(FileMeta meta)
        {
            InitializeComponent();

            this.FileMeta = meta;
        }

        public FileMeta FileMeta { get; set; }

        private void PropertyFrm_Load(object sender, EventArgs e)
        {
            this.Text = FileMeta.filename;

            FileManager fm = new FileManager(Program.fsConnect);
            fm.GetStatus(FileMeta.FilePath, 2, FileMeta.filename, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(GetStatusFinish));
        }

        private void GetStatusFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke((EventHandler)delegate
                        {
                            FileListResponse fileList = JsonHelper.DeserializeObject<FileListResponse>(arg.Response);

                            listView1.Items.Clear();
                            listView1.Items.Add(new ListViewItem(string.Format("acl:{0}", fileList.acl)));
                            listView1.Items.Add(new ListViewItem(string.Format("is_acl_enable:{0}", fileList.is_acl_enable)));
                            listView1.Items.Add(new ListViewItem(string.Format("is_winacl_enable:{0}", fileList.is_winacl_enable)));
                            listView1.Items.Add(new ListViewItem(string.Format("is_winacl_support:{0}", fileList.is_winacl_support)));
                            listView1.Items.Add(new ListViewItem(string.Format("rtt_support:{0}", fileList.rtt_support)));

                            if (fileList.datas != null && fileList.datas.Length > 0)
                            {
                                listView1.Items.Add(new ListViewItem(string.Format("filename:{0}", fileList.datas[0].filename)));
                                listView1.Items.Add(new ListViewItem(string.Format("FilePath:{0}", FileMeta.FilePath)));
                                listView1.Items.Add(new ListViewItem(string.Format("filesize:{0}", fileList.datas[0].filesize)));
                                listView1.Items.Add(new ListViewItem(string.Format("filetype:{0}", fileList.datas[0].filetype)));
                                listView1.Items.Add(new ListViewItem(string.Format("group:{0}", fileList.datas[0].group)));
                                listView1.Items.Add(new ListViewItem(string.Format("iscommpressed:{0}", fileList.datas[0].iscommpressed)));
                                listView1.Items.Add(new ListViewItem(string.Format("isfolder:{0}", fileList.datas[0].isfolder)));
                                listView1.Items.Add(new ListViewItem(string.Format("mt:{0}", fileList.datas[0].mt)));
                                listView1.Items.Add(new ListViewItem(string.Format("owner:{0}", fileList.datas[0].owner)));
                                listView1.Items.Add(new ListViewItem(string.Format("privilege:{0}", fileList.datas[0].privilege)));
                            }
                        });
                    }
                    else
                    {
                        FileListResponse fileList = JsonHelper.DeserializeObject<FileListResponse>(arg.Response);

                        listView1.Items.Clear();
                        listView1.Items.Add(new ListViewItem(string.Format("acl:{0}", fileList.acl)));
                        listView1.Items.Add(new ListViewItem(string.Format("is_acl_enable:{0}", fileList.is_acl_enable)));
                        listView1.Items.Add(new ListViewItem(string.Format("is_winacl_enable:{0}", fileList.is_winacl_enable)));
                        listView1.Items.Add(new ListViewItem(string.Format("is_winacl_support:{0}", fileList.is_winacl_support)));
                        listView1.Items.Add(new ListViewItem(string.Format("rtt_support:{0}", fileList.rtt_support)));

                        if (fileList.datas != null && fileList.datas.Length > 0)
                        {
                            listView1.Items.Add(new ListViewItem(string.Format("filename:{0}", fileList.datas[0].filename)));
                            listView1.Items.Add(new ListViewItem(string.Format("FilePath:{0}", fileList.datas[0].FilePath)));
                            listView1.Items.Add(new ListViewItem(string.Format("filesize:{0}", fileList.datas[0].filesize)));
                            listView1.Items.Add(new ListViewItem(string.Format("filetype:{0}", fileList.datas[0].filetype)));
                            listView1.Items.Add(new ListViewItem(string.Format("group:{0}", fileList.datas[0].group)));
                            listView1.Items.Add(new ListViewItem(string.Format("iscommpressed:{0}", fileList.datas[0].iscommpressed)));
                            listView1.Items.Add(new ListViewItem(string.Format("isfolder:{0}", fileList.datas[0].isfolder)));
                            listView1.Items.Add(new ListViewItem(string.Format("mt:{0}", fileList.datas[0].mt)));
                            listView1.Items.Add(new ListViewItem(string.Format("owner:{0}", fileList.datas[0].owner)));
                            listView1.Items.Add(new ListViewItem(string.Format("privilege:{0}", fileList.datas[0].privilege)));

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
