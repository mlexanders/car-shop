namespace Test.Repository
{
    public class ShopCartRepository
    {
        private readonly AppDBContext dbContext;

        public ShopCartRepository(AppDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public void DeleteCartItem(int id)
        {
            var deleteItem = dbContext.ShopCartItems.Find(id);
            dbContext.ShopCartItems.Remove(deleteItem);
            dbContext.SaveChanges();
        }
    }
}
