using System;
using Restaurant.Models.Beverages;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Coffee coffee = new Coffee("lavaza", 50);
            Console.WriteLine(coffee);
        }
    }
}
