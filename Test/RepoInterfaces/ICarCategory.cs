using System.Collections.Generic;
using Test.Models;

namespace Test.RepoInterfaces
{
    public interface ICarCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
