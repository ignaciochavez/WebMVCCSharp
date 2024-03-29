﻿using Business.Tool;
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

        public CheckCheckModel()
        {

        }

        public CheckCheckModel(MessageVO messageVO, HttpStatusCode? httpStatusCode)
        {
            MessageVO = messageVO;
            HttpStatusCode = httpStatusCode;
        }
    }

    public class CheckOpenAPICSharpCheck
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public MessageVO MessageVOOk { get; set; }

        public CheckOpenAPICSharpCheck()
        {

        }

        public CheckOpenAPICSharpCheck(string response, MessageVO messageVO, MessageVO messageVOOk)
        {
            Response = response;
            MessageVO = messageVO;
            MessageVOOk = messageVOOk;
        }
    }

    public class CheckOpenAPICSharpCheckAuth
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public MessageVO MessageVOOk { get; set; }

        public CheckOpenAPICSharpCheckAuth()
        {

        }

        public CheckOpenAPICSharpCheckAuth(string response, MessageVO messageVO, MessageVO messageVOOk)
        {
            Response = response;
            MessageVO = messageVO;
            MessageVOOk = messageVOOk;
        }
    }
}