using System;
using System.Collections.Generic;
using Wild_Farm.Common;

namespace Wild_Farm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PreferedFood => new List<Type> { typeof(Meat) };

        public override double WeightMultiplier => 1.00;

        public override string ProduceSound()
        {
            return Sounds.TIGER;
        }
    }
}
