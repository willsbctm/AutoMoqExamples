using AutoMoqExamples.Web.Models;
using System.Web.Mvc;

namespace AutoMoqExamples.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository carRepository;

        public HomeController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Home.";

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult CreateCar()
        {
            var car = carRepository.Criar();
            return Json(car);
        }
    }
}