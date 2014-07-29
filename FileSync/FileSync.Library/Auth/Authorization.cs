using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FileSync.Library
{
    public class Authorization
    {
        public AuthorizationResponse Login(string username, string password)
        {
            string url = Util.BuildUrl(string.Format("authLogin.cgi?user={0}&pwd={1}", username, password));
            string xml = HttpHelper.Get(url);

            return (AuthorizationResponse)MappingResponse(xml);
        }

        private IResponse MappingResponse(string xml)
        {
            AuthorizationResponse response = new AuthorizationResponse();

            try
            {
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(xml);

                XmlNode xn = xd.SelectSingleNode("/QDocRoot/authSid");

                if (xn != null)
                {
                    response.AuthSid = xn.InnerText;
                }
            }
            catch (Exception ex)
            {
                response.RawResponse = ex.Message;

                throw ex;
            }

            return response;
        }
    }
}
