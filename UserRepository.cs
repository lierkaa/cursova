using kursova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace kursova.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new();

        public User GetUserByUsername(string username) => users.FirstOrDefault(u => u.Username == username);
        public void AddUser(User user) => users.Add(user);
    }
}