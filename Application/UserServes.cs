using Domain;
using Infrastructure.NoteRepository;
using Infrastructure.UserRepository;
using Microsoft.VisualBasic;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WebApplication3.Domain;

namespace Application
{
    public class UserServes : IUserServes
    {
        private readonly IUserRepository _userRepository;
        private readonly INoteRepository _noteRepository;
        public UserServes(IUserRepository a, INoteRepository b)
        {
            _userRepository = a;
            _noteRepository = b;
        }

        public async Task<User>  UserCreatAsync(string name, string email)
        {
            var newUser = new User
            {
                Name = name,
                Email = email,
                ID = Guid.NewGuid(),
                Notes = []
            };

            await _userRepository.AddUserInRepositoryAsync(newUser);

            return newUser;
        }

        public async Task UserDeleteFromRepositoryAsync(string name)
        {
            var deletedUser = await _userRepository.GetUserAsync(u => u.Name == name);

            if (deletedUser == null)
            {
                return;
            }

            await _userRepository.DeleteUserAsync(deletedUser);
        }

        public async Task<Note> NoteCreatAsync(string header, string text, Guid userID)
        {
            var user = await _userRepository.GetUserAsync(x => x.ID == userID);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            var newNote = new Note
            {
                ID = Guid.NewGuid(),
                Header = header,
                Text = text,
                Date = DateTime.Now,
                Status = false,
                UserID=userID
            };


            await _noteRepository.AddNoteInRepositoryAsync(newNote);
            return newNote;

        }
    }
    
}
