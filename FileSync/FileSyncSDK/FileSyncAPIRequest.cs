using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace FileSyncDemo
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
                    DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(null, FileSyncAPIRequestResult.Fail, error));
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
            HttpWebRequest request = null;
            FileSyncAPIRequestState state = new FileSyncAPIRequestState();
            try
            {
                requestUri = FileSyncUtility.AddParametersToURL(requestUri, requestParams);
                request = (HttpWebRequest)WebRequest.Create(new Uri(requestUri));

                boundary = "----------" + DateTime.Now.Ticks.ToString("x");

                byte[] beginBoundary = Encoding.UTF8.GetBytes(string.Format("--{0}\r\n", boundary));

                string fileTemplate = "Content-Disposition: form-data; name=\"file\"; filename=\"{0}\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                byte[] bfile = Encoding.UTF8.GetBytes(String.Format(fileTemplate, fileParam.FileKey));

                byte[] endBoundary = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                request.Method = httpMethod;
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                request.ContentLength = beginBoundary.Length + bfile.Length + fileParam.FileData.Length + endBoundary.Length;
                request.AllowWriteStreamBuffering = false;
                request.Timeout = 300000;

                state.request = request;
                state.requestParams = requestParams;
                state.fileParam = fileParam;
                state.beginBoundary = beginBoundary;
                state.bfile = bfile;
                state.endBoundary = endBoundary;

                request.BeginGetRequestStream(new AsyncCallback(RequestReadyWithFile), state);
            }
            catch (Exception ex)
            {
                if (DownloadStringCompleted != null)
                {
                    FileSyncError error = new FileSyncError();
                    error.error_code = requestErrorDomain;
                    error.error_msg = "A Error Occurred While Creating HTTP Web Request. " + ex.Message;
                    //System.Windows.Deployment.Current.Dispatcher.BeginInvoke(delegate()
                    // {
                    if (DownloadStringCompleted != null)
                    {
                        DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(request == null ? null : request.Address, FileSyncAPIRequestResult.Fail, error) { RequestParams = requestParams });
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

            using (Stream stream = request.EndGetRequestStream(asyncResult))
            {
                stream.Write(state.beginBoundary, 0, state.beginBoundary.Length);
                stream.Write(state.bfile, 0, state.bfile.Length);
                stream.Write(state.fileParam.FileData, 0, state.fileParam.FileData.Length);
                stream.Write(state.endBoundary, 0, state.endBoundary.Length);
            }
            request.BeginGetResponse(new AsyncCallback(ResponseReady), state);
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
            HttpWebRequest request = null;
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

                    FileSyncAPIRequestState state = new FileSyncAPIRequestState();
                    state.request = request;
                    state.requestParams = requestParams;

                    request.BeginGetResponse(ResponseReady, state);
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
                        DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(request == null ? null : request.Address, FileSyncAPIRequestResult.Fail, error));
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
            request.BeginGetResponse(new AsyncCallback(ResponseReady), state);
        }

        #endregion

        #region Response Ready
        /// <summary>
        /// 处理API请求返回的信息
        /// </summary>
        /// <param name="asyncResult">异步请求返回的结果</param>
        void ResponseReady(IAsyncResult asyncResult)
        {
            FileSyncAPIRequestState state = asyncResult.AsyncState as FileSyncAPIRequestState;
            HttpWebRequest request = state.request;
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
                    DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(request == null ? null : request.Address, FileSyncAPIRequestResult.Success, result) { RequestParams = state.requestParams });
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
                        DownloadStringCompleted(this, new FileSyncRequestResultEventArgs(request == null ? null : request.Address, FileSyncAPIRequestResult.Fail, error) { RequestParams = state.requestParams });
                    }
                }
            }
        }

        /// <summary>
        /// 判断是否是上传文件
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

                    using (FileStream stream = new FileStream(fileTemp.FullName, FileMode.Open))
                    {
                        byte[] bytes = new byte[stream.Length];

                        stream.Seek(0, SeekOrigin.Begin);
                        stream.Read(bytes, 0, bytes.Length);

                        fileParam.FileData = bytes;
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
        /// <summary>
        /// 
        /// </summary>
        public byte[] beginBoundary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] endBoundary { get; set; }
        /// <summary>
        /// 请求的图片参数
        /// </summary>
        public byte[] bfile { get; set; }

        #endregion
    }

}
