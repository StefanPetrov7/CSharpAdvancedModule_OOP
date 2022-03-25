using System;

namespace Restaurant.Models.Beverages
{
    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double mililiters) : base(name, price, mililiters)
        {
        }
    }
}
