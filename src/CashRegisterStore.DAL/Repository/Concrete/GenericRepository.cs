using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;


namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CashRegisterStoreDbContext _dbContext;
        public GenericRepository(CashRegisterStoreDbContext context)
        {
            _dbContext = context;
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteByKey(params object[] keyValues)
        {
            var entityToDelete = await _dbContext.Set<T>().FindAsync(keyValues);

            if (entityToDelete != null)
            {
                _dbContext.Set<T>().Remove(entityToDelete);
                await SaveAsync();
            }
        }

        public async Task<List<T?>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByKey(params object[] keyValues)
        {
            return await _dbContext.Set<T>().FindAsync(keyValues);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await SaveAsync();
        }
    }
}
