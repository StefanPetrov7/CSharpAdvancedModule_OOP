using System;

using Wild_Farm.Contracts;

namespace Wild_Farm.Models
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
           : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get;  }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
