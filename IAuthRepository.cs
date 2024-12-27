using kursova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace kursova.Services
{
    public interface IAuthService
    {
        void Register(string username, string password);
        User Login(string username, string password);
    }
}
