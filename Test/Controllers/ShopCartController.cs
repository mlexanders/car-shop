using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Repository;
using Test.ViewModels;

namespace Test.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly CarRepository carRepository;
        private readonly ShopCart shopCart;
        private readonly ShopCartRepository shopCartDelete;

        public ShopCartController(CarRepository carRepository, ShopCart shopCart, ShopCartRepository shopCartDelete)
        {
            this.carRepository = carRepository;
            this.shopCart = shopCart;
            this.shopCartDelete = shopCartDelete;
        }

        [Route("~/ShopCart/Index")]
        public ViewResult Index()
        {
            var items = shopCart.GetShopItems();
            shopCart.ListShopCarItem = items;

            var obj = new ShopCartViewModel
            {
                shopCart = shopCart
            };

            return View(obj);
        }

        [Route("~/ShopCart/AddToCart")]
        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await carRepository.Read(id);
            if (item != null)
            {
                shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        [Route("~/ShopCart/DeleteCartItem/{id}")]
        public RedirectToActionResult DelitCartItem(int id)
        {
            shopCartDelete.DeleteCartItem(id);

            return RedirectToAction("Index");
        }
    }
}
