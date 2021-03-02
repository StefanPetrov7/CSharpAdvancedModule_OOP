using System;
using System.Linq;
using System.Reflection;
using Wild_Farm.Models;

namespace Wild_Farm.Factory
{
    public class FoodFactory
    {
        public Food GetFood(string[] args)
        {
            string foodType = args[0];
            int qty = int.Parse(args[1]);

            Assembly assembly = Assembly.GetExecutingAssembly(); // Reflection way of getting the food object.
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == foodType);
            object[] foodCtor = new object[] { qty };
            Food food = (Food)Activator.CreateInstance(type, foodCtor);
            return food;

            //Food food = null;  // => No Reflection

            //if (foodType == typeof(Meat).Name)
            //{
            //    food = new Meat(qty);
            //}
            //else if (foodType == typeof(Seeds).Name)
            //{
            //    food = new Seeds(qty);
            //}
            //else if (foodType == typeof(Fruit).Name)
            //{
            //    food = new Fruit(qty);
            //}
            //else if (foodType == typeof(Vegetable).Name)
            //{
            //    food = new Vegetable(qty);
            //}

            //return food;
        }
    }
}
