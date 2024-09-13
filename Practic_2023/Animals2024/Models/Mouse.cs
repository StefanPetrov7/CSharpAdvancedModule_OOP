using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class Mouse : Mammal
    {

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double WeightIncrease => 0.1;

        public override string ProduceSound() => "Squeak";

        public override bool EatFood(Food food) => food is Fruit or Vegetable && base.EatFood(food);

    }
}
