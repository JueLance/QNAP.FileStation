using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileSyncSDK
{
    public class FileSyncAPIRequestFileParam
    {
        #region Properties
        /// <summary>
        /// 文件的Key
        /// </summary>
        public string FileKey { get; set; }
        /// <summary>
        /// 文件的数据
        /// </summary>
        public byte[] FileData { get; set; }
        #endregion
    }
}
