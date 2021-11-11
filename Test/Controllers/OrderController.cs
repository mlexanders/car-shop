using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            _allOrders = allOrders;
            _shopCart = shopCart;
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
            _shopCart.listShopCarItem = _shopCart.GetShopItems();

            if (_shopCart.listShopCarItem.Count == 0)
            {
                ModelState.AddModelError("Email", "У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
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
