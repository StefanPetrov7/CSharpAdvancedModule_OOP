using System;
using Bakery.Models.Drinks.Contracts;

namespace Bakery.Models.Drinks
{
	public class Tea : Drink, IDrink
	{
        private const decimal TeaPrice = 2.50M;

        public Tea(string name, int portion, string brand) : base(name, portion, TeaPrice, brand)
        { }
    }
}

