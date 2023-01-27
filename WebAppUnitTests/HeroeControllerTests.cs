using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using System.Web.Mvc;
using WebApp.Models;
using Business.Tool;

namespace WebAppUnitTests
{
    [TestClass]
    public class HeroeControllerTests
    {
        #region Insert

        /// <summary>
        /// Verificar que el metodo Heroe/Insert funciona correctamente
        /// </summary>
        [TestMethod]
        public void HeroeControllerInsertMethodIsCorrect()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult insertMethod = heroeController.Insert() as ViewResult;
            Assert.IsNull(insertMethod.Model);
            heroeController.Dispose();
        }

        #endregion

        #region Update

        /// <summary>
        /// Verificar que el metodo Heroe/Update funciona segun lo necesitado al enviar sin parametros
        /// </summary>
        [TestMethod]
        public void HeroeControllerUpdateMethodWithoutParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult updateMethod = heroeController.Update() as ViewResult;
            HeroeUpdateModel heroeUpdateModel = updateMethod.Model as HeroeUpdateModel;
            Assert.IsNotNull(heroeUpdateModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Update funciona segun lo necesitado al enviar el parametro nulo
        /// </summary>
        [TestMethod]
        public void HeroeControllerUpdateMethodIsNullParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult updateMethod = heroeController.Update(null) as ViewResult;
            HeroeUpdateModel heroeUpdateModel = updateMethod.Model as HeroeUpdateModel;
            Assert.IsNotNull(heroeUpdateModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Update funciona segun lo necesitado al enviar el parametro invalido
        /// </summary>
        [TestMethod]
        public void HeroeControllerUpdateMethodIsInvalidParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult updateMethod = heroeController.Update(-1) as ViewResult;
            HeroeUpdateModel heroeUpdateModel = updateMethod.Model as HeroeUpdateModel;
            Assert.IsNotNull(heroeUpdateModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Update funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad no existe
        /// </summary>
        [TestMethod]
        public void HeroeControllerUpdateMethodIsNotExist()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult updateMethod = heroeController.Update(100) as ViewResult;
            HeroeUpdateModel heroeUpdateModel = updateMethod.Model as HeroeUpdateModel;
            Assert.IsNull(heroeUpdateModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Update funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad existe
        /// </summary>
        [TestMethod]
        public void HeroeControllerUpdateMethodIsCorrect()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult updateMethod = heroeController.Update(1) as ViewResult;
            HeroeUpdateModel heroeUpdateModel = updateMethod.Model as HeroeUpdateModel;
            Assert.IsNotNull(heroeUpdateModel.Heroe);
            heroeController.Dispose();
        }

        #endregion

        #region Delete

        /// <summary>
        /// Verificar que el metodo Heroe/Delete funciona segun lo necesitado al enviar sin parametros
        /// </summary>
        [TestMethod]
        public void HeroeControllerDeleteMethodWithoutParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult deleteMethod = heroeController.Delete() as ViewResult;
            HeroeDeleteModel heroeDeleteModel = deleteMethod.Model as HeroeDeleteModel;
            Assert.IsNotNull(heroeDeleteModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Delete funciona segun lo necesitado al enviar el parametro nulo
        /// </summary>
        [TestMethod]
        public void HeroeControllerDeleteMethodIsNullParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult deleteMethod = heroeController.Delete(null) as ViewResult;
            HeroeDeleteModel heroeDeleteModel = deleteMethod.Model as HeroeDeleteModel;
            Assert.IsNotNull(heroeDeleteModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Delete funciona segun lo necesitado al enviar el parametro invalido
        /// </summary>
        [TestMethod]
        public void HeroeControllerDeleteMethodIsInvalidParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult deleteMethod = heroeController.Delete(-1) as ViewResult;
            HeroeDeleteModel heroeDeleteModel = deleteMethod.Model as HeroeDeleteModel;
            Assert.IsNotNull(heroeDeleteModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Delete funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad no existe y no se elimina
        /// </summary>
        [TestMethod]
        public void HeroeControllerDeleteMethodIsNotExist()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult deleteMethod = heroeController.Delete(100) as ViewResult;
            HeroeDeleteModel heroeDeleteModel = deleteMethod.Model as HeroeDeleteModel;
            Assert.IsFalse(heroeDeleteModel.Delete.Value);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/Delete funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad existe y se elimina
        /// </summary>
        [TestMethod]
        public void HeroeControllerDeleteMethodIsCorrect()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult deleteMethod = heroeController.Delete(1) as ViewResult;
            HeroeDeleteModel heroeDeleteModel = deleteMethod.Model as HeroeDeleteModel;
            Assert.IsTrue(heroeDeleteModel.Delete.Value);
            heroeController.Dispose();
        }

        #endregion

        #region List

        /// <summary>
        /// Verificar que el metodo Heroe/List funciona segun lo necesitado al enviar sin parametros
        /// </summary>
        [TestMethod]
        public void HeroeControllerListMethodWithoutParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult listMethod = heroeController.List() as ViewResult;
            HeroeListModel heroeListModel = listMethod.Model as HeroeListModel;
            Assert.AreNotEqual(heroeListModel.Heroe.Count, 0);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/List funciona segun lo necesitado al enviar el objeto nulo
        /// </summary>
        [TestMethod]
        public void HeroeControllerListMethodIsNullObject()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult listMethod = heroeController.List(null) as ViewResult;
            HeroeListModel heroeListModel = listMethod.Model as HeroeListModel;
            Assert.IsNotNull(heroeListModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/List funciona segun lo necesitado al enviar el objeto con parametros invalidos
        /// </summary>
        [TestMethod]
        public void HeroeControllerListMethodIsInvalidParametersOfObject()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult listMethod = heroeController.List(-1) as ViewResult;
            HeroeListModel heroeListModel = listMethod.Model as HeroeListModel;
            Assert.IsNotNull(heroeListModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/List funciona segun lo necesitado al enviar el objeto con parametros correctos
        /// </summary>
        [TestMethod]
        public void HeroeControllerListMethodIsCorrect()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult listMethod = heroeController.List(1) as ViewResult;
            HeroeListModel heroeListModel = listMethod.Model as HeroeListModel;
            Assert.AreNotEqual(heroeListModel.Heroe.Count, 0);
            heroeController.Dispose();
        }

        #endregion

        #region ConfirmFormExample

        /// <summary>
        /// Verificar que el metodo Heroe/ConfirmFormHeroe funciona segun lo necesitado al enviar el objeto con parametros vacios
        /// </summary>
        [TestMethod]
        public void HeroeControllerConfirmFormHeroeMethodIsEmptyParametersOfObject()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult confirmFormHeroeMethod = heroeController.ConfirmFormHeroe(id: 0, inputName: string.Empty, inputHome: string.Empty, inputAppearance: string.Empty, inputDescription: string.Empty, inputImgBase64String: string.Empty) as ViewResult;
            HeroeConfirmModel heroeConfirmModel = confirmFormHeroeMethod.Model as HeroeConfirmModel;
            Assert.IsNotNull(heroeConfirmModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/ConfirmFormHeroe funciona segun lo necesitado al enviar el objeto con con parametros invalidos
        /// </summary>
        [TestMethod]
        public void HeroeControllerConfirmFormHeroeMethodIsInvalidParameter()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult confirmFormHeroeMethod = heroeController.ConfirmFormHeroe(id: -1, inputName: "Test Test Test Test Test Test Test Test Test Test", inputHome: "Test Test Test Test Test Test Test Test", inputAppearance: DateTimeOffset.Now.AddDays(1).ToString("yyyy-MM-dd"), 
                inputDescription: "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test "
                + "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test "
                + "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test ", inputImgBase64String: "1234asdf") as ViewResult;
            HeroeConfirmModel heroeConfirmModel = confirmFormHeroeMethod.Model as HeroeConfirmModel;
            Assert.IsNotNull(heroeConfirmModel.MessageVO);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/ConfirmFormHeroe funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad se inserta
        /// </summary>
        [TestMethod]
        public void HeroeControllerConfirmFormHeroeMethodIsValidInsert()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult confirmFormHeroeMethod = heroeController.ConfirmFormHeroe(id: 0, inputName: "Thor", inputHome: "Marvel", inputAppearance: new DateTimeOffset(new DateTime(1962, 8, 1)).ToString("yyyy-MM-dd"), inputDescription: "El personaje, que se basa en la deidad nórdica homónima, es el dios del trueno asgardiano poseedor del martillo encantado, Mjolnir, que le otorga capacidad de volar y manipular el clima entre sus otros atributos sobrehumanos, además de concentrar su poder.", inputImgBase64String: Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\web-64.png")) as ViewResult;
            HeroeConfirmModel heroeConfirmModel = confirmFormHeroeMethod.Model as HeroeConfirmModel;
            Assert.IsNotNull(heroeConfirmModel.Heroe);
            heroeController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Heroe/ConfirmFormHeroe funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad se actualiza
        /// </summary>
        [TestMethod]
        public void ExampleControllerConfirmFormExampleMethodIsValidUpdate()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult confirmFormHeroeMethod = heroeController.ConfirmFormHeroe(id: 2, inputName: "Batman", inputHome: "DC", inputAppearance: new DateTimeOffset(new DateTime(1939, 5, 1)).ToString("yyyy-MM-dd"), inputDescription: "Los rasgos principales de Batman se resumen en «destreza física, habilidades deductivas y obsesión». La mayor parte de las características básicas de los cómics han variado por las diferentes interpretaciones que le han dado al personaje.", inputImgBase64String: Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\web-64.png")) as ViewResult;
            HeroeConfirmModel heroeConfirmModel = confirmFormHeroeMethod.Model as HeroeConfirmModel;
            Assert.IsTrue(heroeConfirmModel.Updated.Value);
            heroeController.Dispose();
        }

        #endregion

        #region Download

        /// <summary>
        /// Verificar que el metodo Heroe/Download funciona correctamente
        /// </summary>
        [TestMethod]
        public void HeroeControllerDownloadMethodIsCorrect()
        {
            HeroeController heroeController = new HeroeController();
            ViewResult downloadMethod = heroeController.Download(null) as ViewResult;
            HeroeDownloadModel heroeDownloadModel = downloadMethod.Model as HeroeDownloadModel;
            Assert.IsNull(heroeDownloadModel);
            heroeController.Dispose();
        }

        #endregion

        #region DownloadExcel

        /// <summary>
        /// Verificar que el metodo Heroe/DownloadExcel funciona correctamente
        /// </summary>
        [TestMethod]
        public void HeroeControllerDownloadExcelMethodIsCorrect()
        {
            HeroeController heroeController = new HeroeController();
            FileContentResult downloadExcelMethod = heroeController.DownloadExcel() as FileContentResult;
            Assert.IsNotNull(downloadExcelMethod.FileContents);
            heroeController.Dispose();
        }

        #endregion

        #region DownloadPDF

        /// <summary>
        /// Verificar que el metodo Heroe/DownloadPDF funciona correctamente
        /// </summary>
        [TestMethod]
        public void HeroeControllerDownloadPDFMethodIsCorrect()
        {
            HeroeController heroeController = new HeroeController();
            FileContentResult downloadPDFMethod = heroeController.DownloadPDF() as FileContentResult;
            Assert.IsNotNull(downloadPDFMethod.FileContents);
            heroeController.Dispose();
        }

        #endregion
    }
}
