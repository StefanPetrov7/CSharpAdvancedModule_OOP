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
            this.toppings = new List<Topping>();
        }

        public double Calories => this.PizzaDough.Calories + this.toppings.Sum(x => x.Calories);

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > GlobalConstants.PIZZA_MAX_CHAR)
                {
                    throw new Exception(string
                        .Format(GlobalConstants.INVALID_PIZZA_NAME, GlobalConstants.PIZZA_MIN_CHAR, GlobalConstants.PIZZA_MAX_CHAR));
                }

                this.name = value;
            }
        }

        private Dough PizzaDough { get; set; }

        public void AddDough(Dough dough)
        {
             this.PizzaDough = dough;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == GlobalConstants.MAX_TOPPINGS)
            {
                throw new ArgumentException(string
                    .Format(GlobalConstants.INVALID_PIZZA_TOPPINGS, GlobalConstants.MIN_TOPPINGS, GlobalConstants.MAX_TOPPINGS));
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return string.Format(GlobalConstants.TO_STRING_PIZZA, this.Name, this.Calories);
        }
    }
}
