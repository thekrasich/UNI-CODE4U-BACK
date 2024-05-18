using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class OrderProductRepository:GenericRepository<OrderProduct>,IOrderProductRepository
    {
        public OrderProductRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdateQuantity(OrderProduct orderProduct)
        {
            var currentOrderProduct = await _dbContext.OrderProducts.FindAsync(orderProduct.OrderId, orderProduct.ProductId);
            currentOrderProduct.Quantity = orderProduct.Quantity;
            _dbContext.Entry(currentOrderProduct).Property(x => x.Quantity).IsModified = true;
            await SaveAsync();
        }
    }
}
