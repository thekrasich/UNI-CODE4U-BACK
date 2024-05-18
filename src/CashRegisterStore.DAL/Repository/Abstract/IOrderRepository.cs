using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task UpdateStatus(Order order);
    }
}
