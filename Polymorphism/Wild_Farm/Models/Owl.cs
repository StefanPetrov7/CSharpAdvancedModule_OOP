using System;
using System.Collections.Generic;

using Wild_Farm.Common;

namespace Wild_Farm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return Sounds.OWL;
        }

        public override double WeightMultiplier => 0.25;

        public override ICollection<Type> PreferedFood => new List<Type> { typeof(Meat) };
    }
}
