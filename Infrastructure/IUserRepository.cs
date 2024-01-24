using Domain;

namespace Infrastructure
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
    }
}