using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class History : Product
    {
        public double totalPrice { get; set; }
        public DateTime date { get; set; }
        public History(string name, int qty, double tPrice, DateTime dt) : base(name, qty)
        {
            totalPrice = tPrice;
            date = dt;
        }
    }
}
