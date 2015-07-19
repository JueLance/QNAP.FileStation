using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSyncDemo
{
    public partial class FSTypingDialog : Form, INotifyPropertyChanged
    {
        public FSTypingDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The user input text
        /// </summary>
        public string InputText
        {
            get
            {
                return tbInput.Text;
            }
            set
            {
                if (value != tbInput.Text)
                {
                    tbInput.Text = value;
                    NotifyPropertyChanged("InputText");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.InputText = this.tbInput.Text;
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FSTypingDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
