using System;
using System.Collections.Generic;
using System.Linq;

using Pizza_Calories.Common;

namespace Pizza_Calories.Models
{
    public class Pizza
    {
        private string name;
        private ICollection<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new HashSet<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length < GlobalConstants.NAME_MIN_LETTERS || value.Length > GlobalConstants.NAME_MAX_LETTERS)
                {
                    throw new Exception(string.Format(GlobalConstants.INVALID_PIZZA_NAME,
                        GlobalConstants.NAME_MIN_LETTERS, GlobalConstants.NAME_MAX_LETTERS));
                }

                this.name = value;
            }
        }

        private Dough Dough { get; set; }

        public int CountToppings => this.toppings.Count;

        public void AddToppings(Topping topping)
        {
            if (toppings.Count < GlobalConstants.MAX_TOPPINGS)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new Exception(string.Format(GlobalConstants.INVALID_TOPPING_COUNT,
               GlobalConstants.MIN_TOPPINGS, GlobalConstants.MAX_TOPPINGS));
            }
        }

        public void AddDough(string type, string model, double weight)
        {
            this.Dough = new Dough(type, model, weight);
        }

        public double CalculatePizzaCalories() => this.toppings.Sum(x => x.Calories) + this.Dough.Calories;

        public override string ToString()
        {
            return $"{this.Name} - {this.CalculatePizzaCalories():f2} Calories.";
        }
    }
}
