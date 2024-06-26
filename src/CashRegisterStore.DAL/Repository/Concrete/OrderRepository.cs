﻿using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdateStatus(Order order)
        {
            var currentOrder = await _dbContext.Orders.FindAsync(order.Id);
            currentOrder.Status= order.Status;
            _dbContext.Entry(currentOrder).Property(x => x.Status).IsModified = true;
            await SaveAsync();
        }
    }
}
