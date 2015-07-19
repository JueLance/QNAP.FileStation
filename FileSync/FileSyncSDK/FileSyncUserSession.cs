using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    public class FileSyncUserSession
    {
        FileSyncSettings settings = FileSyncSettings.ApplicationSettings;

        #region Public Method

        /// <summary>
        /// 当前用户的SessionID
        /// </summary>
        public string SessionID
        {
            get
            {
                if (authInfo != null)
                {
                    return authInfo.AuthSid;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// 授权信息对象
        /// </summary>
        private FileSyncAuthorizeInfo authInfo;

        /// <summary>
        /// 本地存储授权信息的Key
        /// </summary>
        private string authorizeInfoKey = "FileSyncAuthorizeInfo";

        #region Constuctors
        /// <summary>
        /// 构造
        /// </summary>
        public FileSyncUserSession()
        {
            if (!settings.TryGetValue<FileSyncAuthorizeInfo>(authorizeInfoKey, out authInfo))
            {
                authInfo = new FileSyncAuthorizeInfo();
            }
        }
        #endregion

        /// <summary>
        /// 保存用户的授权信息
        /// </summary>
        /// <param name="info">授权信息</param>
        public void SaveUserSessionInfo(FileSyncAuthorizeInfo info)
        {
            if (info == null)
                return;
            authInfo = info;

            if (!settings.Contains(authorizeInfoKey))
            {
                settings.Add(authorizeInfoKey, authInfo);
            }
            else
            {
                settings[authorizeInfoKey] = authInfo;
            }
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        public void UserLogOut()
        {
            authInfo.CleanUp();
            if (settings.Contains(authorizeInfoKey))
                settings.Remove(authorizeInfoKey);
        }

        /// <summary>
        /// 判断用户授权是否有效
        /// </summary>
        public bool IsUserSessionValid()
        {
            return !string.IsNullOrEmpty(authInfo.AuthSid);
        }
        #endregion

    }
}
