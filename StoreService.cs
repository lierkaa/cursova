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
    class StoreService : IStoreService
    {
        private readonly CarRepository CarRepository;

        public StoreService(CarRepository CarRepository)
        {
            this.CarRepository = CarRepository;
        }

        public void DisplayCars()
        {
            Console.Clear();
            Console.WriteLine("\nAvailable Cars:");
            foreach (var car in CarRepository.GetCars())
            {
                Console.WriteLine($"ID: {car.Id}, Name: {car.Name}, Price: {car.Price}, Stock: {car.Stock}");
            }
            Console.WriteLine();
        }

        public void PurchaseCar(User user, int carId)
        {
            var car = CarRepository.GetCarById(carId);
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            if (car.Stock <= 0)
            {
                Console.WriteLine("Car is out of stock.");
                return;
            }

            if (user.Balance < car.Price)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            user.Balance -= car.Price;
            car.Stock--;
            user.PurchaseHistory.Add(car.Name);

            Console.WriteLine($"Successfully purchased {car.Name}.");
        }

        public void ViewPurchaseHistory(User user)
        {
            Console.Clear();
            Console.WriteLine("\nPurchase History:");
            if (user.PurchaseHistory.Count == 0)
            {
                Console.WriteLine("History is empty.");
            }
            else
            {
                foreach (var purchase in user.PurchaseHistory)
                {
                    Console.WriteLine(purchase);
                }
            }
            Console.WriteLine();
        }
    }
}