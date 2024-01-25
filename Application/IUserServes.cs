using Domain;
using System.Linq.Expressions;
using WebApplication3.Domain;
using static Application.UserServes;

namespace Application
{
    public interface IUserServes
    {
        Task<User> UserCreatAsync(string name, string email);
        Task UserDeleteFromRepositoryAsync(string name);
        Task<Note> NoteCreatAsync(string header, string text, Guid ID);
        
    }
}