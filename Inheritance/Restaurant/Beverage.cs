using System;
namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliters) : base(name, price)
        {
            Milliliters = milliters;
        }

        public virtual double Milliliters { get; set; }
    }
}
