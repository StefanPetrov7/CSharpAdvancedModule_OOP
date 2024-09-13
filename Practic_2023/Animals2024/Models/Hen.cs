using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public class Hen : Bird
    {

        public Hen(string name, double weight, int wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double WeightIncrease => 0.35;

        public override string ProduceSound() => "Cluck";

    }
}
