using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly Database _database;
        public UserRepository(Database a)
        {
            _database = a; 
        }

        public async Task AddUserAsync(User user)
        {
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();

        }
        public async Task DeleteUserAsync(User user) 
        {
           
             _database.Users.Remove(user);
            await _database.SaveChangesAsync();
                
                
        }
        public async Task<User> GetUserAsync(Expression<Func<User, bool>> predicate)
        {
            // Реализация получения пользователя по предикату
            return await _database.Users.FirstOrDefaultAsync(predicate);
        }
    }
}
