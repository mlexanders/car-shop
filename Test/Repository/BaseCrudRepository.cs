using System.Collections.Generic;
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

        public virtual async Task Create(T entity)
        {
            await dbContext.AddAsync<T>(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> Read(int id)
        {
            return await dbContext.FindAsync<T>(id);
        }

        public virtual async Task Update(T entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            dbContext.Remove<T>(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
