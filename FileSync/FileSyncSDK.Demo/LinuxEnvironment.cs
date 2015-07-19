using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    public sealed class LinuxEnvironment
    {
        public static string ToPath(string windowsPath)
        {
            return windowsPath.Replace("\\", "/");
        }
    }
}
