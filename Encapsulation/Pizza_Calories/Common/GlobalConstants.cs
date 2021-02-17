namespace Pizza_Calories.Common
{
    public static class GlobalConstants
    {
        
        public const string INVALIDE_DOUGH = "Invalid type of dough.";
        public const string INVALIDE_WEIGHT = "Dough weight should be in the range [{0}..{1}].";
        public const string INVALID_TOPPING_TYPE = "Cannot place {0} on top of your pizza.";
        public const string INVALID_TOPPING_WEIGHT = "{0} weight should be in the range[{1}..{2}].";
        public const string INVALID_PIZZA_NAME = "Pizza name should be between {0} and {1} symbols.";
        public const string INVALID_TOPPING_COUNT = "Number of toppings should be in range [{0}..{1}].";
        public const double DOUGHT_MIN_WEIGHT = 1;
        public const double DOUGHT_MAX_WEIGHT = 200;
        public const double TOPPING_MIN_WEIGHT = 1;
        public const double TOPPING_MAX_WEIGHT = 50;
        public const int NAME_MIN_LETTERS= 1;
        public const int NAME_MAX_LETTERS = 15;
        public const int MIN_TOPPINGS = 0;
        public const int MAX_TOPPINGS = 10;

    }
}
