using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRepository = carRepository;
            _shopCart = shopCart;
        }

        [Route("~/ShopCart/Index")]
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopCarItem = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        [Route("~/ShopCart/AddToCart")]
        public RedirectToActionResult AddToCart(int id)
        {
            var item =_carRepository.Cars.FirstOrDefault(i=>i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
