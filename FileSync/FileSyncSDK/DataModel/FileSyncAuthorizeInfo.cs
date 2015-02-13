using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncSDK
{
    public class FileSyncAuthorizeInfo
    {
        #region Propertys

        public string AuthPassed { get; set; }

        public string AuthSid { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        #endregion

        #region Public Method
        /// <summary>
        /// 构造
        /// </summary>
        public FileSyncAuthorizeInfo()
        {
            AuthPassed = null;
            AuthSid = null;
            UserName = null;
            IsAdmin = false;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void CleanUp()
        {
            AuthPassed = null;
            AuthSid = null;
            UserName = null;
            IsAdmin = false;
        }
        #endregion
    }
}
