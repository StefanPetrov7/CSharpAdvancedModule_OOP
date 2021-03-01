using System;
using Wild_Farm.Common;
using Wild_Farm.Models;

namespace Wild_Farm.Factory
{
    public class FoodFactory
    {
        public Food GetFood(string[] args)
        {
            string foodType = args[0];
            int qty = int.Parse(args[1]);
            Food food = null;

            if (foodType == typeof(Meat).Name)
            {
                food = new Meat(qty);
            }
            else if (foodType == typeof(Seeds).Name)
            {
                food = new Seeds(qty);
            }
            else if (foodType == typeof(Fruit).Name)
            {
                food = new Fruit(qty);
            }
            else if (foodType == typeof(Vegetable).Name)
            {
                food = new Vegetable(qty);
            }

            return food;
        }
    }
}
