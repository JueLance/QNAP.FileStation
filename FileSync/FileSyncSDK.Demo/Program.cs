using System;
using System.Windows.Forms;

namespace FileSyncDemo
{
    internal static class Program
    {
        public static FileSync fsConnect = null;
        public const string AppName = "File Station";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainFrm());
        }
    }
}
