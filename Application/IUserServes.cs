using Domain;
using System.Linq.Expressions;
using static Application.UserServes;

namespace Application
{
    public interface IUserServes
    {
        Task<User> UserCreatAsync(string name, string email);
        Task<DeleteResult> UserDeleteFromRepositoryAsync(string name);
       

    }
}