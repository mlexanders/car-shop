using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Models;

namespace Test.Repository
{
    public class ShopCartRepositore
    {
        private readonly AppDBContext dbContext;
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopCarItem { get; set; }

        public ShopCartRepositore(AppDBContext appDBContext)
        {
            dbContext = appDBContext;
        }


        public static ShopCartRepositore GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCarId);

            return new ShopCartRepositore(context) { ShopCartId = shopCarId };
        }

        public void AddToCart(Car car)
        {
            dbContext.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            dbContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return dbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }

        public void DeleteCartItem(int id)
        {
            var deleteItem = dbContext.ShopCartItems.Find(id);
            dbContext.ShopCartItems.Remove(deleteItem);
            dbContext.SaveChanges();
        }
    }
}
