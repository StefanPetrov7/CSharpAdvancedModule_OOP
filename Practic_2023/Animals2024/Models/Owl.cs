using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class Owl : Bird
    {

        public Owl(string name, double weight, int wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double WeightIncrease => 0.25;

        public override string ProduceSound() => "Hoot Hoot";

        public override bool EatFood(Food food) => food is Meat  && base.EatFood(food);
    }
}
