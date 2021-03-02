using System;
using System.Collections.Generic;

using Wild_Farm.Contracts;
using Wild_Farm.IO;

namespace Wild_Farm.Models
{
    public abstract class Animal
    {
        private string DEFAULT_SOUND = "DEFAULT";
        private IWriter writer = new ConsoleWriter();

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        protected string Name { get; }

        protected double Weight { get; private set; }

        protected int FoodEaten { get; private set; }

        public abstract ICollection<Type> PreferedFood { get; }

        public abstract double WeightMultiplier { get; }

        public virtual string ProduceSound()
        {
            return DEFAULT_SOUND;
        }

        public virtual void Eat(Food food)
        {
            if (!this.PreferedFood.Contains(food.GetType()))
            {
                writer.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                this.Weight += food.Qty * this.WeightMultiplier;
                this.FoodEaten += food.Qty;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
