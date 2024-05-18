using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class PhotoRepository:GenericRepository<Photo>,IPhotoRepository
    {
        public PhotoRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdatePath(Photo photo)
        {
            var currentPhoto = await _dbContext.Photos.FindAsync(photo.Id);
            currentPhoto.Path = photo.Path;
            _dbContext.Entry(currentPhoto).Property(x => x.Path).IsModified = true;
            await SaveAsync();
        }
    }
}
