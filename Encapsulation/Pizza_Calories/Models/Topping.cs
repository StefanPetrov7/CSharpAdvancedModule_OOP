using System;
using System.Collections.Generic;

using Pizza_Calories.Common;
        
namespace Pizza_Calories.Models
{
    public class Topping
    {
        private string toppingType;
        private double weight;
        private string nameInput;

        private readonly Dictionary<string, double> TOPPING_TYPE = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private readonly Dictionary<string, string> TOPPING_NAMES = new Dictionary<string, string>
        {
            { "meat", "Meat"},
            { "veggies", "Veggies" },
            { "cheese", "Cheese" },
            { "sauce", "Saice" }
        };

        public Topping(string toppingType, double weight)
        {
            this.nameInput = toppingType;
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        private string ToppingType
        {
            get { return this.toppingType; }
            set
            {

                if (TOPPING_TYPE.ContainsKey(value.ToLower()))
                {
                    this.toppingType = value.ToLower();
                }
                else
                {
                    throw new Exception(string.Format(GlobalConstants.INVALID_TOPPING_TYPE, this.nameInput));
                }
            }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < GlobalConstants.TOPPING_MIN_WEIGHT || value > GlobalConstants.TOPPING_MAX_WEIGHT)
                {
                    throw new Exception(string.Format(GlobalConstants.INVALID_TOPPING_WEIGHT,
                        this.nameInput, GlobalConstants.TOPPING_MIN_WEIGHT, GlobalConstants.TOPPING_MAX_WEIGHT));
                }
                this.weight = value;
            }
        }

        public double Calories => this.Weight * 2 * TOPPING_TYPE[this.ToppingType];

    }
}
