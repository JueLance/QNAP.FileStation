using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FileSyncSDK
{
    public class FileSyncSettings : Hashtable
    {
        private static FileSyncSettings m_Setting;
        public static FileSyncSettings ApplicationSettings
        {
            get
            {
                if (m_Setting == null)
                {
                    m_Setting = new FileSyncSettings();
                }

                return m_Setting;
            }
        }

        public bool TryGetValue<T1>(string authorizeInfoKey, out FileSyncAuthorizeInfo authInfo)
        {
            if (this.ContainsKey(authorizeInfoKey))
            {
                authInfo = (FileSyncAuthorizeInfo)this[authorizeInfoKey];

                return true;
            }

            authInfo = null;
            return false;
        }

    }
}
