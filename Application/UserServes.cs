using Domain;
using Infrastructure;
using Microsoft.VisualBasic;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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

        public async Task <DeleteResult> UserDeleteFromRepositoryAsync(string name)
        {
            var deletedUser = await _userRepository.GetUserAsync(u => u.Name == name);
            if (deletedUser != null)
            {
                await _userRepository.DeleteUserAsync(deletedUser);
                return new DeleteResult { Message = "Пользователь успешно удален" };
            }

            return new DeleteResult { Message = "Пользователь не существует" };
        }

        public class DeleteResult
        {
            public User DeletedUser { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
        }


    }
    
}
