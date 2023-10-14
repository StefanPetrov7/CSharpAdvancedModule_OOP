using WildFarm.Enumeration;
using WildFarm.Models.Foods;
using WildFarm.Exceptios;

namespace WildFarm.Factory
{
    public static class FoodFactory
    {
        public static Food GetFood(string foodType, int qty)
        {
            Food food = null;

            if (Enum.TryParse(foodType, out FoodType curFood) == false)
            {
                throw new InvalidFoodException();
            }

            if (curFood == FoodType.Fruit)
            {
                food = new Fruit(qty);
            }
            else if (curFood == FoodType.Meat)
            {
                food = new Meat(qty);
            }
            else if (curFood == FoodType.Seeds)
            {
                food = new Seeds(qty);
            }
            else if (curFood == FoodType.Vegetable)
            {
                food = new Vegetable(qty);
            }

            return food;
        }
    }
}

