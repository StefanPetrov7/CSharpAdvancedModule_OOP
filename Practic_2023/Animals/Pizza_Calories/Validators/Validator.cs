using Pizza_Calories.Common;
namespace Pizza_Calories.Validators
{
    public static class Validator
    {
        public static void FlourDoughValidator(string flour, Dictionary<string, double> values, string message)
        {
            if (values.ContainsKey(flour.ToLower()) == false)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ToppingValidator(string topping, Dictionary<string, double> values, string message)
        {
            if (values.ContainsKey(topping.ToLower()) == false)
            {
                throw new ArgumentException(string.Format(message, topping));
            }
        }

        public static void PizzaNameValidator(string name)
        {
            if (name.Length < GlobalConstants.PIZZA_MIN_NAME || name.Length > GlobalConstants.PIZZA_MAX_NAME || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(GlobalConstants.INVALID_PIZZA_NAME);
            }
        }

        public static void WeightValidatorDough(int weight, int minValu, int maxValue, string message)
        {
            if (weight < minValu || weight > maxValue)
            {
                throw new ArgumentException(string.Format(message, minValu, maxValue));
            }
        }

        public static void WeightValidatorTopping(int weight, int minValu, int maxValue, string message, string type)
        {
            if (weight < minValu || weight > maxValue)
            {
                throw new ArgumentException(string.Format(message, type, minValu, maxValue)); ;
            }
        }
    }
}

