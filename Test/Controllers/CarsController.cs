using Microsoft.AspNetCore.Mvc;
using System;
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
            string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = null;
            if (string.IsNullOrEmpty(category))
            {
                cars = (await allCars.Read()).OrderBy(car => car.Id);
            }
            else if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = (await allCars.Read()).Where(car => car.Category.CategoryName.Equals("Электромобиль")).OrderBy(i => i.Id);
                currentCategory = "Электромобили";
            }
            else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = (await allCars.Read()).Where(car => car.Category.CategoryName.Equals("Классический автомобиль")).OrderBy(i => i.Id);
                currentCategory = "Классические автомобили";
            }

            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                currentCategory = currentCategory
            };
            ViewBag.Title = "Страница с автомобилями";
            return View(carObj);
        }
    }
}
