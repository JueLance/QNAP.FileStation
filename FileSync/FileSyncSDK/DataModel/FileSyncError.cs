using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    public class FileSyncError : Exception
    {
        #region Propertys
        /// <summary>
        /// 错误码
        /// </summary>
        public string error_code { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string error_msg { get; set; }
        #endregion
    }
}
