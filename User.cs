using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace kursova.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public decimal Balance { get; set; } = 0;
        public List<string> PurchaseHistory { get; set; } = new List<string>();
    }
}
