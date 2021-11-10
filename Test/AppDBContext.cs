using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test
{
    public class AppDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDatail> OrderDatails { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
