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
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> cars = new()
    {
        new Car { Id = 1, Name = "Audi RS7 Mansory", Price = 370000, Stock = 2},
        new Car { Id = 2, Name = "Mercedes-Benz G63", Price = 221366, Stock = 5},
        new Car { Id = 3, Name = "BMW I8", Price = 70500, Stock = 3},
        new Car { Id = 4, Name = "Ford Mustang Shelby GT500", Price = 125000, Stock = 10},
        new Car { Id = 5, Name = "Rolls Royce Phantom", Price = 394999, Stock = 1},
        new Car { Id = 6, Name = "Nissan GT-R 35 Nismo", Price = 222885, Stock = 4},
        new Car { Id = 7, Name = "TVR Griffith", Price = 112722, Stock = 6}
    };

        public List<Car> GetCars() => cars;
        public Car GetCarById(int id) => cars.FirstOrDefault(p => p.Id == id);
    }
}