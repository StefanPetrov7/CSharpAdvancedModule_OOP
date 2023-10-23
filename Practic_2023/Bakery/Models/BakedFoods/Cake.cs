using System;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Models.BakedFoods
{
	public class Cake : BakedFood, IBakedFood
	{
        private const int InitialCakePortion = 245;

        public Cake(string name, decimal price) : base(name, InitialCakePortion, price)
        { }
    }
}

