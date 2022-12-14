using Business.Entity;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ExampleUpdateModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public Example Example { get; set; }
    }

    public class ExampleDeleteModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public bool? Delete { get; set; }
    }

    public class ExampleListModel
    {
        public List<string> Response { get; set; }
        public List<MessageVO> MessageVO { get; set; }
        public List<Example> Example { get; set; }
        public int PageIndex { get; set; }
        public long? Count { get; set; }
        public int PageSizeMaximun { get; set; }
    }

    public class ExampleConfirmModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public Example Example { get; set; }
        public bool? Updated { get; set; }
        public string UrlButton { get; set; }
        public string ValueButton { get; set; }
    }

    public class ExampleDownloadModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
    }
}