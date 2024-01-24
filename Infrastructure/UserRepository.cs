using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
