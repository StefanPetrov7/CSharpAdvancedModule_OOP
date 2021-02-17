using System;
using System.Collections.Generic;

using Pizza_Calories.Common;

namespace Pizza_Calories.Models
{
    public class Dough
    {
        private readonly Dictionary<string, double> BACKING_TECHNIQUES = new Dictionary<string, double>
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        private readonly Dictionary<string, double> FLOUR_TYPE = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < GlobalConstants.DOUGHT_MIN_WEIGHT || value > GlobalConstants.DOUGHT_MAX_WEIGHT)
                {
                    throw new Exception(string.Format
                        (GlobalConstants.INVALIDE_WEIGHT, GlobalConstants.DOUGHT_MIN_WEIGHT, GlobalConstants.DOUGHT_MAX_WEIGHT));
                }

                this.weight = value;
            }
        }

        private string FlourType
        {
            get { return this.flourType; }

            set
            {
                if (FLOUR_TYPE.ContainsKey(value.ToLower()))
                {
                    this.flourType = value.ToLower();
                }
                else
                {
                    throw new Exception(GlobalConstants.INVALIDE_DOUGH);
                }
            }
        }

        private string BakingTechnique
        {
            get { return this.bakingTechnique; }

            set
            {
                if (BACKING_TECHNIQUES.ContainsKey(value.ToLower()))
                {
                    this.bakingTechnique = value.ToLower();
                }
                else
                {
                    throw new Exception(GlobalConstants.INVALIDE_DOUGH);
                }
            }
        }

        public double Calories
            => this.Weight * 2 * FLOUR_TYPE[this.FlourType] * BACKING_TECHNIQUES[this.BakingTechnique];

    }
}
