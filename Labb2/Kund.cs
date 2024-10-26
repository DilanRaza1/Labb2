using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class Kund
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Produkt> Cart { get; set; }
        public Kund(string name, string password)
        {
            Name = name;
            Password = password;
            Cart = new List<Produkt>();

        }

        public override string ToString()
        {
            return $"Customer Name: {Name}\nPassword: {Password}\nItems in Cart: {Cart.Count}";
        }

    }
}
