using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FileSyncDemo
{
    public class FileSyncUtility
    {
        /// <summary>
        /// 将请求的参数整理为请求url中需要的字符串
        /// </summary>
        /// <param name="requestParams">请求的参数</param>
        public static string GetQueryFromParams(Dictionary<string, object> requestParams)
        {
            if (requestParams == null || requestParams.Count == 0)
                return "";
            string paramStr = "";
            string divStr = "";
            foreach (KeyValuePair<string, object> param in requestParams)
            {
                string value = param.Value as string;
                if (value != null)
                {
                    paramStr += divStr;
                    paramStr += param.Key + "=" + Uri.EscapeDataString(value);
                    divStr = "&";
                }
            }

            return paramStr;
        }

        /// <summary>
        /// 把请求参数加入的请求的url中
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="key">请求的参数</param>
        public static string AddParametersToURL(string url, Dictionary<string, object> requestParams)
        {
            string paramStr = GetQueryFromParams(requestParams);

            if (paramStr != "")
            {
                url += "?" + paramStr;
            }
            return url;
        }
    }
}
