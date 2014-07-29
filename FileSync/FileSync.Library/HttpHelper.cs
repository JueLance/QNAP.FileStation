using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
//using System.Drawing;

namespace FileSync.Library
{
    public class HttpHelper
    {
        public const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.57 Safari/537.36";
        public const string Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

        public static string Post(string url, string str)
        {
            string reply = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Post;
            request.Accept = "text/plain";
            request.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(str);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        reply = reader.ReadToEnd();
                    }
                }
            }

            return reply;
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


        //public static Image GetWithStream(string url)
        //{
        //    Image img = null;

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

        //    request.Method = WebRequestMethods.Http.Get;
        //    request.ContentType = "text/html;charset=UTF-8";
        //    request.UserAgent = UserAgent;
        //    request.Accept = Accept;

        //    using (WebResponse response = request.GetResponse())
        //    {
        //        using (Stream ms = response.GetResponseStream())
        //        {
        //            img = Image.FromStream(ms);
        //        }
        //    }

        //    return img;
        //}

        public static string PostFile(string url, string filePath, string destName)
        {
            string response = string.Empty;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);
            //---------------------------
            //----------
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "--\r\n");     //请求头部信息   

            StringBuilder sb2 = new StringBuilder();
            sb2.Append(string.Format("--{0}", strBoundary));
            sb2.AppendLine();
            sb2.AppendLine(string.Format("Content-Disposition: form-data; name=\"file\"; filename=\"{0}\";", destName));
            sb2.Append(string.Format("Content-Type: application/octet-stream"));
            sb2.AppendLine();
            sb2.AppendLine();

            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sb2.ToString());

            try
            {
                // 根据uri创建HttpWebRequest对象   
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                httpReq.Method = "POST";
                //对发送的数据不使用缓存   
                httpReq.AllowWriteStreamBuffering = false;
                //设置获得响应的超时时间（300秒）   
                httpReq.Timeout = 300000;
                httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
                long fileLength = fs.Length;
                long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
                httpReq.ContentLength = length;

                //每次上传4k
                int bufferLength = 4096 * 10;
                byte[] buffer = new byte[bufferLength];
                //已上传的字节数
                long offset = 0;
                //开始上传时间
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);

                using (Stream postStream = httpReq.GetRequestStream())
                {
                    //发送请求头部消息
                    postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

                    while (size > 0)
                    {
                        postStream.Write(buffer, 0, size);

                        offset += size;

                        //TimeSpan span = DateTime.Now - startTime;
                        //double second = span.TotalSeconds;

                        size = r.Read(buffer, 0, bufferLength);
                    }

                    postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                }

                using (WebResponse webRespon = httpReq.GetResponse())
                {
                    using (Stream s = webRespon.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            response = sr.ReadToEnd();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fs.Close();
                r.Close();
            }

            return response;
        }
    }
}