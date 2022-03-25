using System;
namespace Restaurant.Models.Food
{
    public class Soup: Starter
    {
        public Soup(string name, decimal price, double grams): base(name, price, grams)
        {
        }
    }
}
