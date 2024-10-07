using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class ShoppingCart
    {
        private Kund kund;

        public ShoppingCart(Kund kund)
        {
            this.kund = kund;
        }
        
        public void AddProduct(Produkt products)
        {
            kund.Cart.Add(products);
        }

        public void RemoveProduct(Produkt products)
        {
            kund.Cart.Remove(products);

        }

        public void PrintKundVagn()
        {
            foreach (var item in kund.Cart)
            {
                Console.WriteLine(item);
            }

        }

        public static void ShowCart(List<Produkt> cart)
        {
            Dictionary<string, int> productCount = new Dictionary<string, int>();
            double totalPrice = 0;

            if (cart.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your shopping cart is empty.");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Your Cart:");
                foreach (var item in cart)
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

                Console.WriteLine("Total price: " + totalPrice);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

    }
}

    


    
