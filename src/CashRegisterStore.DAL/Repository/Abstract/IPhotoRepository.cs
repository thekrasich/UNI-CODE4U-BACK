using CashRegisterStore.DAL.Data.Entities;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IPhotoRepository : IGenericRepository<Photo>
    {
        Task UpdatePath(Photo photo);
    }
}
