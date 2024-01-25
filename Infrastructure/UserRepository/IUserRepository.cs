using Domain;
using System.Linq.Expressions;

namespace Infrastructure.UserRepository
{
    public interface IUserRepository
    {
        Task AddUserInRepositoryAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserAsync(Expression<Func<User, bool>> predicate);
        
    }

}