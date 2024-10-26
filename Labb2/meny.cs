using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    internal class meny
    {
        public static bool MainMeny()
        {
            bool showMeny = true;

            Manager manager = new Manager();

            while (showMeny)
            {
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Create a user");
                Console.WriteLine("3. Show registered customers");
                Console.WriteLine("4. Exit");
                Console.WriteLine("\r\nVälj ett alternativ: ");

                ConsoleKeyInfo userChoice = Console.ReadKey();

                if (userChoice.Key != ConsoleKey.D1 || userChoice.Key != ConsoleKey.D2 || userChoice.Key != ConsoleKey.D3 || userChoice.Key != ConsoleKey.D4)
                {
                    Console.Clear();
                }

                switch (userChoice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        bool loginsuccess = manager.Login();
                        if (loginsuccess)
                        {
                            Console.Clear();
                            showMeny= false;
                            manager.IsLoggedIn();
                            return showMeny;
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }


                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        manager.createUser();

                        break;



                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        manager.showCustomers();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);
                        break;


                }
            }

            return false;
        }

        public static bool loggedinMeny(Kund kund)
        {
            bool showMeny = true;

            Manager manager = new Manager();

            ShoppingCart cart = new ShoppingCart(kund);

          
           
            while (showMeny)
            {
                Console.WriteLine("1. Your ShoppingCart");
                Console.WriteLine("2. show Products");
                Console.WriteLine("3. Buy products");
                Console.WriteLine("4. Go to checkout");
                Console.WriteLine("5. Customer info");
                Console.WriteLine("6. Exit");
                Console.WriteLine("7. Logout");
                Console.WriteLine("\r\nChoose an option: ");

                ConsoleKeyInfo userChoice = Console.ReadKey();

                if (userChoice.Key != ConsoleKey.D1 || userChoice.Key != ConsoleKey.D2 || userChoice.Key != ConsoleKey.D3 || userChoice.Key != ConsoleKey.D4 || userChoice.Key != ConsoleKey.D5 || userChoice.Key != ConsoleKey.D6 || userChoice.Key != ConsoleKey.D7)
                {
                    Console.Clear();
                }

                switch (userChoice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        ShoppingCart.ShowCart(kund.Cart);
                        break;

                      


                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        manager.ViewProducts();
                        break;




                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("Which product would you like to buy: ");
                        Produkt.BuyProducts(cart);
                        break;

                        

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        manager.Checkout(kund);
                        break;


                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                        Console.Clear();
                        manager.ShowCustomerInfo(kund);
                        break;


                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                        Console.Clear();
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);
                        break;

                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                        Console.Clear();
                        manager.Logout();
                        break;
                }


            }

            return false;
        }
    }
}
