using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task UpdateName(Category category);
    }
}
