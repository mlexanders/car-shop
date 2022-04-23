using System.Collections.Generic;
using Test.Models;

namespace Test.RepoInterfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavCars { get; }
        Car GetCar(int carId);
    }
}
