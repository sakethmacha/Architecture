using System;
using System.Collections.Generic;
using WebApp.Application.Interfaces;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Repositories;

namespace WebApp.Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository UserRepository;
        private readonly IPasswordHasher PasswordHasher;

        public RegisterUserUseCase(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            UserRepository = userRepository;
            PasswordHasher = passwordHasher;
        }

        public async Task<bool> Execute(string name, string email, string password, string role, int leaveBalance)
        {
            if (await UserRepository.ExistsAsync(email))
                return false;

            var hash = PasswordHasher.Hash(password);

            var user = new User(name, email, hash, role,leaveBalance);

            await UserRepository.AddAsync(user);
            return true;
        }
    }

}
