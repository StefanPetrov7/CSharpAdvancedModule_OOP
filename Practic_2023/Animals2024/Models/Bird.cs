using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, int wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public int WingSize { get; set; }

        public override string ToString() => $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";

    }
}
