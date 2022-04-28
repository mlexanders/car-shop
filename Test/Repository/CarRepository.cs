using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Repository
{
    public class CarRepository : BaseCrudRepository<Car>
    {
        AppDBContext dBContext;
        public CarRepository(AppDBContext dBContext) : base(dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IEnumerable<Car>> ReadAsync()
        {
            return await dBContext.Cars.Include(c => c.Category).ToListAsync();
        }

        public async Task<List<Car>> GetFavoriteCars()
        {
            return (await ReadAsync()).Where(c => c.IsFavourite).ToList();
        }
    }
}
