using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using System.Web.Mvc;
using WebApp.Models;
using System.Net;

namespace WebAppUnitTests
{
    [TestClass]
    public class CheckControllerTests
    {
        /// <summary>
        /// Verificar que el metodo Check/Check funciona correctamente
        /// </summary>
        [TestMethod]
        public void CheckControllerCheckMethodIsCorrect()
        {
            CheckController checkController = new CheckController();
            ViewResult checkMethod = checkController.Check() as ViewResult;
            CheckCheckModel checkCheckModel = checkMethod.Model as CheckCheckModel;
            Assert.IsNotNull(checkCheckModel);
            Assert.AreEqual(HttpStatusCode.OK, checkCheckModel.HttpStatusCode);
            checkController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Check/OpenAPICSharpCheck funciona correctamente
        /// </summary>
        [TestMethod]
        public void CheckControllerOpenAPICSharpCheckMethodIsCorrect()
        {
            CheckController checkController = new CheckController();
            ViewResult openAPICSharpCheckMethod = checkController.OpenAPICSharpCheck() as ViewResult;
            CheckOpenAPICSharpCheck checkOpenAPICSharpCheckModel = openAPICSharpCheckMethod.Model as CheckOpenAPICSharpCheck;
            Assert.IsNotNull(checkOpenAPICSharpCheckModel);
            Assert.IsNotNull(checkOpenAPICSharpCheckModel.MessageVOOk);
            checkController.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Check/OpenAPICSharpCheckAuth funciona correctamente
        /// </summary>
        [TestMethod]
        public void CheckControllerOpenAPICSharpCheckAuthMethodIsCorrect()
        {
            CheckController checkController = new CheckController();
            ViewResult openAPICSharpCheckAuthMethod = checkController.OpenAPICSharpCheckAuth() as ViewResult;
            CheckOpenAPICSharpCheckAuth checkOpenAPICSharpCheckAuthModel = openAPICSharpCheckAuthMethod.Model as CheckOpenAPICSharpCheckAuth;
            Assert.IsNotNull(checkOpenAPICSharpCheckAuthModel);
            Assert.IsNotNull(checkOpenAPICSharpCheckAuthModel.MessageVOOk);
            checkController.Dispose();
        }
    }
}
