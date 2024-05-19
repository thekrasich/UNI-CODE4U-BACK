using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Photo>> GetPhotosByProductIdAsync(int productId)
        {
            return await _dbContext.Photos.Where(photo => photo.ProductId == productId).ToListAsync();
        }

    }
}
