using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarCategory _carCategory;

        public CarsController(IAllCars allCars, ICarCategory carCategory)
        {
            _allCars = allCars;
            _carCategory = carCategory;
        }

        //[Route("~/Cars/List")]
        [Route("~/Cars/List/{category?}")]
        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = null;
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобиль")).OrderBy(i => i.id);
                currentCategory = "Электромобили";
            }
            else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классический автомобиль")).OrderBy(i => i.id);
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
