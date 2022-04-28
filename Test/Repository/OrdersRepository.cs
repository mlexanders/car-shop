using System;
using Test.Models;

namespace Test.Repository
{
    public class OrdersRepository
    {
        private readonly AppDBContext dbContext;
        private readonly ShopCartRepositore shopCart;

        public OrdersRepository(AppDBContext dBContext, ShopCartRepositore shopCart)
        {
            this.dbContext = dBContext;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            dbContext.Orders.Add(order);

            var items = shopCart.ListShopCarItem;

            foreach (var element in items)
            {
                var orderDetail = new OrderDatail
                {
                    CarId = element.Car.Id,
                    OrderId = order.Id,
                    Price = element.Car.Price,
                    Car = element.Car,
                    Order = order
                };
                dbContext.Remove(element);
                dbContext.OrderDatails.Add(orderDetail);
            }
            dbContext.SaveChanges();
        }
    }
}
