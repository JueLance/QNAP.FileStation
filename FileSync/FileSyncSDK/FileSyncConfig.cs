using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    public class FileSyncConfig
    {
        private string m_SDKVersion;

        public string SDKVersion
        {
            get { return m_SDKVersion; }
            set { m_SDKVersion = value; }
        }

        public ProtocolType Protocol { get; set; }

        public string Domain { get; set; }

        public int Port { get; set; }

        public Uri Uri
        {
            get
            {
                return new Uri(Protocol + "://" + Domain + ":" + Port + "/cgi-bin/");
            }
        }
    }

    public enum ProtocolType
    {
        Http,
        Https
    }
}
