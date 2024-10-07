using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class Manager
    {
        private Kund loggedinKund;
        bool isloggedIn = false;
        public List<Kund> kundLista;
        
        public Manager()
        {
            kundLista = new List<Kund>();

        }

        public bool createUser()
        {
            Console.WriteLine("Please create a username: ");
            Console.Write("\t\n name: ");
            string kundName = Console.ReadLine();
            Console.Write("\t\n password: ");
            string password = Console.ReadLine();

            Kund newKund; 

            if (!kundLista.Any(k => k.Name.Equals(kundName, StringComparison.OrdinalIgnoreCase))) // <---- LINQ QUERY METHOD
            {
                if (!string.IsNullOrWhiteSpace(kundName) && !string.IsNullOrWhiteSpace(password))
                {
                    Console.Clear();
                    newKund =new Kund(kundName, password);
                    Console.WriteLine($"{kundName} user created.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    kundLista.Add(newKund);

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Cannot contain empty spaces.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Customer already exists");
                Thread.Sleep(1000);
                Console.Clear();
            }


            return true;
        }


        public void showCustomers()
        {
            foreach (Kund newKund in kundLista)
            {
                Console.WriteLine($"{newKund.Name} ");
                Thread.Sleep(1500);
                Console.WriteLine("\n\nPress Any key To Continue");
                Console.ReadKey();
                
                Console.Clear();

            }

        }


        public bool Login()
        {
            Console.WriteLine("Enter username: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            foreach (Kund newKund in kundLista)
            {
                if (newKund == kundLista.FirstOrDefault(k => k.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    loggedinKund = new Kund(name, password);
                    Console.Clear();
                    Console.WriteLine("You are logged in");
                    Thread.Sleep(1000);
                    Console.Clear();
                    isloggedIn = true;
                    return isloggedIn;

                }
            }

            return isloggedIn;
        }

        public bool IsLoggedIn()
        {
            while (isloggedIn)
            {
                meny.loggedinMeny(loggedinKund);
            }
            return true;
        }


        public void Checkout(Kund kund)
        {
            Dictionary<string, int> productCount = new Dictionary<string, int>();
            double totalPrice = 0;
            foreach ( var item in kund.Cart)
            {
                
                string productName = item.produktName;

                if (!productCount.ContainsKey(productName))
                {
                    productCount[productName] = 1;
                }
                else
                {
                    productCount[productName]++;
                }

                totalPrice += item.price;
            }

            foreach (var product in productCount)
            {
                if (product.Value > 1)
                {

                    Console.WriteLine($"{product.Key} x {product.Value}");
                }
                else
                {
                    Console.WriteLine(product.Key);
                }
            }

            if (kund.Cart.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your Cart is empty cannot checkout");
                Thread.Sleep(1300);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"Total price: " + totalPrice + "kr");
                Thread.Sleep(2000);
                Console.WriteLine("Do you want to checkout? (y/n)");
                string answer = Console.ReadLine();
                if (answer == "y")
                {

                    Console.WriteLine("Thank you for your purchase!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    kund.Cart.Clear();

                }
                else
                {
                    Console.WriteLine("Purchase cancelled");
                    Thread.Sleep(1000);
                    Console.Clear();

                }
            }


            
        }
        public void ViewProducts()
        {
            Produkt[] products = Produkt.LoadProducts();
            foreach (Produkt item in products)
            {
                Console.WriteLine($"{item.produktName} - {item.price:C}");
                Console.WriteLine("--------------------------------------------------");
            }
        }

        public void ShowCustomerInfo(Kund kund)
        {
            Console.WriteLine($"Name: {kund.Name}");
            Console.WriteLine($"Cart: {kund.Cart.Count} items");
            Thread.Sleep(1000);
            Console.WriteLine("\n\nPress Any Key To Return To The Menu..");
            Console.ReadKey();
            Console.Clear();
            


        }

     
    }
}


