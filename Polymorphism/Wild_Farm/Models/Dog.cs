using System;
using System.Collections.Generic;
using Wild_Farm.Common;

namespace Wild_Farm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
           : base(name, weight, livingRegion)
        {
        }

        public override ICollection<Type> PreferedFood => new List<Type> { typeof(Meat) };

        public override double WeightMultiplier => 0.40;

        public override string ProduceSound()
        {
            return Sounds.DOG;
        }
    }
}
