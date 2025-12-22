
using System.Security.Claims;
using WebApp.Application.Interfaces;
using WebApp.Domain.Interfaces.Repositories;

namespace WebApp.Application.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository UserRepository;
        private readonly IPasswordHasher PasswordHasher;

        public LoginUserUseCase(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            UserRepository = userRepository;
            PasswordHasher = passwordHasher;
        }

        public async Task<List<Claim>?> Execute(string email, string password)
        {
            var user = await UserRepository.GetByEmailAsync(email);

            if (user == null || !PasswordHasher.Verify(password, user.Password!))
                return null;

            return new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name!),
            new Claim(ClaimTypes.Role, user.Role!)
        };
        }
    }

}
