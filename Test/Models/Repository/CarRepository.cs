using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Test.Models.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContext _dbContext;

        public CarRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public IEnumerable<Car> Cars
        {
            get
            {
                return _dbContext.Cars.Include(c => c.Category);
            }
        }

        public IEnumerable<Car> GetFavCars
        {
            get
            {
                return _dbContext.Cars.Where(c => c.IsFavourite).Include(c => c.Category);
            }
        }

        public Car GetCar(int carId)
        {
            return _dbContext.Cars.FirstOrDefault(p => p.Id == carId);
        }
    }
}
