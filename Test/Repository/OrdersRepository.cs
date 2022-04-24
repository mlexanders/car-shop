using System;
using Test.Models;
using Test.RepoInterfaces;

namespace Test.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContext _dbContext;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDBContext dBContext, ShopCart shopCart)
        {
            _dbContext = dBContext;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _dbContext.Orders.Add(order);

            var items = _shopCart.listShopCarItem;

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
                _dbContext.Remove(element);
                _dbContext.OrderDatails.Add(orderDetail);
            }
            _dbContext.SaveChanges();
        }
    }
}
