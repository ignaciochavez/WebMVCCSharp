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

        public HeroeUpdateModel()
        {

        }

        public HeroeUpdateModel(string response, MessageVO messageVO, Heroe heroe)
        {
            Response = response;
            MessageVO = messageVO;
            Heroe = heroe;
        }
    }

    public class HeroeDeleteModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public bool? Delete { get; set; }

        public HeroeDeleteModel()
        {

        }

        public HeroeDeleteModel(string response, MessageVO messageVO, bool? delete)
        {
            Response = response;
            MessageVO = messageVO;
            Delete = delete;
        }
    }

    public class HeroeListModel
    {
        public List<string> Response { get; set; }
        public List<MessageVO> MessageVO { get; set; }
        public List<Heroe> Heroe { get; set; }
        public int PageIndex { get; set; }
        public long? Count { get; set; }
        public int PageSizeMaximun { get; set; }

        public HeroeListModel()
        {

        }

        public HeroeListModel(List<string> response, List<MessageVO> messageVO, List<Heroe> heroe, int pageIndex, long? count, int pageSizeMaximun)
        {
            Response = response;
            MessageVO = messageVO;
            Heroe = heroe;
            PageIndex = pageIndex;
            Count = count;
            PageSizeMaximun = pageSizeMaximun;
        }
    }

    public class HeroeConfirmModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public Heroe Heroe { get; set; }
        public bool? Updated { get; set; }

        public HeroeConfirmModel()
        {

        }

        public HeroeConfirmModel(string response, MessageVO messageVO, Heroe heroe, bool? updated)
        {
            Response = response;
            MessageVO = messageVO;
            Heroe = heroe;
            Updated = updated;
        }
    }

    public class HeroeDownloadModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }

        public HeroeDownloadModel()
        {

        }

        public HeroeDownloadModel(string response, MessageVO messageVO)
        {
            Response = response;
            MessageVO = messageVO;
        }
    }
}