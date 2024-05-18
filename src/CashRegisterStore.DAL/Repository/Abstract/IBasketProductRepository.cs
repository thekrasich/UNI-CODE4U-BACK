using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IBasketProductRepository : IGenericRepository<BasketProduct>
    {
        Task UpdateQuantity(BasketProduct basketProduct);
    }

    
}
