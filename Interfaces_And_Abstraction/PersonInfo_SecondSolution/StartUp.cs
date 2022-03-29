using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string END_WHHILE = "End";
            string input;
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var arg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arg.Length == 4)
                {
                    buyers[arg[0]] = (new Citizen(arg[0], int.Parse(arg[1]), arg[2], arg[3]));
                }
                else
                {
                    buyers[arg[0]] = (new Rabel(arg[0], int.Parse(arg[1]), arg[2]));
                }
            }


            while ((input = Console.ReadLine()) != END_WHHILE)
            {
                string name = input;

                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }
            }

            Console.WriteLine(buyers.Values.Sum(x => x.Food));

        }
    }
}
