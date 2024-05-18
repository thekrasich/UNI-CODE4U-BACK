using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct>
    {
        Task UpdateQuantity(OrderProduct orderProduct);
    }
}
