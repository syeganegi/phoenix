// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeControllerTest.cs" company="">
//   
// </copyright>
// <summary>
//   The home controller test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Tests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers;
    using Phoenix.PhoenixApp.Presentation.MVC.ServiceAgents.Services;

    /// <summary>
    /// The home controller test.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        #region Public Methods and Operators
        
        /// <summary>
        /// The index.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        #endregion
    }
}