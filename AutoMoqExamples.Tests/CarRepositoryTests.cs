using AutoMoq;
using AutoMoqExamples.Web.Controllers;
using FluentAssertions;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoMoqExamples.Tests
{
    [TestClass]
    public class CarRepositoryTests
    {
        [TestMethod]
        public void DeveLancarErroAoInstanciarUmaClasseComDependenciaConcretaQueContemDependencias()
        {
            var mocker = new AutoMoqer();

            Action acao = () => mocker.Create<CarController>();

            acao.ShouldThrow<ResolutionFailedException>();
        }
    }
}
