using System;
namespace Restaurant.Models.Beverages
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMililiters = 50;

        private const decimal coffeePrice = 3.50M;


        public Coffee(string name, double caffeine):base(name, coffeePrice, coffeeMililiters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
