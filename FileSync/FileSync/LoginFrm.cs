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
using FileSync.Library;

namespace FileSync
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = this;
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            string url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.htm");
            webBrowser1.Url = new Uri(url);
        }

        public void Login(string username, string password)
        {
            try
            {

                FileSyncConfig.Instance.Protocol = ProtocolType.Http;
                FileSyncConfig.Instance.Port = 8080;
                FileSyncConfig.Instance.Domain = "192.168.1.85";

                Authorization auth = new Authorization();
                AuthorizationResponse response = auth.Login(username, password);

                if (response != null)
                {
                    Setting.SessionID = response.AuthSid;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                this.Owner.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
