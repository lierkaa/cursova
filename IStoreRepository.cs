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
    public interface IStoreService
    {
        void DisplayCars();
        void PurchaseCar(User user, int carId);
        void ViewPurchaseHistory(User user);
    }
}
