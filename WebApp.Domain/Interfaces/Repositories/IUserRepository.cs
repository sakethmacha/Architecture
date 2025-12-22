

using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<bool> ExistsAsync(string email);
    }
}
