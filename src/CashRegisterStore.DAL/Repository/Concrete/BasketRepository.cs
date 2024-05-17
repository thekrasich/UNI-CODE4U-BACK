using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class BasketRepository:GenericRepository<Basket>,IBasketRepository
    {
        public BasketRepository(CashRegisterStoreDbContext _dbContext):base(_dbContext)
        {
            
        }
    }
}
