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
    public class HeroeController : Controller
    {
        ContentHTML contentHTML = new ContentHTML();
        MessageVO messageVO = new MessageVO();

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update(int? id = 0)
        {
            HeroeUpdateModel heroeUpdateModel = new HeroeUpdateModel()
            {
                Response = string.Empty,
                MessageVO = null,
                Heroe = null
            };
            Tuple<string, MessageVO, Heroe> tupleSelectMethod = new Tuple<string, MessageVO, Heroe>(null, null, null);
            try
            {
                if (id == null)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersNull").Replace("{0}", "id"));
                else if (id.Value <= 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    heroeUpdateModel.MessageVO = messageVO;
                }
                else if (id.Value > 0)
                {
                    tupleSelectMethod = HeroeImpl.Select(id.Value);

                    if (!string.IsNullOrWhiteSpace(tupleSelectMethod.Item1))
                        heroeUpdateModel.Response = tupleSelectMethod.Item1;
                    else if (tupleSelectMethod.Item2 != null)
                        heroeUpdateModel.MessageVO = tupleSelectMethod.Item2;
                    else if (tupleSelectMethod.Item3 != null)
                        heroeUpdateModel.Heroe = tupleSelectMethod.Item3;
                }
            }
            catch (Exception ex)
            {
                heroeUpdateModel.Response = ex.GetOriginalException().Message;
            }
            return View(heroeUpdateModel);
        }

        [HttpPost]
        public ActionResult Delete(int? id = 0)
        {
            HeroeDeleteModel heroeDeleteModel = new HeroeDeleteModel()
            {
                Response = string.Empty,
                MessageVO = null,
                Delete = null
            };
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
                    heroeDeleteModel.MessageVO = messageVO;
                }
                else if (id.Value > 0)
                {
                    tupleDeleteMethod = HeroeImpl.Delete(id.Value);

                    if (!string.IsNullOrWhiteSpace(tupleDeleteMethod.Item1))
                        heroeDeleteModel.Response = tupleDeleteMethod.Item1;
                    else if (tupleDeleteMethod.Item2 != null)
                        heroeDeleteModel.MessageVO = tupleDeleteMethod.Item2;
                    else if (tupleDeleteMethod.Item3 != null)
                        heroeDeleteModel.Delete = tupleDeleteMethod.Item3;
                }                
            }
            catch (Exception ex)
            {
                heroeDeleteModel.Response = ex.GetOriginalException().Message;
            }
            return View(heroeDeleteModel);
        }

        [HttpGet]
        public ActionResult List(int? pageIndex = 1)
        {
            HeroeListModel heroeListModel = new HeroeListModel()
            {
                Response = new List<string>(),
                MessageVO = new List<MessageVO>(),
                Heroe = new List<Heroe>()
            };
            Tuple<string, MessageVO, List<Heroe>> tupleListMethod = new Tuple<string, MessageVO, List<Heroe>>(null, null, null);
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
                    heroeListModel.MessageVO.Add(messageVO);
                }
                else
                {
                    heroeListModel.PageSizeMaximun = Useful.GetPageSizeMaximun();
                    tupleListMethod = HeroeImpl.List(new HeroeListDTO() { PageIndex = pageIndex.Value, PageSize = heroeListModel.PageSizeMaximun });

                    if (tupleListMethod.Item3 != null && tupleListMethod.Item3.Count() == 0)
                        heroeListModel.PageIndex = 0;
                    else
                        heroeListModel.PageIndex = pageIndex.Value;

                    if (!string.IsNullOrWhiteSpace(tupleListMethod.Item1))
                        heroeListModel.Response.Add(tupleListMethod.Item1);
                    else if (tupleListMethod.Item2 != null)
                        heroeListModel.MessageVO.Add(tupleListMethod.Item2);
                    else if (tupleListMethod.Item3 != null)
                        heroeListModel.Heroe = tupleListMethod.Item3;

                    if (tupleListMethod.Item3 != null && tupleListMethod.Item3.Count() > 0)
                    {
                        tupleCountMethod = HeroeImpl.TotalRecords();

                        if (!string.IsNullOrWhiteSpace(tupleCountMethod.Item1))
                            heroeListModel.Response.Add(tupleCountMethod.Item1);
                        else if (tupleCountMethod.Item2 != null)
                            heroeListModel.MessageVO.Add(tupleCountMethod.Item2);
                        else if (tupleCountMethod.Item3 != null)
                            heroeListModel.Count = tupleCountMethod.Item3;
                    }
                }                
            }
            catch (Exception ex)
            {
                heroeListModel.Response.Add(ex.GetOriginalException().Message);
            }
            return View(heroeListModel);
        }

        [HttpPost]
        public ActionResult ConfirmFormHeroe(int id, string inputName, string inputHome, string inputAppearance, string inputDescription, string inputImgBase64String)
        {
            HeroeConfirmModel heroeConfirmModel = new HeroeConfirmModel()
            {
                Response = string.Empty,
                MessageVO = null,
                Heroe = null,
                Updated = null
            };
            Tuple<string, MessageVO, bool?> tupleUpdateMethod = new Tuple<string, MessageVO, bool?>(null, null, null);
            Tuple<string, MessageVO, Heroe> tupleInsertMethod = new Tuple<string, MessageVO, Heroe>(null, null, null);
            try
            {
                if (id < 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parameterMustBeGreaterThanOrEqualToZero").Replace("{0}", "id"));

                if (string.IsNullOrWhiteSpace(inputName))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                else if (inputName.Trim().Length > 45)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                if (string.IsNullOrWhiteSpace(inputHome))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Home"));
                else if (inputHome.Trim().Length > 35)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Home").Replace("{1}", "35"));
                
                DateTimeOffset Appearance = new DateTimeOffset();
                bool isDate = DateTimeOffset.TryParseExact(inputAppearance, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out Appearance);
                if (!isDate)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "Appearance"));
                else if (!Useful.ValidateDateTimeOffset(Appearance))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "Appearance"));
                else if (Appearance > DateTimeOffset.Now)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "Appearance"));

                if (string.IsNullOrWhiteSpace(inputDescription))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Description"));
                else if (inputDescription.Trim().Length > 450)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Description").Replace("{1}", "450"));

                if (string.IsNullOrWhiteSpace(inputImgBase64String))
                {
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "ImgBase64String"));
                }
                else if (!Useful.ValidateBase64String(Useful.ReplaceConventionImageFromBase64String(inputImgBase64String)))
                {
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "ImgBase64String"));
                }
                else
                {

                    string[] arrayImgBase64String = inputImgBase64String.Split(',');
                    if (!Useful.ValidateIsImageBase64String(arrayImgBase64String[0]))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("formatMustBe").Replace("{0}", "ImgBase64String").Replace("{1}", "bmp, emf, exif, gif, icon, jpeg, jpg, png, tiff o wmf"));

                }

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    heroeConfirmModel.MessageVO = messageVO;
                }
                else
                {
                    if (id > 0)
                    {
                        tupleUpdateMethod = HeroeImpl.Update(new Heroe() { Id = id, Name = inputName.Trim(), Home = inputHome.Trim(), Appearance = Appearance, Description = inputDescription.Trim(), ImgBase64String = inputImgBase64String.Trim() });

                        if (!string.IsNullOrWhiteSpace(tupleUpdateMethod.Item1))
                            heroeConfirmModel.Response = tupleUpdateMethod.Item1;
                        else if (tupleUpdateMethod.Item2 != null)
                            heroeConfirmModel.MessageVO = tupleUpdateMethod.Item2;
                        else if (tupleUpdateMethod.Item3 != null)
                            heroeConfirmModel.Updated = tupleUpdateMethod.Item3;
                    }
                    else
                    {
                        tupleInsertMethod = HeroeImpl.Insert(new HeroeInsertDTO() { Name = inputName.Trim(), Home = inputHome.Trim(), Appearance = Appearance, Description = inputDescription.Trim(), ImgBase64String = inputImgBase64String.Trim() });

                        if (!string.IsNullOrWhiteSpace(tupleInsertMethod.Item1))
                            heroeConfirmModel.Response = tupleInsertMethod.Item1;
                        else if (tupleInsertMethod.Item2 != null)
                            heroeConfirmModel.MessageVO = tupleInsertMethod.Item2;
                        else if (tupleInsertMethod.Item3 != null)
                            heroeConfirmModel.Heroe = tupleInsertMethod.Item3;
                    }
                }
            }
            catch (Exception ex)
            {
                heroeConfirmModel.Response = ex.GetOriginalException().Message;
            }
            return View(heroeConfirmModel);
        }

        [HttpPost]
        public ActionResult Download(HeroeDownloadModel heroeDownloadModel)
        {
            try
            {
                return View(heroeDownloadModel);
            }
            catch (Exception ex)
            {
                heroeDownloadModel.Response = ex.GetOriginalException().Message;
                return View(heroeDownloadModel);
            }
        }

        [HttpPost]
        public ActionResult DownloadExcel()
        {
            HeroeDownloadModel heroeDownloadModel = new HeroeDownloadModel()
            {
                Response = string.Empty,
                MessageVO = null
            };
            Tuple<string, MessageVO, HeroeExcelDTO> tupleExcelMethod = new Tuple<string, MessageVO, HeroeExcelDTO>(null, null, null);
            try
            {
                tupleExcelMethod = HeroeImpl.Excel();
                if (!string.IsNullOrWhiteSpace(tupleExcelMethod.Item1))
                    heroeDownloadModel.Response = tupleExcelMethod.Item1;
                else if (tupleExcelMethod.Item2 != null)
                    heroeDownloadModel.MessageVO = tupleExcelMethod.Item2;

                if (!string.IsNullOrWhiteSpace(heroeDownloadModel.Response) || heroeDownloadModel.MessageVO != null)
                    return View("Download", heroeDownloadModel);
                else
                    return File(tupleExcelMethod.Item3.FileContent, "application/vnd.ms-excel", tupleExcelMethod.Item3.FileName);
            }
            catch (Exception ex)
            {
                heroeDownloadModel.Response = ex.GetOriginalException().Message;
                return View("Download", heroeDownloadModel);
            }
        }

        [HttpPost]
        public ActionResult DownloadPDF()
        {
            HeroeDownloadModel heroeDownloadModel = new HeroeDownloadModel()
            {
                Response = string.Empty,
                MessageVO = null
            };
            Tuple<string, MessageVO, HeroePDFDTO> tuplePDFMethod = new Tuple<string, MessageVO, HeroePDFDTO>(null, null, null);
            try
            {
                tuplePDFMethod = HeroeImpl.PDF();
                if (!string.IsNullOrWhiteSpace(tuplePDFMethod.Item1))
                    heroeDownloadModel.Response = tuplePDFMethod.Item1;
                else if (tuplePDFMethod.Item2 != null)
                    heroeDownloadModel.MessageVO = tuplePDFMethod.Item2;

                if (!string.IsNullOrWhiteSpace(heroeDownloadModel.Response) || heroeDownloadModel.MessageVO != null)
                    return View("Download", heroeDownloadModel);
                else
                    return File(tuplePDFMethod.Item3.FileContent, "application/pdf", tuplePDFMethod.Item3.FileName);
            }
            catch (Exception ex)
            {
                heroeDownloadModel.Response = ex.GetOriginalException().Message;
                return View("Download", heroeDownloadModel);
            }
        }
    }
}