using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }

        public string currentCategory { get; set; }
    }
}
