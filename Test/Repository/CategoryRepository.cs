using System.Collections.Generic;
using Test.Models;
using Test.RepoInterfaces;

namespace Test.Repository
{
    public class CategoryRepository : ICarCategory
    {
        private readonly AppDBContext _dbContext;

        public CategoryRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public IEnumerable<Category> AllCategories => _dbContext.Categories;
    }
}
