using Polymorphism.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightIncrease { get;  }

        public abstract string ProduceSound();

        public virtual bool EatFood(Food food)
        {
            this.Weight += food.Quantity * this.WeightIncrease;
            this.FoodEaten += food.Quantity;
            return true;
        }
    }
}
