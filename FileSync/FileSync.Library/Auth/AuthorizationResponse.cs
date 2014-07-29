using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSync.Library
{
    public class AuthorizationResponse : IResponse
    {
        public string RawResponse { get; set; }

        public string AuthPassed { get; set; }

        public string AuthSid { get; set; }

        public bool IsAdmin { get; set; }
    }
}
