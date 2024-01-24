using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UserServes : IUserServes
    {
        private readonly IUserRepository _userRepository;

        public UserServes(IUserRepository a)
        {
            _userRepository = a;

        }
        public async Task<User> UserCreatAsync(string name, string email)
        {

            var newUser = new User
            {
                Name = name,
                Email = email,
                ID = Guid.NewGuid(),
                Notes = []


            };
            await _userRepository.AddUserAsync(newUser);
            return newUser;


        }
    }
}
