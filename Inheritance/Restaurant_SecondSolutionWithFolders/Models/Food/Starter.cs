using System;
namespace Restaurant.Models.Food
{
    public class Starter : Food
    {
        public Starter(string name, decimal price, double grams) : base(name, price, grams)
        {
        }
    }
}
