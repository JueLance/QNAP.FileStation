using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MSHTML;

//javascript(DHTML)代码和客户端应用程序代码之间实现双向通信.
//if (webBrowser1.Document != null) webBrowser1.Document.GetElementById("Button1").InvokeMember("onclick"); 

namespace FileSyncDemo
{
    //     using System.Security.Permissions;
    // [PermissionSet(SecurityAction.Demand, Name = "FullTrust
    // [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*
            msdn说webBrowser1.ObjectForScripting属性的作用是：获取或设置一个对象，
            该对象可由显示在 WebBrowser 控件中的网页所包含的脚本代码访问。
            使用该属性可以启用 WebBrowser 控件承载的网页与包含 WebBrowser 控件的应用程序之间的通信。
            使用该属性可以将动态 HTML (DHTML) 代码与客户端应用程序代码集成在一起。
            为该属性指定的对象可作为 window.external 对象（用于主机访问的内置 DOM 对象）用于网页脚本。 
            */

            webBrowser1.ObjectForScripting = this;
        }

        public void Test(String message)
        {
            MessageBox.Show(message, "client code");
        }

        public void Test2(String message, string msg)
        {
            MessageBox.Show(message, "client code");
        }

        // 建立一个查找用的TextRange（IHTMLTxtRange接口） 
        private IHTMLTxtRange searchRange = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            string url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.htm");
            webBrowser1.Url = new Uri(url);

        }

        void btnElement_Click(object sender, HtmlElementEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Document的DomDocument属性，就是该对象内部的COM对象。 
            IHTMLDocument2 document = (IHTMLDocument2)webBrowser1.Document.DomDocument;
            string keyword = txtKeyword.Text.Trim();
            if (keyword == "")
                return;
            // IE的查找逻辑就是，如果有选区，就从当前选区开头+1字符处开始查找；没有的话就从页面最初开始查找。 
            // 这个逻辑其实是有点不大恰当的，我们这里不用管，和IE一致即可。 
            if (document.selection.type.ToLower() != "none")
            {
                searchRange = (IHTMLTxtRange)document.selection.createRange();
                searchRange.collapse(true);
                searchRange.moveStart("character", 1);
            }
            else
            {
                IHTMLBodyElement body = (IHTMLBodyElement)document.body;
                searchRange = (IHTMLTxtRange)body.createTextRange();
            }
            // 如果找到了，就选取（高亮显示）该关键字；否则弹出消息。 
            if (searchRange.findText(keyword, 1, 0))
            {
                searchRange.select();
                searchRange.scrollIntoView();
            }
            else
            {
                MessageBox.Show("已搜索到文档结尾。");
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument htmlDoc = webBrowser1.Document;
            HtmlElement btnElement = htmlDoc.All["btnClose"];
            if (btnElement != null)
            {
                btnElement.Click += new HtmlElementEventHandler(btnElement_Click);
                //btnElement.AttachEventHandler("onclick", new EventHandler(HtmlBtnClose_Click)); 
                //formElement.AttachEventHandler("onsubmit", new EventHandler(HtmlForm_Submit));
            }

            //HtmlElement formLogin = webBrowser.Document.Forms["loginForm"];
            //formLogin.InvokeMember("submit");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TaskForm.Instance.AddBackgroundTask(new ITask() { ID = 1, Name = "move file" });
            //TaskForm.Instance.AddBackgroundTask(new ITask() { ID = 2, Name = "move file" });
            //TaskForm.Instance.AddBackgroundTask(new ITask() { ID = 3, Name = "move file" });
            //TaskForm.Instance.AddBackgroundTask(new ITask() { ID = 4, Name = "move file" });
            //TaskForm.Instance.AddBackgroundTask(new ITask() { ID = 5, Name = "move file" });
            //TaskForm.Instance.AddBackgroundTask(new ITask() { ID = 6, Name = "move file" });

            TaskForm form = TaskForm.Instance;
            TaskForm.Instance.Owner = this;
            form.Show();
        }

    }
}
