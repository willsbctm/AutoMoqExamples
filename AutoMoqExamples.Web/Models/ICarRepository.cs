namespace AutoMoqExamples.Web.Models
{
    public interface ICarRepository
    {
        object Criar(bool rodasDeLigaLeve = false);
    }
}