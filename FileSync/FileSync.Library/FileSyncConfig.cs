using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSync.Library
{
    public class FileSyncConfig
    {
        public ProtocolType Protocol { get; set; }

        public string Domain { get; set; }

        public int Port { get; set; }

        private static FileSyncConfig m_FileSyncConfig;

        public static FileSyncConfig Instance
        {
            get
            {
                if (m_FileSyncConfig == null)
                {
                    m_FileSyncConfig = new FileSyncConfig();
                }
                return m_FileSyncConfig;
            }
        }
    }

    public enum ProtocolType
    {
        Http,
        Https
    }
}
