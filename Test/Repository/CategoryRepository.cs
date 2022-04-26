using Test.Models;

namespace Test.Repository
{
    public class CategoryRepository : BaseCrudRepository<Category>
    {
        public CategoryRepository(AppDBContext dBContext) : base(dBContext)
        {
        }
    }
}