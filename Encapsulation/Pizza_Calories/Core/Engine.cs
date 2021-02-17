using System;

using Pizza_Calories.Models;

namespace Pizza_Calories.Core
{
    public class Engine
    {
        private const string END_INGRIDIENTS = "END";

        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughtInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];
                string doughType = doughtInfo[1];
                string doughModel = doughtInfo[2];
                double weightDough = double.Parse(doughtInfo[3]);

                Pizza pizza = new Pizza(pizzaName);

                pizza.AddDough(doughType, doughModel, weightDough);

                string input;

                while ((input = Console.ReadLine()) != END_INGRIDIENTS)
                {
                    string[] toppingInfo = input.Split();
                    string toppingType = toppingInfo[1];
                    double weightTopping = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(toppingType, weightTopping);
                    pizza.AddToppings(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
