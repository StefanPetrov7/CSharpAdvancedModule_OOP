using System;
namespace Restaurant.Models.Food
{
    public class Fish : MainDish
    {
        private const double defaultGrams = 22;

        public Fish(string name, decimal price): base(name, price, defaultGrams)
        {
        }
    }
}
