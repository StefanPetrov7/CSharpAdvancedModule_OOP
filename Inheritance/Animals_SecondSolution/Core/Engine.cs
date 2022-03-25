using System;
using System.Collections.Generic;
using System.Linq;
using Animals.Models;

namespace Animals.Core
{
    public class Engine
    {
        private const string END_WHILE = "Beast!";

        private readonly ICollection<Animal> animals;

        public Engine()
        {
            this.animals = new HashSet<Animal>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != END_WHILE)
            {
                string animalType = input;
                var arg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal = null;
                try
                {
                    switch (animalType)
                    {
                        case "Cat":
                            animal = new Cat(arg[0], int.Parse(arg[1]), arg[2]);
                            break;
                        case "Dog":
                            animal = new Dog(arg[0], int.Parse(arg[1]), arg[2]);
                            break;
                        case "Frog":
                            animal = new Frog(arg[0], int.Parse(arg[1]), arg[2]);
                            break;
                        case "Kitten":
                            animal = new Kitten(arg[0], int.Parse(arg[1]));
                            break;
                        case "Tomacat":
                            animal = new Tomcat(arg[0], int.Parse(arg[1]));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
                if (animal != null)
                {
                    animals.Add(animal);
                }
            }

            animals.ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
