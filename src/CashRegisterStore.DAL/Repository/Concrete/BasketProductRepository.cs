using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class BasketProductRepository:GenericRepository<BasketProduct>,IBasketProductRepository
   {
        public BasketProductRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdateQuantity(BasketProduct basketProduct)
        {
            var currentBasketProduct = await _dbContext.BasketProducts.FindAsync(basketProduct.BasketId, basketProduct.ProductId);
            currentBasketProduct.Quantity= basketProduct.Quantity;
            _dbContext.Entry(currentBasketProduct).Property(x => x.Quantity).IsModified = true;
            await SaveAsync();
        }
        

    }
}
