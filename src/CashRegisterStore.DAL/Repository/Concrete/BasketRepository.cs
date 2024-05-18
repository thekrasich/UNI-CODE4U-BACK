using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class BasketRepository:GenericRepository<Basket>,IBasketRepository
    {
        public BasketRepository(CashRegisterStoreDbContext _dbContext):base(_dbContext)
        {
            
        }
    }
}
