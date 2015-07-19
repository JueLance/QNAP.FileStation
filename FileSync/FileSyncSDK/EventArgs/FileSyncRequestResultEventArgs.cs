using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    public class FileSyncRequestResultEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// API请求的结果
        /// </summary>
        public FileSyncAPIRequestResult Result { get; private set; }

        /// <summary>
        /// API请求失败的错误信息
        /// </summary>
        public FileSyncError Error { get; private set; }

        /// <summary>
        /// API请求返回的信息
        /// </summary>
        public string Response { get; private set; }

        /// <summary>
        /// API请求的URL
        /// </summary>
        public Uri RequestUrl { get; private set; }

        /// <summary>
        /// API请求的参数
        /// </summary>
        public Dictionary<string, object> RequestParams { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="requestUrl">API请求的URL</param>
        /// <param name="error">API调用失败的错误信息</param>
        public FileSyncRequestResultEventArgs(Uri requestUrl, FileSyncAPIRequestResult result, FileSyncError error)
        {
            RequestUrl = requestUrl;
            Result = result;
            Error = error;
            Response = null;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="requestUrl">API请求的URL</param>
        /// <param name="result">API调用结果</param>
        /// <param name="error">API调用返回的信息</param>
        public FileSyncRequestResultEventArgs(Uri requestUrl, FileSyncAPIRequestResult result, string response)
        {
            RequestUrl = requestUrl;
            Result = result;
            Error = null;
            Response = response;
        }
        #endregion
    }
}
