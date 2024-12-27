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
    class WalletService : IWalletService
    {
        public void AddBalance(User user, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Must be greater than zero.");
                return;
            }

            user.Balance += amount;
            Console.WriteLine($"Successfully added {amount} to your balance.\n Current balance: {user.Balance}");
        }
        public void ViewBalance(User user)
        {
            Console.Clear();
            Console.WriteLine($"\nYour current balance is: {user.Balance}");
        }
    }
}