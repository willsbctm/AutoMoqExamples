using AutoMoqExamples.Web.Models;
using System.Web.Mvc;

namespace AutoMoqExamples.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly CarRepository carRepository;

        public CarController(CarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
    }
}