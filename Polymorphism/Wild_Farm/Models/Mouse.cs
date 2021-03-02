using System;
using System.Collections.Generic;

using Wild_Farm.Common;

namespace Wild_Farm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override ICollection<Type> PreferedFood => new List<Type> { typeof(Vegetable), typeof(Fruit) };

        public override double WeightMultiplier => 0.10;

        public override string ProduceSound()
        {
            return Sounds.MOUSE;
        }
    }
}
