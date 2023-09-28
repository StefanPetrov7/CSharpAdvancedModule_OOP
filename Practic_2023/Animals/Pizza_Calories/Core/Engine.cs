
using Pizza_Calories.Models;

namespace Pizza_Calories.Core
{
    public class Engine
    {
        public void MakePizza()
        {
            try
            {
                string[] pizzaData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] doughtData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Pizza pizza = new Pizza(pizzaData[1]);
                Dough dough = new Dough(doughtData[1], doughtData[2], int.Parse(doughtData[3]));

                pizza.Dough = dough;

                string input;

                while ((input = Console.ReadLine()) != "END")
                {

                    string[] topData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    Topping topping = new Topping(topData[1], int.Parse(topData[2]));
                    pizza.AddTopping(topping);

                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

