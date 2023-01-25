using Business.Implementation;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CheckController : Controller
    {
        MessageVO messageVO = new MessageVO();
        ContentHTML contentHTML = new ContentHTML();

        [HttpGet]
        public ActionResult Check()
        {
            CheckCheckModel checkCheckModel = new CheckCheckModel()
            {
                MessageVO = null,
                HttpStatusCode = null
            };
            try
            {
                if (contentHTML.IsLoadDocumentHTML())
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("checkTitle"), contentHTML.GetInnerTextById("correctCheckMessage"));
                    checkCheckModel.HttpStatusCode = HttpStatusCode.OK;
                }
                else
                {
                    messageVO.SetMessage(0, "Verificacion de API", "Servicio no responde correctamente, funcionalidad no se ha ejecutado segun lo esperado");
                    checkCheckModel.HttpStatusCode = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                checkCheckModel.HttpStatusCode = HttpStatusCode.InternalServerError;
            }
            checkCheckModel.MessageVO = messageVO;
            return View(checkCheckModel);
        }

        [HttpGet]
        public ActionResult OpenAPICSharpCheck()
        {
            CheckOpenAPICSharpCheck checkOpenAPICSharpCheck = new CheckOpenAPICSharpCheck()
            {
                Response = string.Empty,
                MessageVO = null,
                MessageVOOk = null
            };
            Tuple<string, MessageVO, MessageVO> tupleCheckMethod = new Tuple<string, MessageVO, MessageVO>(null, null, null);
            try
            {
                tupleCheckMethod = CheckImpl.Check();

                if (!string.IsNullOrWhiteSpace(tupleCheckMethod.Item1))
                    checkOpenAPICSharpCheck.Response = tupleCheckMethod.Item1;
                else if (tupleCheckMethod.Item2 != null)
                    checkOpenAPICSharpCheck.MessageVO = tupleCheckMethod.Item2;
                else if (tupleCheckMethod.Item3 != null)
                    checkOpenAPICSharpCheck.MessageVOOk = tupleCheckMethod.Item3;

            }
            catch (Exception ex)
            {
                checkOpenAPICSharpCheck.Response = ex.GetOriginalException().Message;
            }
            return View(checkOpenAPICSharpCheck);
        }

        [HttpGet]
        public ActionResult OpenAPICSharpCheckAuth()
        {
            CheckOpenAPICSharpCheckAuth checkOpenAPICSharpCheckAuth = new CheckOpenAPICSharpCheckAuth()
            {
                Response = string.Empty,
                MessageVO = null,
                MessageVOOk = null
            };
            Tuple<string, MessageVO, MessageVO> tupleCheckAuthMethod = new Tuple<string, MessageVO, MessageVO>(null, null, null);
            try
            {
                tupleCheckAuthMethod = CheckImpl.CheckAuth();

                if (!string.IsNullOrWhiteSpace(tupleCheckAuthMethod.Item1))
                    checkOpenAPICSharpCheckAuth.Response = tupleCheckAuthMethod.Item1;
                else if (tupleCheckAuthMethod.Item2 != null)
                    checkOpenAPICSharpCheckAuth.MessageVO = tupleCheckAuthMethod.Item2;
                else if (tupleCheckAuthMethod.Item3 != null)
                    checkOpenAPICSharpCheckAuth.MessageVOOk = tupleCheckAuthMethod.Item3;

            }
            catch (Exception ex)
            {
                checkOpenAPICSharpCheckAuth.Response = ex.GetOriginalException().Message;
            }
            return View(checkOpenAPICSharpCheckAuth);
        }
    }
}