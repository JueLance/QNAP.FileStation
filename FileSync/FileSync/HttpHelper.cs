using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Drawing;

namespace FileSync
{
    public class HttpHelper
    {
        public const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.57 Safari/537.36";
        public const string Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

        public static HttpStatusCode Post(string url, string str)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Post;
            request.Accept = "text/plain";
            request.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(str);
            }

            WebResponse response = request.GetResponse();
            return ((HttpWebResponse)response).StatusCode;
            //using (WebResponse response = request.GetResponse())
            //{

            //    // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //    using (Stream dataStream = response.GetResponseStream())
            //    {
            //        using (StreamReader reader = new StreamReader(dataStream))
            //        {
            //            _responseFromServer = reader.ReadToEnd();
            //        }
            //    }
            //}
        }

        public static string Get(string url)
        {
            string content = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = UserAgent;
            request.Accept = Accept;

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    content = sr.ReadToEnd();
                }
            }

            return content;
        }


        public static Image GetWithStream(string url)
        {
            Image img = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = UserAgent;
            request.Accept = Accept;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream ms = response.GetResponseStream())
                {
                    img = Image.FromStream(ms);
                }
            }

            return img;
        }
    }
}