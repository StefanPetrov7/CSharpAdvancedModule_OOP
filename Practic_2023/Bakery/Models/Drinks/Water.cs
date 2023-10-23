using System;
using Bakery.Models.Drinks.Contracts;

namespace Bakery.Models.Drinks
{
	public class Water: Drink, IDrink
	{
		private const decimal WaterPrice = 1.50M;

		public Water(string name, int portion, string brand) : base(name, portion, WaterPrice, brand)
		{ }
	}
}

