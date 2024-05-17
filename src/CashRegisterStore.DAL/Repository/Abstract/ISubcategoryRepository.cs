using CashRegisterStore.DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface ISubcategoryRepository : IGenericRepository<Subcategory>
    {
        Task UpdateSubcategory(Subcategory subcategory);
    }
}
