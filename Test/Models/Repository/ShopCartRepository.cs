namespace Test.Models.Repository
{
    public class ShopCartRepository : IShopCart
    {
        private readonly AppDBContext _dbContext;

        public ShopCartRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void DeleteCartItem(int id)
        {
            var deleteItem =_dbContext.ShopCartItems.Find(id);
            _dbContext.ShopCartItems.Remove(deleteItem);
            _dbContext.SaveChanges();
        }
    }
}
