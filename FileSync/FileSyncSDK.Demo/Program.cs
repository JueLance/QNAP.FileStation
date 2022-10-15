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
#if NET5_0_OR_GREATER
            ApplicationConfiguration.Initialize();
#else
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#endif
            Application.Run(new MainFrm());
        }
    }
}
