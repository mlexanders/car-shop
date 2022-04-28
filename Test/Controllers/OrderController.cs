using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repository;

namespace Test.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrdersRepository allOrders;
        private readonly ShopCartRepositore shopCart;

        public OrderController(OrdersRepository allOrders, ShopCartRepositore shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        [Route("~/Order/CheckOut")]
        public IActionResult CheckOut()
        {
            return View();
        }

        [Route("~/Order/CheckOut")]
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.ListShopCarItem = shopCart.GetShopItems();

            if (shopCart.ListShopCarItem.Count == 0)
            {
                ModelState.AddModelError("Email", "У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        [Route("~/Order/Complete")]
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
