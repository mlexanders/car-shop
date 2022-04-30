using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Repository;
using Test.ViewModels;

namespace Test.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRepository allCars;
        private readonly CategoryRepository carCategory;

        public CarsController(CarRepository allCars, CategoryRepository carCategory)
        {
            this.allCars = allCars;
            this.carCategory = carCategory;
        }

        [Route("~/Cars/List/{category?}")]
        public async Task<IActionResult> List(string category)
        {
            IEnumerable<Car> cars = null;
            string currentCategory = null;

            if (category == null)
            {
                cars = (await allCars.ReadAsync()).OrderBy(car => car.Id);
            }
            else if (string.Equals("electro", category))
            {
                cars = (await allCars.ReadAsync()).Where(car => car.Category.CategoryName.Equals("Электромобиль"));
                currentCategory = "Электромобили";
            }
            else if (string.Equals("fuel", category))
            {
                cars = (await allCars.ReadAsync()).Where(car => car.Category.CategoryName.Equals("Классический автомобиль"));
                currentCategory = "Классические автомобили";
            }

            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                CurrentCategory = currentCategory
            };
            ViewBag.Title = "Страница с автомобилями";
            return View(carObj);
        }
    }
}
