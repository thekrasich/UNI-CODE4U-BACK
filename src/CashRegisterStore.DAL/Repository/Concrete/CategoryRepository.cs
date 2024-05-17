using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdateName(Category category)
        {
            var currentCategory = await _dbContext.Categories.FindAsync(category.Id);
            currentCategory.Name = category.Name;
            _dbContext.Entry(currentCategory).Property(x => x.Name).IsModified = true;
            await SaveAsync();
        }
    }
    
}
