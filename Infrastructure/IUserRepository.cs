using Domain;
using System.Linq.Expressions;

namespace Infrastructure
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserAsync(Expression<Func<User, bool>> predicate);

    }

}