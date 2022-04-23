using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.RepoInterfaces;
using Test.ViewModels;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRepository;

        public HomeController(IAllCars carRepository)
        {
            _carRepository = carRepository;
        }

        [Route("~/")]
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRepository.GetFavCars
            };
            return View(homeCars);
        }
    }
}
