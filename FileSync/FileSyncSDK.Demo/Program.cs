using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FileSyncDemo
{
    static class Program
    {
        public static FileSync fsConnect = null;
        public const string AppName = "File Station";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TestForm());
            Application.Run(new MainFrm());
        }
    }
}
