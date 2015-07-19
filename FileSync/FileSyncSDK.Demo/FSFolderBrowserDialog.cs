using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSyncDemo
{
    public partial class FSFolderBrowserDialog : Form
    {
        public FSFolderBrowserDialog()
        {
            InitializeComponent();
        }

        private void FSFileBrowserDialog_Load(object sender, EventArgs e)
        {
            tvTree.FileSync = Program.fsConnect;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string SelectedPath { get; set; }

        private void lknNewFloder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FSTypingDialog dlg = new FSTypingDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbUrl.Text = LinuxEnvironment.ToPath(Path.Combine(tbUrl.Text, dlg.InputText));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SelectedPath = tbUrl.Text;
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
                });
            }
            else
            {
                tbUrl.Text = url;
            }
        }
    }
}
