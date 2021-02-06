using System;
namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double calories = 1000;

        private const double grams = 1000;

        private const decimal price = 5;

        public Cake(string name) : base(name, price, grams, calories)
        {

        }

    }
}
