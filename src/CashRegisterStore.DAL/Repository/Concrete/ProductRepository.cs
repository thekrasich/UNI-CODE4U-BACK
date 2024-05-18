using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class ProductRepository: GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdateProduct(Product product)
        {
            var currentProduct = await _dbContext.Products.FindAsync(product.Id);
            
            currentProduct.Name = product.Name;
            currentProduct.Description = product.Description;
            currentProduct.Price = product.Price;
            currentProduct.SubcategoryId = product.SubcategoryId;
            currentProduct.AvailableCount = product.AvailableCount;
            
            _dbContext.Entry(currentProduct).Property(x => x.Name).IsModified = true;
            _dbContext.Entry(currentProduct).Property(x => x.Description).IsModified = true;
            _dbContext.Entry(currentProduct).Property(x => x.Price).IsModified = true;
            _dbContext.Entry(currentProduct).Property(x => x.SubcategoryId).IsModified = true;
            _dbContext.Entry(currentProduct).Property(x => x.AvailableCount).IsModified = true;
            await SaveAsync();
        }
    }
}
