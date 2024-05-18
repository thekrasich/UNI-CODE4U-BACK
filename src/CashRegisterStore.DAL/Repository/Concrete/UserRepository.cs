﻿using CashRegisterStore.DAL.Data;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.Repository.Abstract;

namespace CashRegisterStore.DAL.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CashRegisterStoreDbContext _dbContext) : base(_dbContext)
        {
            
        }
        public async Task UpdateUser(User user)
        {
            var currentUser = await _dbContext.Users.FindAsync(user.Id);

            currentUser.Name = user.Name;
            currentUser.Surname = user.Surname;
            //currentUser.PhoneNumber= user.PhoneNumber;
            //currentUser.Email = user.Email;
            //currentUser.Password = user.Password;
            currentUser.Role= user.Role;

            _dbContext.Entry(currentUser).Property(x => x.Name).IsModified = true;
            _dbContext.Entry(currentUser).Property(x => x.Surname).IsModified = true;
           /* _dbContext.Entry(currentUser).Property(x => x.PhoneNumber).IsModified = true;
            _dbContext.Entry(currentUser).Property(x => x.Email).IsModified = true;*/
            //_dbContext.Entry(currentUser).Property(x => x.Password).IsModified = true;
            _dbContext.Entry(currentUser).Property(x => x.Role).IsModified = true;
            await SaveAsync();
        }
    }
}
