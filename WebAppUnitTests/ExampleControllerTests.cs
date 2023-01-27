using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using System.Web.Mvc;
using WebApp.Models;

namespace WebAppUnitTests
{
    [TestClass]
    public class ExampleControllerTests
    {
        #region Insert

        /// <summary>
        /// Verificar que el metodo Example/Insert funciona correctamente
        /// </summary>
        [TestMethod]
        public void ExampleControllerInsertMethodIsCorrect()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult insertMethod = exampleController.Insert() as ViewResult;
            Assert.IsNull(insertMethod.Model);
            exampleController.Dispose();
        }

        #endregion

        #region Update

        /// <summary>
        /// Verificar que el metodo Example/Update funciona segun lo necesitado al enviar sin parametros
        /// </summary>
        [TestMethod]
        public void ExampleControllerUpdateMethodWithoutParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult updateMethod = exampleController.Update() as ViewResult;
            ExampleUpdateModel exampleUpdateModel = updateMethod.Model as ExampleUpdateModel;
            Assert.IsNotNull(exampleUpdateModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Update funciona segun lo necesitado al enviar el parametro nulo
        /// </summary>
        [TestMethod]
        public void ExampleControllerUpdateMethodIsNullParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult updateMethod = exampleController.Update(null) as ViewResult;
            ExampleUpdateModel exampleUpdateModel = updateMethod.Model as ExampleUpdateModel;
            Assert.IsNotNull(exampleUpdateModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Update funciona segun lo necesitado al enviar el parametro invalido
        /// </summary>
        [TestMethod]
        public void ExampleControllerUpdateMethodIsInvalidParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult updateMethod = exampleController.Update(-1) as ViewResult;
            ExampleUpdateModel exampleUpdateModel = updateMethod.Model as ExampleUpdateModel;
            Assert.IsNotNull(exampleUpdateModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Update funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad no existe
        /// </summary>
        [TestMethod]
        public void ExampleControllerUpdateMethodIsNotExist()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult updateMethod = exampleController.Update(100) as ViewResult;
            ExampleUpdateModel exampleUpdateModel = updateMethod.Model as ExampleUpdateModel;
            Assert.IsNull(exampleUpdateModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Update funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad existe
        /// </summary>
        [TestMethod]
        public void ExampleControllerUpdateMethodIsCorrect()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult updateMethod = exampleController.Update(1) as ViewResult;
            ExampleUpdateModel exampleUpdateModel = updateMethod.Model as ExampleUpdateModel;
            Assert.IsNotNull(exampleUpdateModel.Example);
            exampleController.Dispose();
        }

        #endregion

        #region Delete

        /// <summary>
        /// Verificar que el metodo Example/Delete funciona segun lo necesitado al enviar sin parametros
        /// </summary>
        [TestMethod]
        public void ExampleControllerDeleteMethodWithoutParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult deleteMethod = exampleController.Delete() as ViewResult;
            ExampleDeleteModel exampleDeleteModel = deleteMethod.Model as ExampleDeleteModel;
            Assert.IsNotNull(exampleDeleteModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Delete funciona segun lo necesitado al enviar el parametro nulo
        /// </summary>
        [TestMethod]
        public void ExampleControllerDeleteMethodIsNullParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult deleteMethod = exampleController.Delete(null) as ViewResult;
            ExampleDeleteModel exampleDeleteModel = deleteMethod.Model as ExampleDeleteModel;
            Assert.IsNotNull(exampleDeleteModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Delete funciona segun lo necesitado al enviar el parametro invalido
        /// </summary>
        [TestMethod]
        public void ExampleControllerDeleteMethodIsInvalidParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult deleteMethod = exampleController.Delete(-1) as ViewResult;
            ExampleDeleteModel exampleDeleteModel = deleteMethod.Model as ExampleDeleteModel;
            Assert.IsNotNull(exampleDeleteModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Delete funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad no existe y no se elimina
        /// </summary>
        [TestMethod]
        public void ExampleControllerDeleteMethodIsNotExist()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult deleteMethod = exampleController.Delete(100) as ViewResult;
            ExampleDeleteModel exampleDeleteModel = deleteMethod.Model as ExampleDeleteModel;
            Assert.IsFalse(exampleDeleteModel.Delete.Value);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/Delete funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad existe y se elimina
        /// </summary>
        [TestMethod]
        public void ExampleControllerDeleteMethodIsCorrect()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult deleteMethod = exampleController.Delete(1) as ViewResult;
            ExampleDeleteModel exampleDeleteModel = deleteMethod.Model as ExampleDeleteModel;
            Assert.IsTrue(exampleDeleteModel.Delete.Value);
            exampleController.Dispose();
        }

        #endregion

        #region List

        /// <summary>
        /// Verificar que el metodo Example/List funciona segun lo necesitado al enviar sin parametros
        /// </summary>
        [TestMethod]
        public void ExampleControllerListMethodWithoutParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult listMethod = exampleController.List() as ViewResult;
            ExampleListModel exampleListModel = listMethod.Model as ExampleListModel;
            Assert.AreNotEqual(exampleListModel.Example.Count, 0);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/List funciona segun lo necesitado al enviar el objeto nulo
        /// </summary>
        [TestMethod]
        public void ExampleControllerListMethodIsNullObject()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult listMethod = exampleController.List(null) as ViewResult;
            ExampleListModel exampleListModel = listMethod.Model as ExampleListModel;
            Assert.IsNotNull(exampleListModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/List funciona segun lo necesitado al enviar el objeto con parametros invalidos
        /// </summary>
        [TestMethod]
        public void ExampleControllerListMethodIsInvalidParametersOfObject()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult listMethod = exampleController.List(-1) as ViewResult;
            ExampleListModel exampleListModel = listMethod.Model as ExampleListModel;
            Assert.IsNotNull(exampleListModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/List funciona segun lo necesitado al enviar el objeto con parametros correctos
        /// </summary>
        [TestMethod]
        public void ExampleControllerListMethodIsCorrect()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult listMethod = exampleController.List(1) as ViewResult;
            ExampleListModel exampleListModel = listMethod.Model as ExampleListModel;
            Assert.AreNotEqual(exampleListModel.Example.Count, 0);
            exampleController.Dispose();
        }

        #endregion

        #region ConfirmFormExample

        /// <summary>
        /// Verificar que el metodo Example/ConfirmFormExample funciona segun lo necesitado al enviar el objeto con parametros vacios
        /// </summary>
        [TestMethod]
        public void ExampleControllerConfirmFormExampleMethodIsEmptyParametersOfObject()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult confirmFormExampleMethod = exampleController.ConfirmFormExample(id: 0, inputRut: string.Empty, inputName: string.Empty, inputLastName: string.Empty, inputBirthDate: string.Empty, inputActiveRadioOptions: string.Empty, inputPassword: string.Empty) as ViewResult;
            ExampleConfirmModel exampleConfirmModel = confirmFormExampleMethod.Model as ExampleConfirmModel;
            Assert.IsNotNull(exampleConfirmModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/ConfirmFormExample funciona segun lo necesitado al enviar el objeto con con parametros invalidos
        /// </summary>
        [TestMethod]
        public void ExampleControllerConfirmFormExampleMethodIsInvalidParameter()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult confirmFormExampleMethod = exampleController.ConfirmFormExample(id: -1, inputRut: "1234567890123", inputName: "Test Test Test Test Test Test Test Test Test Test", inputLastName: "Test Test Test Test Test Test Test Test Test Test", inputBirthDate: DateTimeOffset.Now.AddDays(1).ToString("yyyy-MM-dd"), inputActiveRadioOptions: "123", inputPassword: "1234512345asdfgasdfg") as ViewResult;
            ExampleConfirmModel exampleConfirmModel = confirmFormExampleMethod.Model as ExampleConfirmModel;
            Assert.IsNotNull(exampleConfirmModel.MessageVO);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/ConfirmFormExample funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad se inserta
        /// </summary>
        [TestMethod]
        public void ExampleControllerConfirmFormExampleMethodIsValidInsert()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult confirmFormExampleMethod = exampleController.ConfirmFormExample(id: 0, inputRut: "76-0", inputName: "Emanuel", inputLastName: "Leiva", inputBirthDate: DateTimeOffset.Now.AddYears(-18).AddMonths(-5).AddDays(12).ToString("yyyy-MM-dd"), inputActiveRadioOptions: "yes", inputPassword: "12345678") as ViewResult;
            ExampleConfirmModel exampleConfirmModel = confirmFormExampleMethod.Model as ExampleConfirmModel;
            Assert.IsNotNull(exampleConfirmModel.Example);
            exampleController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Example/ConfirmFormExample funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad se actualiza
        /// </summary>
        [TestMethod]
        public void ExampleControllerConfirmFormExampleMethodIsValidUpdate()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult confirmFormExampleMethod = exampleController.ConfirmFormExample(id: 2, inputRut: "2-7", inputName: "Jose", inputLastName: "Gonazalez", inputBirthDate: DateTimeOffset.Now.AddYears(-20).AddMonths(-2).AddDays(-4).ToString("yyyy-MM-dd"), inputActiveRadioOptions: "yes", inputPassword: "5678tyui") as ViewResult;
            ExampleConfirmModel exampleConfirmModel = confirmFormExampleMethod.Model as ExampleConfirmModel;
            Assert.IsTrue(exampleConfirmModel.Updated.Value);
            exampleController.Dispose();
        }

        #endregion

        #region Download

        /// <summary>
        /// Verificar que el metodo Example/Download funciona correctamente
        /// </summary>
        [TestMethod]
        public void ExampleControllerDownloadMethodIsCorrect()
        {
            ExampleController exampleController = new ExampleController();
            ViewResult downloadMethod = exampleController.Download(null) as ViewResult;
            ExampleDownloadModel exampleDownloadModel = downloadMethod.Model as ExampleDownloadModel;
            Assert.IsNull(exampleDownloadModel);
            exampleController.Dispose();
        }

        #endregion

        #region DownloadExcel

        /// <summary>
        /// Verificar que el metodo Example/DownloadExcel funciona correctamente
        /// </summary>
        [TestMethod]
        public void ExampleControllerDownloadExcelMethodIsCorrect()
        {
            ExampleController exampleController = new ExampleController();
            FileContentResult downloadExcelMethod = exampleController.DownloadExcel() as FileContentResult;
            Assert.IsNotNull(downloadExcelMethod.FileContents);
            exampleController.Dispose();
        }

        #endregion

        #region DownloadPDF

        /// <summary>
        /// Verificar que el metodo Example/DownloadPDF funciona correctamente
        /// </summary>
        [TestMethod]
        public void ExampleControllerDownloadPDFMethodIsCorrect()
        {
            ExampleController exampleController = new ExampleController();
            FileContentResult downloadPDFMethod = exampleController.DownloadPDF() as FileContentResult;
            Assert.IsNotNull(downloadPDFMethod.FileContents);
            exampleController.Dispose();
        }

        #endregion
    }
}
