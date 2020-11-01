using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebServiceASMX
{
    public class Auth:SoapHeader
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}