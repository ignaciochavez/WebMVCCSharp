using Business.Entity;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class HeroeUpdateModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public Heroe Heroe { get; set; }
    }

    public class HeroeDeleteModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public bool? Delete { get; set; }
    }

    public class HeroeListModel
    {
        public List<string> Response { get; set; }
        public List<MessageVO> MessageVO { get; set; }
        public List<Heroe> Heroe { get; set; }
        public int PageIndex { get; set; }
        public long? Count { get; set; }
        public int PageSizeMaximun { get; set; }
    }

    public class HeroeConfirmModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public Heroe Heroe { get; set; }
        public bool? Updated { get; set; }
    }

    public class HeroeDownloadModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
    }
}