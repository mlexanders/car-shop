using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Models
{
    public class ShopCart
    {
        private readonly AppDBContext _dbContext;

        public ShopCart(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopCarItem { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCarId);

            return new ShopCart(context) { ShopCartId = shopCarId };
        }
        public void AddToCart(Car car)
        {
            _dbContext.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            _dbContext.SaveChanges();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return _dbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
