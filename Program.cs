using kursova.Models;
using kursova.Repositories;
using kursova.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace kursova {
    class Program
    {
        static void Main()
        {
            var userRepository = new UserRepository();
            var carRepository = new CarRepository();

            IAuthService authService = new AuthService(userRepository);
            IStoreService storeService = new StoreService(carRepository);
            IWalletService walletService = new WalletService();

            User currentUser = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Register\n2. Login\n3. Add Balance\n4. View Current Balance\n5. View Cars\n6. Purchase Cars\n7. View Purchase History\n8. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\nRegister:");
                        Console.Write("Enter username: ");
                        var username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        var password = ReadPassword();
                        authService.Register(username, password);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nLogin:");
                        Console.Write("Enter username: ");
                        username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = ReadPassword();
                        currentUser = authService.Login(username, password);
                        break;
                    case "3":
                        if (currentUser == null)
                        {
                            Console.Clear();
                            Console.WriteLine("\nPlease log in first.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nAdd Balance:");
                            Console.Write("Enter amount to add: ");
                            if (decimal.TryParse(Console.ReadLine(), out var amount))
                            {
                                walletService.AddBalance(currentUser, amount);
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount.");
                            }
                        }
                        break;
                    case "4":
                        if (currentUser == null)
                        {
                            Console.Clear();
                            Console.WriteLine("\nPlease log in first.");
                        }
                        else
                        {
                            walletService.ViewBalance(currentUser);
                        }
                        break;
                    case "5":
                        storeService.DisplayCars();
                        break;
                    case "6":
                        if (currentUser == null)
                        {
                            Console.Clear();
                            Console.WriteLine("\nPlease log in first.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nPurchase Car:");
                            Console.Write("Enter product ID: ");
                            if (int.TryParse(Console.ReadLine(), out var carId))
                            {
                                storeService.PurchaseCar(currentUser, carId);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Car ID.");
                            }
                        }
                        break;
                    case "7":
                        if (currentUser == null)
                        {
                            Console.Clear();
                            Console.WriteLine("\nPlease log in first.");
                        }
                        else
                        {
                            storeService.ViewPurchaseHistory(currentUser);
                        }
                        break;
                    case "8":
                        Console.Clear();
                        Console.WriteLine("\nGoodbye!");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nInvalid choice. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }

        static string ReadPassword()
        {
            var password = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            return password.ToString();
        }
    }
}