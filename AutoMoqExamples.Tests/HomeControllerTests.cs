using AutoMoq;
using AutoMoqExamples.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FluentAssertions;
using AutoMoqExamples.Web.Models;

namespace AutoMoqExamples.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void DeveInstanciarController()
        {
            var mocker = new AutoMoqer();
            var homeController = mocker.Create<HomeController>();
            var viewResult = homeController.Index() as ViewResult;

            viewResult.ViewName.Should().Be("Index");

            var message = (string)viewResult.ViewBag.Message;
            message.Should().Be("Home.");
        }

        [TestMethod]
        public void DeveconfigurarComportamentoDasDependenciasDaController()
        {
            var mocker = new AutoMoqer();
            var homeController = mocker.Create<HomeController>();

            mocker.GetMock<ICarRepository>()
                .Setup(s => s.Criar(false))
                .Returns(new { RodasDeLigaLeve = false });

            var jsonResult = homeController.CreateCar() as JsonResult;

            jsonResult.Data.Should().Be(new { RodasDeLigaLeve = false });
        }
    }
}
