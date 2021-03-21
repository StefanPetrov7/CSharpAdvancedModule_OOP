using System;
namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal price = 2.50M;

        public Tea(string name, int portion, string brand)
            : base(name, portion, price, brand)
        { }
    }
}
