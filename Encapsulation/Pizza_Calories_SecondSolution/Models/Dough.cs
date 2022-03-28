using System;
using System.Collections.Generic;
using Pizza_Calories.Common;

namespace Pizza_Calories.Models
{
    public class Dough
    {
        private Dictionary<string, double> flourTypes = new Dictionary<string, double>
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0,
        };

        private Dictionary<string, double> bakingTypes = new Dictionary<string, double>
        {
            ["crispy"] = 0.9,
            ["homemade"] = 1.0,
            ["chewy"] = 1.1,
        };

        private string flourType;
        private string bakingType;
        private double weight;

        public Dough(string flourType, string bakingType, double weght)
        {
            this.Type = flourType;
            this.BakingTechnique = bakingType;
            this.Weight = weght;
        }

        public double Calories
      => GlobalConstants.BASE_CALORIES * this.Weight * flourTypes[this.Type] * bakingTypes[this.BakingTechnique];

        private string Type
        {
            get => this.flourType;
            set
            {
                if (!flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(GlobalConstants.INAVLID_TYPE_DOUGH);
                }

                this.flourType = value.ToLower();
            }
        }

        private string BakingTechnique
        {
            get => this.bakingType;
            set
            {
                if (!bakingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(GlobalConstants.INAVLID_TYPE_DOUGH);
                }

                this.bakingType = value.ToLower();
            }
        }

        private double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new AggregateException(string
                        .Format(GlobalConstants.INAVLID_WEIGHT, GlobalConstants.DOUGH_MIN_VALUE, GlobalConstants.DOUGH_MAX_VALUE));
                }

                this.weight = value;
            }
        }
    }
}
