using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncSDK
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

        #endregion

        #region Constructors
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="result">API调用结果</param>
        /// <param name="error">API调用失败的错误信息</param>
        public FileSyncRequestResultEventArgs(FileSyncAPIRequestResult result, FileSyncError error)
        {
            Result = result;
            Error = error;
            Response = null;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="result">API调用结果</param>
        /// <param name="error">API调用返回的信息</param>
        public FileSyncRequestResultEventArgs(FileSyncAPIRequestResult result, string response)
        {
            Result = result;
            Error = null;
            Response = response;
        }
        #endregion
    }
}
