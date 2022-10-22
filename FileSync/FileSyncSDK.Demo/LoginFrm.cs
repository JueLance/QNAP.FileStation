using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using FileSyncDemo;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace FileSyncDemo
{
    public partial class LoginFrm : Form
    {
        public class MyScriptObject
        {
            private LoginFrm _form;

            public MyScriptObject(LoginFrm form)
            {
                _form = form;
            }
            public void Login(string username, string password)
            {
                Authorization auth = new Authorization(Program.fsConnect);
                auth.Authorize(username, password, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(_form.AuthorizeFinish));
            }

            public void SetEnvironment(string server, int port)
            {
                Program.fsConnect = new FileSync("Http", server, port);
            }
        }

        public LoginFrm()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new MyScriptObject(this);
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            string url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.htm");
            webBrowser1.Url = new Uri(url);
        }

        private void AuthorizeFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    if (FileSync.CurrentUser.IsUserSessionValid())
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("登录失败！请重新登录");
                    }

                    //if (this.InvokeRequired)
                    //{
                    //    this.Invoke((EventHandler)delegate
                    //    {
                    //        this.Close();
                    //    });
                    //}
                    //else
                    //{
                    //    this.Close();
                    //}

                    //this.Owner.Show();


                    break;
                case FileSyncAPIRequestResult.Fail:
                    MessageBox.Show("登录失败！请重新登录");
                    break;
                default:
                    break;
            }

        }
    }
}
