using kursova.Models;
using kursova.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace kursova.Services
{
    class AuthService : IAuthService
    {
        private readonly UserRepository userRepository;

        public AuthService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Register(string username, string password)
        {
            if (userRepository.GetUserByUsername(username) != null)
            {
                Console.WriteLine("Username already exists.");
                return;
            }

            string passwordHash = HashPassword(password);
            userRepository.AddUser(new User { Username = username, PasswordHash = passwordHash });
            Console.WriteLine("Registration successful.");
        }

        public User Login(string username, string password)
        {
            var user = userRepository.GetUserByUsername(username);
            if (user == null || user.PasswordHash != HashPassword(password))
            {
                Console.WriteLine("Invalid username or password.");
                return null;
            }

            Console.WriteLine("Login successful.");
            return user;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}