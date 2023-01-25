using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApp.Models
{
    public class CheckCheckModel
    {
        public MessageVO MessageVO { get; set; }
        public HttpStatusCode? HttpStatusCode { get; set; }
    }

    public class CheckOpenAPICSharpCheck
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public MessageVO MessageVOOk { get; set; }
    }

    public class CheckOpenAPICSharpCheckAuth
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public MessageVO MessageVOOk { get; set; }
    }
}