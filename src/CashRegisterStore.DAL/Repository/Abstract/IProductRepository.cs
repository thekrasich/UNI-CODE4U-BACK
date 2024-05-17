using CashRegisterStore.DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterStore.DAL.Repository.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task UpdateProduct(Product product);
    }
}
