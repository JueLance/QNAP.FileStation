using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSyncDemo
{
    public class UiLog
    {
        public RichTextBox RichTextBox { get; set; }

        public bool AutoWrap { get; set; }

        private static object lockObject = new object();

        private static UiLog _instance;
        public static UiLog Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        _instance = _instance ?? new UiLog();
                    }
                }

                return _instance;
            }
        }

        public static void Log(string msg)
        {
            if (_instance.RichTextBox.InvokeRequired)
            {
                _instance.RichTextBox.Invoke((EventHandler)delegate
                {
                    _instance.RichTextBox.AppendText(msg + (_instance.AutoWrap ? Environment.NewLine : ""));
                });
            }
            else
            {
                _instance.RichTextBox.AppendText(msg + (_instance.AutoWrap ? Environment.NewLine : ""));
            }
        }

        public static void Log(object obj)
        {
            Log(obj.ToString());
        }
    }
}
