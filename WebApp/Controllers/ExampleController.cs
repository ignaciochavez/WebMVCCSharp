using Business.DTO;
using Business.Entity;
using Business.Implementation;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ExampleController : Controller
    {
        private ContentHTML contentHTML = new ContentHTML();
        private MessageVO messageVO = new MessageVO();

        [HttpGet]
        public ActionResult Insert()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult Update(int? id = 0)
        {
            ExampleUpdateModel exampleUpdateModel = new ExampleUpdateModel(string.Empty, null, null);
            Tuple<string, MessageVO, Example> tupleSelectMethod = new Tuple<string, MessageVO, Example>(null, null, null);
            try
            {
                if (id == null)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersNull").Replace("{0}", "id"));
                else if (id.Value <= 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    exampleUpdateModel.MessageVO = messageVO;
                }
                else if (id.Value > 0)
                {
                    tupleSelectMethod = ExampleImpl.Select(id.Value);

                    if (!string.IsNullOrWhiteSpace(tupleSelectMethod.Item1))
                        exampleUpdateModel.Response = tupleSelectMethod.Item1;
                    else if (tupleSelectMethod.Item2 != null)
                        exampleUpdateModel.MessageVO = tupleSelectMethod.Item2;
                    else if (tupleSelectMethod.Item3 != null)
                        exampleUpdateModel.Example = tupleSelectMethod.Item3;
                }
            }
            catch (Exception ex)
            {
                exampleUpdateModel.Response = ex.GetOriginalException().Message;
            }
            return View(exampleUpdateModel);
        }

        [HttpPost]
        public ActionResult Delete(int? id = 0)
        {
            ExampleDeleteModel exampleDeleteModel = new ExampleDeleteModel(string.Empty, null, null);
            Tuple<string, MessageVO, bool?> tupleDeleteMethod = new Tuple<string, MessageVO, bool?>(null, null, null);
            try
            {
                if (id == null)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersNull").Replace("{0}", "id"));
                else if (id.Value <= 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    exampleDeleteModel.MessageVO = messageVO;
                }
                else if (id.Value > 0)
                {
                    tupleDeleteMethod = ExampleImpl.Delete(id.Value);

                    if (!string.IsNullOrWhiteSpace(tupleDeleteMethod.Item1))
                        exampleDeleteModel.Response = tupleDeleteMethod.Item1;
                    else if (tupleDeleteMethod.Item2 != null)
                        exampleDeleteModel.MessageVO = tupleDeleteMethod.Item2;
                    else if (tupleDeleteMethod.Item3 != null)
                        exampleDeleteModel.Delete = tupleDeleteMethod.Item3;
                }                
            }
            catch (Exception ex)
            {
                exampleDeleteModel.Response = ex.GetOriginalException().Message;
            }
            return View(exampleDeleteModel);
        }
        
        [HttpGet]
        public ActionResult List(int? pageIndex = 1)
        {
            ExampleListModel exampleListModel = new ExampleListModel(new List<string>(), new List<MessageVO>(), new List<Example>(), 0, null, 0);
            Tuple<string, MessageVO, List<Example>> tupleListMethod = new Tuple<string, MessageVO, List<Example>>(null, null, null);
            Tuple<string, MessageVO, long?> tupleCountMethod = new Tuple<string, MessageVO, long?>(null, null, null);
            try
            {
                if (pageIndex == null)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersNull").Replace("{0}", "pageIndex"));
                else if (pageIndex.Value <= 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "pageIndex"));

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    exampleListModel.MessageVO.Add(messageVO);
                }
                else
                {
                    exampleListModel.PageSizeMaximun = Useful.GetPageSizeMaximun();
                    tupleListMethod = ExampleImpl.List(new ExampleListDTO(pageIndex.Value, exampleListModel.PageSizeMaximun));

                    if (tupleListMethod.Item3 != null && tupleListMethod.Item3.Count() == 0)
                        exampleListModel.PageIndex = 0;
                    else
                        exampleListModel.PageIndex = pageIndex.Value;

                    if (!string.IsNullOrWhiteSpace(tupleListMethod.Item1))
                        exampleListModel.Response.Add(tupleListMethod.Item1);
                    else if (tupleListMethod.Item2 != null)
                        exampleListModel.MessageVO.Add(tupleListMethod.Item2);
                    else if (tupleListMethod.Item3 != null)
                        exampleListModel.Example = tupleListMethod.Item3;

                    if (tupleListMethod.Item3 != null && tupleListMethod.Item3.Count() > 0)
                    {
                        tupleCountMethod = ExampleImpl.TotalRecords();

                        if (!string.IsNullOrWhiteSpace(tupleCountMethod.Item1))
                            exampleListModel.Response.Add(tupleCountMethod.Item1);
                        else if (tupleCountMethod.Item2 != null)
                            exampleListModel.MessageVO.Add(tupleCountMethod.Item2);
                        else if (tupleCountMethod.Item3 != null)
                            exampleListModel.Count = tupleCountMethod.Item3;
                    }
                }
            }
            catch (Exception ex)
            {                
                exampleListModel.Response.Add(ex.GetOriginalException().Message);
            }
            return View(exampleListModel);
        }

        [HttpPost]
        public ActionResult ConfirmFormExample(int id, string inputRut, string inputName, string inputLastName, string inputBirthDate, string inputActiveRadioOptions, string inputPassword)
        {
            ExampleConfirmModel exampleConfirmModel = new ExampleConfirmModel(string.Empty, null, null, null);
            Tuple<string, MessageVO, bool?> tupleUpdateMethod = new Tuple<string, MessageVO, bool?>(null, null, null);
            Tuple<string, MessageVO, Example> tupleInsertMethod = new Tuple<string, MessageVO, Example>(null, null, null);
            try
            {
                if (id < 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parameterMustBeGreaterThanOrEqualToZero").Replace("{0}", "id"));

                inputRut = (!string.IsNullOrWhiteSpace(inputRut)) ? inputRut.Replace(".", "") : inputRut;

                if (string.IsNullOrWhiteSpace(inputRut))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Rut"));
                else if (inputRut.Trim().Length > 12)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Rut").Replace("{1}", "12"));
                else if (!Useful.ValidateRut(inputRut))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "Rut"));

                if (string.IsNullOrWhiteSpace(inputName))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                else if (inputName.Trim().Length > 45)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                if (string.IsNullOrWhiteSpace(inputLastName))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "LastName"));
                else if (inputLastName.Trim().Length > 45)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "LastName").Replace("{1}", "45"));
                
                DateTimeOffset birthDate = new DateTimeOffset();
                bool isDate = DateTimeOffset.TryParseExact(inputBirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
                if (!isDate)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "BirthDate"));
                else if (!Useful.ValidateDateTimeOffset(birthDate))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "BirthDate"));
                else if (birthDate > DateTimeOffset.Now)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "BirthDate"));
                
                if (string.IsNullOrWhiteSpace(inputActiveRadioOptions))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parameterNotSelected").Replace("{0}", "Active"));
                else if (inputActiveRadioOptions != "yes" && inputActiveRadioOptions != "no")
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("formatMustBe").Replace("{0}", "yes y no"));

                if (string.IsNullOrWhiteSpace(inputPassword))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Password"));
                else if (inputPassword.Trim().Length > 16)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Password").Replace("{1}", "16"));

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    exampleConfirmModel.MessageVO = messageVO;
                }
                else
                {           
                    if (id > 0)
                    {
                        tupleUpdateMethod = ExampleImpl.Update(new Example(id, inputRut.Trim(), inputName.Trim(), inputLastName.Trim(), birthDate, ((inputActiveRadioOptions.Trim() == "yes") ? true : false), inputPassword));

                        if (!string.IsNullOrWhiteSpace(tupleUpdateMethod.Item1))
                            exampleConfirmModel.Response = tupleUpdateMethod.Item1;
                        else if (tupleUpdateMethod.Item2 != null)
                            exampleConfirmModel.MessageVO = tupleUpdateMethod.Item2;
                        else if (tupleUpdateMethod.Item3 != null)
                            exampleConfirmModel.Updated = tupleUpdateMethod.Item3;
                    }
                    else
                    {
                        tupleInsertMethod = ExampleImpl.Insert(new ExampleInsertDTO(inputRut.Trim(), inputName.Trim(), inputLastName.Trim(), birthDate, ((inputActiveRadioOptions.Trim() == "yes") ? true : false), inputPassword));

                        if (!string.IsNullOrWhiteSpace(tupleInsertMethod.Item1))
                            exampleConfirmModel.Response = tupleInsertMethod.Item1;
                        else if (tupleInsertMethod.Item2 != null)
                            exampleConfirmModel.MessageVO = tupleInsertMethod.Item2;
                        else if (tupleInsertMethod.Item3 != null)
                            exampleConfirmModel.Example = tupleInsertMethod.Item3;
                    }
                }
                
            }
            catch (Exception ex)
            {
                exampleConfirmModel.Response = ex.GetOriginalException().Message;
            }
            return View(exampleConfirmModel);
        }

        [HttpPost]
        public ActionResult Download(ExampleDownloadModel exampleDownloadModel)
        {
            try
            {
                return View(exampleDownloadModel);
            }
            catch (Exception ex)
            {
                exampleDownloadModel.Response = ex.GetOriginalException().Message;
                return View(exampleDownloadModel);
            }
        }

        [HttpPost]
        public ActionResult DownloadExcel()
        {
            ExampleDownloadModel exampleDownloadModel = new ExampleDownloadModel(string.Empty, null);
            Tuple<string, MessageVO, ExampleExcelDTO> tupleExcelMethod = new Tuple<string, MessageVO, ExampleExcelDTO>(null, null, null);
            try
            {
                tupleExcelMethod = ExampleImpl.Excel();
                if (!string.IsNullOrWhiteSpace(tupleExcelMethod.Item1))
                    exampleDownloadModel.Response = tupleExcelMethod.Item1;
                else if (tupleExcelMethod.Item2 != null)
                    exampleDownloadModel.MessageVO = tupleExcelMethod.Item2;

                if (!string.IsNullOrWhiteSpace(exampleDownloadModel.Response) || exampleDownloadModel.MessageVO != null)
                    return View("Download", exampleDownloadModel);
                else
                    return File(tupleExcelMethod.Item3.FileContent, "application/vnd.ms-excel", tupleExcelMethod.Item3.FileName);
            }
            catch (Exception ex)
            {
                exampleDownloadModel.Response = ex.GetOriginalException().Message;
                return View("Download", exampleDownloadModel);
            }
        }

        [HttpPost]
        public ActionResult DownloadPDF()
        {
            ExampleDownloadModel exampleDownloadModel = new ExampleDownloadModel(string.Empty, null);
            Tuple<string, MessageVO, ExamplePDFDTO> tuplePDFMethod = new Tuple<string, MessageVO, ExamplePDFDTO>(null, null, null);
            try
            {
                tuplePDFMethod = ExampleImpl.PDF();
                if (!string.IsNullOrWhiteSpace(tuplePDFMethod.Item1))
                    exampleDownloadModel.Response = tuplePDFMethod.Item1;
                else if (tuplePDFMethod.Item2 != null)
                    exampleDownloadModel.MessageVO = tuplePDFMethod.Item2;

                if (!string.IsNullOrWhiteSpace(exampleDownloadModel.Response) || exampleDownloadModel.MessageVO != null)
                    return View("Download", exampleDownloadModel);
                else
                    return File(tuplePDFMethod.Item3.FileContent, "application/pdf", tuplePDFMethod.Item3.FileName);
            }
            catch (Exception ex)
            {
                exampleDownloadModel.Response = ex.GetOriginalException().Message;
                return View("Download", exampleDownloadModel);
            }
        }        
    }
}