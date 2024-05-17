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
    public class SubcategoryRepository:GenericRepository<Subcategory>,ISubcategoryRepository
    {
        public SubcategoryRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdateSubcategory(Subcategory subcategory)
        {
            var currentSubcategory = await _dbContext.Subcategories.FindAsync(subcategory.Id);
            currentSubcategory.CategoryId = subcategory.CategoryId;
            currentSubcategory.Name = subcategory.Name;
            _dbContext.Entry(currentSubcategory).Property(x => x.CategoryId).IsModified = true;
            _dbContext.Entry(currentSubcategory).Property(x => x.Name).IsModified = true;
            await SaveAsync();
        }
    }
}
