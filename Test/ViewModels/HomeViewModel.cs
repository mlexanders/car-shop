using System.Collections.Generic;
using Test.Models;

namespace Test.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
