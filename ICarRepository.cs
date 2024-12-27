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
    public interface ICarRepository
    {
        List<Car> GetCars();
        Car GetCarById(int id);
    }
}
