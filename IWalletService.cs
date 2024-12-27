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
    public interface IWalletService
    {
        void AddBalance(User user, decimal amount);
        void ViewBalance(User user);
    }
}
