using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Repository;
using Test.ViewModels;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarRepository carRepository;

        public HomeController(CarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        [Route("~/")]
        public async Task<ViewResult> Index()
        {
            var homeCars = new HomeViewModel
            {
                favoriteCars = await carRepository.GetFavoriteCars()
            };
            return View(homeCars);
        }
    }
}
