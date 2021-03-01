using System;
using System.Collections.Generic;
using Wild_Farm.Common;

namespace Wild_Farm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
               : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PreferedFood
            => new List<Type> {typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) };

        public override double WeightMultiplier => 0.35;

        public override string ProduceSound()
        {
            return Sounds.HEN;
        }
    }
}
