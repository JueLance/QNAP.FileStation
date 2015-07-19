using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    public class FileSync
    {
        public FileSync(string protocol, string ip, int port)
        {
            Config.Domain = ip;
            Config.Port = port;
            Config.Protocol = (ProtocolType)Enum.Parse(typeof(ProtocolType), protocol);
        }

        /// <summary>
        /// 用来存储User授权信息的对象
        /// </summary>
        public static FileSyncUserSession CurrentUser = new FileSyncUserSession();

        /// <summary>
        /// 负责SDK配置信息的对象
        /// </summary>
        public static FileSyncConfig Config = new FileSyncConfig();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestUrl">相对URL，不需要传http://ip:8080/cgi-bin/这样的地址</param>
        /// <param name="httpMethod"></param>
        /// <param name="requestParams"></param>
        /// <param name="callback"></param>
        public void SendRequest(string requestUrl, string httpMethod, Dictionary<string, object> requestParams, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            FileSyncAPIRequest request = new FileSyncAPIRequest();
            request.DownloadStringCompleted += new FileSyncAPIRequest.FileSyncRequestCompletedHandler(callback);

            if (requestUrl.StartsWith("http") || requestUrl.StartsWith("https"))
            {
                request.APIRequest(requestUrl, httpMethod, requestParams);
            }
            else
            {
                request.APIRequest(Config.Uri.ToString() + requestUrl, httpMethod, requestParams);
            }
        }
    }
}
