using System;
namespace Pizza_Calories.Common
{
    public static class GlobalConstants
    {
        public const string INAVLID_TYPE_DOUGH = "Invalid type of dough.";
        public const string INAVLID_WEIGHT = "Dough weight should be in the range [{0}..{1}].";
        public const string INVALID_TOPPING = "Cannot place {0} on top of your pizza.";
        public const string INVALID_TOPPING_WEIGHT = "{0} weight should be in the range [{1}..{2}].";
        public const string INVALID_PIZZA_NAME = "Pizza name should be between {0} and {1} symbols.";
        public const string INVALID_PIZZA_TOPPINGS = "Number of toppings should be in range [{0}..{1}].";
        public const string TO_STRING_PIZZA = "{0} - {1:f2} Calories.";
        public const double BASE_CALORIES = 2;
        public const int DOUGH_MIN_VALUE = 1;
        public const int DOUGH_MAX_VALUE = 200;
        public const int TOPPING_MIN_VALUE = 1;
        public const int TOPPING_MAX_VALUE = 50;
        public const int PIZZA_MIN_CHAR = 1;
        public const int PIZZA_MAX_CHAR = 15;
        public const int MIN_TOPPINGS = 0;
        public const int MAX_TOPPINGS = 10;
    }
}
