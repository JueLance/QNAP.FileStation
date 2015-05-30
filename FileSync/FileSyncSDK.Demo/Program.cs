using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FileSyncSDK;

namespace FileSync
{
    static class Program
    {
        public static FileSyncSDK.FileSync fsConnect = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            fsConnect = new FileSyncSDK.FileSync("Http", "10.0.0.12", 8866);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new MainFrm());
        }
    }
}
