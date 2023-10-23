using System;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood, IBakedFood
    {
        private const int InitialBreadPortion = 200;

        public Bread(string name, decimal price) : base(name, InitialBreadPortion, price)
        { }
    }
}

