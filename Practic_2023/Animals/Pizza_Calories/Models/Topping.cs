using Pizza_Calories.Validators;
using Pizza_Calories.Common;

namespace Pizza_Calories.Models
{
    public class Topping
    {
        private readonly Dictionary<string, double> toppingTypeValues = new Dictionary<string, double>()
        {
            { "meat" , 1.2 },
            { "veggies" , 0.8},
            { "cheese" , 1.1},
            { "sauce" , 0.9}
        };

        private const int BASE_WEIGHT = 2;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get => this.type;
            set
            {
                Validator.ToppingValidator(value, toppingTypeValues, GlobalConstants.INVALID_TOPPING_TYPE);
                this.type = value;
            }
        }

        private int Weight
        {
            get => this.weight;
            set
            {
                Validator.WeightValidatorTopping(value, GlobalConstants.MIN_DOUGHT_WEIGHT,
                    GlobalConstants.MAX_TOPPING_WEIGHT, GlobalConstants.INVALID_TOPPING_WEIGHT, this.Type);
                this.weight = value;
            }
        }

        public double Calories => this.Weight * BASE_WEIGHT * toppingTypeValues[this.Type.ToLower()];

    }
}

