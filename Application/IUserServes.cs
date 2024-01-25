using Domain;
using System.Linq.Expressions;

namespace Application
{
    public interface IUserServes
    {
        Task<User> UserCreatAsync(string name, string email);
        Task<User> UserDeleteFromRepositoryAsync(string name);
       

    }
}