using System;
namespace Restaurant.Models.Food
{
    public class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams): base(name, price, grams)
        {
        }
    }
}
