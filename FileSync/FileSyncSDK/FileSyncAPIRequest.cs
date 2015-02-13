using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace FileSyncSDK
{
    public class FileSyncAPIRequest
    {
        /// <summary>
        /// 分隔字符串
        /// </summary>
        string boundary = String.Empty;

        private const string requestErrorDomain = "99999999";

        #region Events
        /// <summary>
        /// API请求结果处理的代理方法
        /// </summary>
        public delegate void FileSyncRequestCompletedHandler(object sender, FileSyncRequestResultEventArgs e);
        public event FileSyncRequestCompletedHandler DownloadStringCompleted;
        #endregion

        #region Public Method
        /// <summary>
        /// 发起API请求
        /// </summary>
        /// <param name="requestUrl">API请求的url,必须是https的</param>
        /// <param name="httpMethod">API的请求方式</param>
        /// <param name="requestParams">API的请求参数</param>
        public void APIRequest(string requestUrl, string httpMethod, Dictionary<string, object> requestParams)
        {
            if (requestUrl == null || requestUrl == "" /*|| !requestUrl.StartsWith("https")*/)
            {
                FileSyncError error = new FileSyncError();
                error.error_code = requestErrorDomain;
                error.error_msg = "Request url is wrong.";

                if (DownloadStringCompleted != null)
                {
                    DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(FileSyncAPIRequestResult.Fail, error));
                }

                return;
            }

            if (requestParams == null)
            {
                requestParams = new Dictionary<string, object>();
            }

            if (!requestParams.ContainsKey("sid"))
            {
                requestParams.Add("sid", FileSync.CurrentUser.SessionID);
            }

            FileSyncAPIRequestFileParam fileParam = IsUploadFile(requestParams);
            if (fileParam != null)
            {
                requestParams.Remove(fileParam.FileKey);
                AsyncRequestAPIWithFile(requestUrl, httpMethod, requestParams, fileParam);
            }
            else
            {
                AsyncRequestAPI(requestUrl, httpMethod, requestParams);
            }
        }
        #endregion

        #region Private Method With Files

        /// <summary>
        /// 请求上传图片API接口
        /// </summary>
        /// <param name="requestUri">API请求的uri</param>
        /// <param name="httpMethod">API的请求方式</param>
        /// <param name="requestParams">API的请求参数</param>
        /// <param name="imageParam">图片参数</param>
        private void AsyncRequestAPIWithFile(string requestUri, string httpMethod, Dictionary<string, object> requestParams, FileSyncAPIRequestFileParam fileParam)
        {
            HttpWebRequest request;
            FileSyncAPIRequestState state = new FileSyncAPIRequestState();
            try
            {
                requestUri = FileSyncUtility.AddParametersToURL(requestUri, requestParams);
                request = (HttpWebRequest)WebRequest.Create(requestUri);

                boundary = "----------" + DateTime.Now.Ticks.ToString("X");
                request.Method = httpMethod;
                request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;

                state.request = request;
                state.requestParams = requestParams;
                state.fileParam = fileParam;

                request.BeginGetRequestStream(new AsyncCallback(RequestReadyWithFile), state);
            }
            catch (Exception ex)
            {
                if (DownloadStringCompleted != null)
                {
                    FileSyncError error = new FileSyncError();
                    error.error_code = requestErrorDomain;
                    error.error_msg = "A Error Occurred While Creating HTTP Web Request." + ex.Message;
                    //System.Windows.Deployment.Current.Dispatcher.BeginInvoke(delegate()
                    // {
                    if (DownloadStringCompleted != null)
                    {
                        DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(FileSyncAPIRequestResult.Fail, error));
                    }
                    // });
                }
            }
        }

        /// <summary>
        /// 准备上传图片API的请求参数
        /// </summary>
        /// <param name="asyncResult">完成异步请求的对象</param>
        void RequestReadyWithFile(IAsyncResult asyncResult)
        {
            FileSyncAPIRequestState state = asyncResult.AsyncState as FileSyncAPIRequestState;
            HttpWebRequest request = state.request;

            byte[] beginBoundary = Encoding.UTF8.GetBytes("--" + boundary + "\r\n");
            byte[] subEndBoundary = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundary = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--");

            //request.ContentLength=beginBoundary.Length+

            //由于QNAP的API是吧参数放在url中，不是request body. 所以不需要这段逻辑
            //Dictionary<string, object> paras = state.requestParams;
            //string paraTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            //string fileTemplate = "Content-Disposition: form-data; name=\"{0}\";filename=\"file.png\"\r\nContent-Type: image/png\r\n\r\n";
            string fileTemplate = "Content-Disposition: form-data; name=\"{0}\";filename=\"{0}\"\r\nContent-Type: application/octet-stream\r\n\r\n";//application/octet-stream是不是通用的？ 2015-02-13 Rocky

            using (Stream stream = request.EndGetRequestStream(asyncResult))
            {
                stream.Write(beginBoundary, 0, beginBoundary.Length);

                //foreach (KeyValuePair<string, object> param in state.requestParams)
                //{
                //    string value = param.Value as string;
                //    if (value != null)
                //    {
                //        byte[] bpara = Encoding.UTF8.GetBytes(String.Format(paraTemplate, param.Key, value));
                //        stream.Write(bpara, 0, bpara.Length);
                //        stream.Write(subEndBoundary, 0, subEndBoundary.Length);
                //    }
                //}

                string str = String.Format(fileTemplate, state.fileParam.FileKey);
                byte[] bfile = Encoding.UTF8.GetBytes(str);
                stream.Write(bfile, 0, bfile.Length);
                stream.Write(state.fileParam.FileData, 0, state.fileParam.FileData.Length);

                stream.Write(endBoundary, 0, endBoundary.Length);
            }
            request.BeginGetResponse(new AsyncCallback(ResponseReady), request);
        }

        #endregion

        #region Private Method Without File
        /// <summary>
        /// 请求普通API接口
        /// </summary>
        /// <param name="requestUri">API请求的uri</param>
        /// <param name="httpMethod">API的请求方式</param>
        /// <param name="requestParams">API的请求参数</param>
        private void AsyncRequestAPI(string requestUri, string httpMethod, Dictionary<string, object> requestParams)
        {
            HttpWebRequest request;
            try
            {
                // POST
                if (httpMethod == "POST")
                {
                    requestUri = FileSyncUtility.AddParametersToURL(requestUri, requestParams);
                    FileSyncAPIRequestState state = new FileSyncAPIRequestState();
                    request = (HttpWebRequest)WebRequest.Create(requestUri);
                    request.Method = httpMethod;
                    request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                    //平台统计用
                    request.UserAgent = "FileSync Windows SDK " + FileSync.Config.SDKVersion + "(windows; " + Environment.OSVersion.Platform + ")";
                    state.request = request;
                    state.requestParams = requestParams;

                    request.BeginGetRequestStream(new AsyncCallback(RequestReady), state);
                }
                else if (httpMethod == "GET")
                {
                    requestUri = FileSyncUtility.AddParametersToURL(requestUri, requestParams);
                    request = (HttpWebRequest)WebRequest.Create(requestUri);
                    request.Method = httpMethod;
                    request.BeginGetResponse(ResponseReady, request);
                }
            }
            catch
            {
                if (DownloadStringCompleted != null)
                {
                    FileSyncError error = new FileSyncError();
                    error.error_code = requestErrorDomain;
                    error.error_msg = "A Error Occurred While Creating HTTP Web Request.";
                    if (DownloadStringCompleted != null)
                    {
                        DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(FileSyncAPIRequestResult.Fail, error));
                    }
                }
            }
        }

        /// <summary>
        /// 准备普通API的请求参数
        /// </summary>
        /// <param name="asyncResult">完成异步请求的对象</param>
        void RequestReady(IAsyncResult asyncResult)
        {
            FileSyncAPIRequestState state = asyncResult.AsyncState as FileSyncAPIRequestState;
            HttpWebRequest request = state.request;
            Dictionary<string, object> requestParam = state.requestParams;
            string querystring = FileSyncUtility.GetQueryFromParams(requestParam);

            using (Stream stream = request.EndGetRequestStream(asyncResult))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(querystring);
                    writer.Flush();
                }
            }
            request.BeginGetResponse(new AsyncCallback(ResponseReady), request);
        }

        #endregion

        #region Response Ready
        /// <summary>
        /// 处理API请求返回的信息
        /// </summary>
        /// <param name="asyncResult">异步请求返回的结果</param>
        void ResponseReady(IAsyncResult asyncResult)
        {
            HttpWebRequest request = asyncResult.AsyncState as HttpWebRequest;
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.EndGetResponse(asyncResult);

                string result = string.Empty;
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                if (DownloadStringCompleted != null)
                {
                    DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(FileSyncAPIRequestResult.Success, result));
                }
            }
            catch (Exception ex)
            {
                if (DownloadStringCompleted != null)
                {
                    FileSyncError error = new FileSyncError();
                    error.error_code = requestErrorDomain;
                    error.error_msg = "No response." + ex.Message;

                    if (DownloadStringCompleted != null)
                    {
                        DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(FileSyncAPIRequestResult.Fail, error));
                    }
                }
            }
        }

        /// <summary>
        /// 判断是否是上传照片
        /// </summary>
        private FileSyncAPIRequestFileParam IsUploadFile(Dictionary<string, object> requestParams)
        {
            FileSyncAPIRequestFileParam fileParam = null;

            foreach (KeyValuePair<string, object> param in requestParams)
            {
                FileInfo fileTemp = param.Value as FileInfo;
                if (fileTemp != null)
                {
                    fileParam = new FileSyncAPIRequestFileParam();
                    fileParam.FileKey = param.Key;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        FileStream stream = new FileStream(fileTemp.FullName, FileMode.Open);
                        //stream.Seek(0, SeekOrigin.Begin);

                        byte[] bytes = new byte[stream.Length];
                        stream.Read(bytes, 0, bytes.Length);

                        // 设置当前流的位置为流的开始 
                        stream.Seek(0, SeekOrigin.Begin);

                        fileParam.FileData = bytes;

                        stream.Close();
                    }
                }
            }

            return fileParam;
        }

        #endregion
    }

    class FileSyncAPIRequestState
    {
        #region Properties
        /// <summary>
        /// 负责web请求的对象
        /// </summary>
        public HttpWebRequest request { get; set; }
        /// <summary>
        /// 请求的参数
        /// </summary>
        public Dictionary<string, object> requestParams { get; set; }
        /// <summary>
        /// 请求的图片参数
        /// </summary>
        public FileSyncAPIRequestFileParam fileParam { get; set; }
        #endregion
    }

}
