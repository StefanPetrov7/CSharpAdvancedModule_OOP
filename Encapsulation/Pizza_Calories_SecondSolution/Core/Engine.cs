using System;
using System.Linq;
using Pizza_Calories.Models;

namespace Pizza_Calories.Core
{
    public class Engine
    {
        private const string END_LOOP = "END";

        public void Run()
        {
            string[] pizzaArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] doughArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = pizzaArg[1];
            string doughFlour = doughArg[1];
            string doughType = doughArg[2];
            double doughWeight = double.Parse(doughArg[3]);

            try
            {
                Pizza pizza = CreatePizza(pizzaName);
                Dough dough = CreateDough(doughFlour, doughType, doughWeight);
                pizza.AddDough(dough);

                string input;

                while ((input = Console.ReadLine()) != END_LOOP)
                {
                    string[] toppingArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string toppingName = toppingArg[1];
                    double toppingWeight = double.Parse(toppingArg[2]);
                    Topping topping = CreateTopping(toppingName, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Topping CreateTopping(string toppingName, double toppingWeight)
        {
            Topping topping = new Topping(toppingName, toppingWeight);
            return topping;
        }

        private Dough CreateDough(string flour, string type, double weight)
        {
            Dough dough = new Dough(flour, type, weight);
            return dough;
        }

        private Pizza CreatePizza(string pizzaName)
        {
            Pizza pizza = new Pizza(pizzaName);
            return pizza;
        }
    }
}
