using Microsoft.Extensions.Caching.Memory;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Repositories;
using WebApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext DbContext;
        private readonly IMemoryCache MemoryCache;

        public UserRepository(
            ApplicationDbContext context,
            IMemoryCache cache)
        {
            DbContext = context;
            MemoryCache = cache;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            if (!MemoryCache.TryGetValue(email, out User? user))
            {
                user = await DbContext.Users
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user != null)
                {
                    MemoryCache.Set(email, user, TimeSpan.FromMinutes(5));
                }
            }

            return user;
        }

        public async Task AddAsync(User user)
        {
            DbContext.Users.Add(user);
            await DbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await DbContext.Users.AnyAsync(u => u.Email == email);
        }
    }

}
