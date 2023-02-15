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

        public ExampleUpdateModel()
        {

        }

        public ExampleUpdateModel(string response, MessageVO messageVO, Example example)
        {
            Response = response;
            MessageVO = messageVO;
            Example = example;
        }
    }

    public class ExampleDeleteModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public bool? Delete { get; set; }

        public ExampleDeleteModel()
        {
            
        }

        public ExampleDeleteModel(string response, MessageVO messageVO, bool? delete)
        {
            Response = response;
            MessageVO = messageVO;
            Delete = delete;
        }
    }

    public class ExampleListModel
    {
        public List<string> Response { get; set; }
        public List<MessageVO> MessageVO { get; set; }
        public List<Example> Example { get; set; }
        public int PageIndex { get; set; }
        public long? Count { get; set; }
        public int PageSizeMaximun { get; set; }

        public ExampleListModel()
        {

        }

        public ExampleListModel(List<string> response, List<MessageVO> messageVO, List<Example> example, int pageIndex, long? count, int pageSizeMaximun)
        {
            Response = response;
            MessageVO = messageVO;
            Example = example;
            PageIndex = pageIndex;
            Count = count;
            PageSizeMaximun = pageSizeMaximun;
        }
    }

    public class ExampleConfirmModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }
        public Example Example { get; set; }
        public bool? Updated { get; set; }

        public ExampleConfirmModel()
        {

        }

        public ExampleConfirmModel(string response, MessageVO messageVO, Example example, bool? updated)
        {
            Response = response;
            MessageVO = messageVO;
            Example = example;
            Updated = updated;
        }
    }

    public class ExampleDownloadModel
    {
        public string Response { get; set; }
        public MessageVO MessageVO { get; set; }

        public ExampleDownloadModel()
        {

        }

        public ExampleDownloadModel(string response, MessageVO messageVO)
        {
            Response = response;
            MessageVO = messageVO;
        }
    }
}