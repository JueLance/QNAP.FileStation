using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSync
{
    public partial class AboutMeFrm : Form
    {
        public AboutMeFrm()
        {
            InitializeComponent();
        }

        public string Content
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        private void AboutMeFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
