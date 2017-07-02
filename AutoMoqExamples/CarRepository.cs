namespace AutoMoqExamples
{
    public class CarRepository
    {
        private readonly IWheelRepository wheelRepository;
        public CarRepository(IWheelRepository wheelRepository)
        {
            this.wheelRepository = wheelRepository;
        }

        public IWheelRepository GetWheelRepository()
        {
            return wheelRepository;
        }

        public object Criar(bool rodasDeLigaLeve = false)
        {
            var rodas = wheelRepository.Criar(rodasDeLigaLeve);

            return rodas;
        }
    }
}
