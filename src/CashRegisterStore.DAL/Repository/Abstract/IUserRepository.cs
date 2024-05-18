using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UpdateUser(User user);
    }
}
