using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Repository;
using Test.ViewModels;

namespace Test.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly CarRepository carRepository;
        private readonly ShopCartRepositore shopCartRepositore;

        public ShopCartController(CarRepository carRepository, ShopCartRepositore shopCartRepositore)
        {
            this.carRepository = carRepository;
            this.shopCartRepositore = shopCartRepositore;
        }

        [Route("~/ShopCart/Index")]
        public ViewResult Index()
        {
            var items = shopCartRepositore.GetShopItems();
            shopCartRepositore.ListShopCarItem = items;

            var obj = new ShopCartViewModel
            {
                ListShopCarItem = shopCartRepositore.ListShopCarItem
            };

            return View(obj);
        }

        [Route("~/ShopCart/AddToCart")]
        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await carRepository.ReadAsync(id);
            if (item != null)
            {
                shopCartRepositore.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

        [Route("~/ShopCart/DeleteCartItem/{id}")]
        public RedirectToActionResult DelitCartItem(int id)
        {
            shopCartRepositore.DeleteCartItem(id);

            return RedirectToAction("Index");
        }
    }
}
