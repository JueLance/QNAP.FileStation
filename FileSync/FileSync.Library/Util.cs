using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSync.Library
{
    public class Util
    {
        public static string BuildUrl(string str)
        {
            string pro = "http://";
            switch (FileSyncConfig.Instance.Protocol)
            {
                case ProtocolType.Http:
                    pro = "http://";
                    break;
                case ProtocolType.Https:
                    pro = "https://";
                    break;
                default:
                    pro = "http://";
                    break;
            }
            return string.Format("{0}{1}:{2}/cgi-bin/{3}", pro, FileSyncConfig.Instance.Domain, FileSyncConfig.Instance.Port, str);
        }
    }
}
