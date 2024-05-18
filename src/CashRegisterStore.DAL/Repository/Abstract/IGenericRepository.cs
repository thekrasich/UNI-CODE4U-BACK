namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task<T> GetByKey(params object[] keyValues);
        Task<List<T?>> GetAll();
        Task Update(T entity);
        Task DeleteByKey(params object[] keyValues);
        Task SaveAsync();

    }
}
