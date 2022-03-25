using System;
namespace Restaurant.Models.Beverages
{
    public class ColdBeverage : Beverage
    {
        public ColdBeverage(string name, decimal price, double mililiters) : base(name, price, mililiters)
        {
        }
    }
}
