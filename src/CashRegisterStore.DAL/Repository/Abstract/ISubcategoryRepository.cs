using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface ISubcategoryRepository : IGenericRepository<Subcategory>
    {
        Task UpdateSubcategory(Subcategory subcategory);
    }
}
