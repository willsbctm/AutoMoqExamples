using AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutoMoqExamples.Tests
{
    [TestClass]
    public class CriacaoDeClassesComSuasDependencias
    {
        [TestMethod]
        public void AoInstanciarClasseConcretaDeveCriarMockDeSuasDependencias()
        {
            var mocker = new AutoMoqer();

            var carRepository = mocker.Create<CarRepository>();

            carRepository.Should().NotBeNull();
            carRepository.GetWheelRepository().Should().NotBeNull();
        }

        [TestMethod]
        public void DeveInserirComportamentoNasDependenciasDaClasseConcreta()
        {
            var mocker = new AutoMoqer();

            // Pode ser antes ou depois do create =)
            mocker.GetMock<IWheelRepository>().Setup(x => x.Criar(true)).Returns(new { RodasDeLigaLeve = true });

            var carRepository = mocker.Create<CarRepository>();

            var carro = carRepository.Criar(true);

            carro.ShouldBeEquivalentTo(new { RodasDeLigaLeve = true });

            mocker.GetMock<IWheelRepository>().Verify(x => x.Criar(true), Times.Once());
        }

        [TestMethod]
        public void DeveTrocarImplementacaoDaDependenciaDaClasseConcreta()
        {
            var mocker = new AutoMoqer();

            var customWheelRepository = mocker.Create<CustomWheelRepository>();
            mocker.SetInstance<IWheelRepository>(customWheelRepository);

            var carRepository = mocker.Create<CarRepository>();

            var carro = carRepository.Criar();

            carro.ShouldBeEquivalentTo(new { Personalizada = true });
        }
    }
}
