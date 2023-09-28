using Pizza_Calories.Validators;
using Pizza_Calories.Common;

namespace Pizza_Calories.Models
{
    public class Dough
    {
        private readonly Dictionary<string, double> flourTypeVlues = new Dictionary<string, double>()
        {
            { "white",  1.5 },
            { "wholegrain" , 1.0 },
        };

        private readonly Dictionary<string, double> backingTechniqueValues = new Dictionary<string, double>()
        {
            { "crispy" , 0.9 },
            { "chewy" , 1.1},
            { "homemade" , 1.0}
        };

        private const int BASE_WEIGHT = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string type, string technique, int weight)
        {
            this.FlourType = type;
            this.BakingTechnique = technique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get => this.flourType;

            set
            {
                Validator.FlourDoughValidator(value, flourTypeVlues, GlobalConstants.INVALID_DOUGH_TYPE);
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                Validator.FlourDoughValidator(value, backingTechniqueValues, GlobalConstants.INVALID_DOUGH_TYPE);
                this.bakingTechnique = value;
            }
        }

        private int Weight
        {
            get => this.weight;
            set
            {
                Validator.WeightValidatorDough(value, GlobalConstants.MIN_DOUGHT_WEIGHT,
                    GlobalConstants.MAX_DOUGHT_WEIGHT, GlobalConstants.INVALID_DOUGH_WEIGHT);

                this.weight = value;
            }
        }

        public double Calories
            => this.Weight * BASE_WEIGHT * flourTypeVlues[this.FlourType.ToLower()] * backingTechniqueValues[this.BakingTechnique.ToLower()];
    }
}

