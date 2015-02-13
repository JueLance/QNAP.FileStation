using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FileSyncSDK
{
    public class Authorization
    {
        FileSync m_fsConnect = null;
        FileSyncAPIRequest.FileSyncRequestCompletedHandler tempCallback = null;

        private const string requestErrorDomain = "99999999";

        public Authorization(FileSync fsConnect)
        {
            m_fsConnect = fsConnect;
        }

        public void Authorize(string username, string password, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("user", username);
            dict.Add("pwd", password);

            tempCallback = callback;

            m_fsConnect.SendRequest("authLogin.cgi", "GET", dict, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(AuthorizeFinish));
        }

        private void AuthorizeFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        FileSyncAuthorizeInfo authInfo = new FileSyncAuthorizeInfo();

                        string xml = arg.Response;

                        XmlDocument xd = new XmlDocument();
                        xd.LoadXml(xml);

                        authInfo.AuthSid = xd.SelectSingleNode("/QDocRoot/authSid").InnerText;
                        authInfo.UserName = xd.SelectSingleNode("/QDocRoot/username").InnerText;

                        FileSync.CurrentUser.SaveUserSessionInfo(authInfo);

                        if (tempCallback != null)
                        {
                            tempCallback(this, arg);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (tempCallback != null)
                        {
                            FileSyncError error = new FileSyncError();
                            error.error_code = requestErrorDomain;
                            error.error_msg = "An error occurs when parse server response." + ex.Message;

                            tempCallback(this, new FileSyncRequestResultEventArgs(FileSyncAPIRequestResult.Fail, error));
                        }
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    if (tempCallback != null)
                    {
                        tempCallback(this, arg);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
