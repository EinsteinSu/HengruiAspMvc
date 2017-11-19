using System.Web.Mvc;
using Hengrui.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HengruiTest.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Welcome to DevExpress Extensions for ASP.NET MVC!", result.ViewBag.Message);
        }
    }
}