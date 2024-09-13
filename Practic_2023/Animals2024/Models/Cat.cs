using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class Cat : Feline
    {

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightIncrease => 0.3;

        public override string ProduceSound() => "Meow";

        public override bool EatFood(Food food) => food is Meat or Vegetable && base.EatFood(food); 

    }
}
