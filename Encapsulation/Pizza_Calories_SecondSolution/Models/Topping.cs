using System;
using System.Collections.Generic;
using Pizza_Calories.Common;

namespace Pizza_Calories.Models
{
    public class Topping
    {
        private Dictionary<string, double> toppingTypes = new Dictionary<string, double>
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9
        };

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Calories => GlobalConstants.BASE_CALORIES * this.Weight * toppingTypes[this.Type.ToLower()];

        private string Type
        {
            get => this.type;
            set
            {
                if (!toppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.INVALID_TOPPING, value));
                }

                this.type = value;
            }
        }

        private double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string
                        .Format(GlobalConstants.INVALID_TOPPING_WEIGHT, this.Type, GlobalConstants.TOPPING_MIN_VALUE, GlobalConstants.TOPPING_MAX_VALUE));
                }

                this.weight = value;
            }
        }
    }
}
