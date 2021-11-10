using Microsoft.EntityFrameworkCore;
using System;

namespace Test.Models.Repository
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
                    CarId = element.car.id,
                    OrderId = order.Id,
                    Price = element.car.price
                };
                _dbContext.OrderDatails.Add(orderDetail);
            }
            _dbContext.SaveChanges();
        }
    }
}
