using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class Tiger : Feline
    {

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightIncrease => 1.0;

        public override string ProduceSound() => "ROAR!!!";

        public override bool EatFood(Food food) => food is Meat  && base.EatFood(food);
    }

}
