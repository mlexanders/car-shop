using System.Threading.Tasks;

namespace Test.Repository
{
    public class BaseCrudRepository<T> where T : class
    {
        private readonly AppDBContext dbContext;

        public BaseCrudRepository(AppDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await dbContext.AddAsync<T>(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> ReadAsync(int id)
        {
            return await dbContext.FindAsync<T>(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            dbContext.Remove<T>(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
