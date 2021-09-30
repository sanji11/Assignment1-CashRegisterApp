using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class Product
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public Product(string n, int qty, double pr) {
            name = n;
            quantity = qty;
            price = pr;
        }
        public Product(string n, int qty)
        {
            name = n;
            quantity = qty;
        }
    }
}
