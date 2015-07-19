using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    #region Enum
    /// <summary>
    /// 授权结果的枚举值
    /// </summary>
    public enum FileSyncUserLoginResult : uint
    {
        UserLogin_Success = 1,
        UserLogin_Cancel = 2,
        UserLogin_Fail = 3
    };
    #endregion

    public class FileSyncLoginResultEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// 授权的结果
        /// </summary>
        public FileSyncUserLoginResult Result { get; private set; }

        /// <summary>
        /// 授权失败的错误信息
        /// </summary>
        public FileSyncError Error { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="result">授权结果</param>
        /// <param name="error">授权失败的错误信息</param>
        public FileSyncLoginResultEventArgs(FileSyncUserLoginResult result, FileSyncError error)
        {
            Result = result;
            Error = error;
        }
        #endregion

    }
}
