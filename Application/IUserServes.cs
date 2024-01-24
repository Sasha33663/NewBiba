using Domain;

namespace Application
{
    public interface IUserServes
    {
        Task<User> UserCreatAsync(string name, string email);
    }
}