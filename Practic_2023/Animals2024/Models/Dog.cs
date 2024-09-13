using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class Dog : Mammal
    {

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double WeightIncrease => 0.4;

        public override string ProduceSound() => "Woof!";

        public override bool EatFood(Food food) => food is Meat && base.EatFood(food);
    }
}
