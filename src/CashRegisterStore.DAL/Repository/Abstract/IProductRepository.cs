using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task UpdateProduct(Product product);
    }
}
