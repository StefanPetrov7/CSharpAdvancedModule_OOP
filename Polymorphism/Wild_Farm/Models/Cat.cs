using System;
using System.Collections.Generic;
using Wild_Farm.Common;

namespace Wild_Farm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
              : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PreferedFood => new List<Type> {typeof(Vegetable), typeof(Meat) };

        public override double WeightMultiplier => 0.30;

        public override string ProduceSound()
        {
            return Sounds.CAT;
        }
    }
}
