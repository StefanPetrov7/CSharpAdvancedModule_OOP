namespace Pizza_Calories.Common
{
	public static class GlobalConstants
	{
		public const string INVALID_DOUGH_TYPE = "Invalid type of dough.";
		public const string INVALID_DOUGH_WEIGHT = "Dough weight should be in the range [{0}..{1}].";

		public const string INVALID_TOPPING_TYPE = "Cannot place {0} on top of your pizza.";
		public const string INVALID_TOPPING_WEIGHT = "{0} weight should be in the range [{1}..{2}].";

		public const string INVALID_PIZZA_NAME = "Pizza name should be between 1 and 15 symbols.";

		public const string EXCESSIVE_TOOPINGS = "Number of toppings should be in range [0..10].";


        public const int MIN_DOUGHT_WEIGHT = 1;
		public const int MAX_DOUGHT_WEIGHT = 200;

        public const int MIN_TOPPING_WEIGHT = 1;
        public const int MAX_TOPPING_WEIGHT = 50;

        public const int PIZZA_MIN_NAME = 1;
        public const int PIZZA_MAX_NAME = 15;

    }
}

