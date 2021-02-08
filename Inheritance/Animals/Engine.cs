using System;
using System.Collections.Generic;

namespace Animals
{
    public class Engine
    {
        private const string END_OF_INPUT_CMD = "Beast!";

        private readonly List<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }

        public void Run()
        {
            string type;

            while ((type = Console.ReadLine()) != END_OF_INPUT_CMD)
            {
                string[] animalArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal;

                try
                {
                    animal = GetAnimal(type, animalArg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                animals.Add(animal);

            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private Animal GetAnimal(string type, string[] animalArg)
        {
            string name = animalArg[0];
            int age = int.Parse(animalArg[1]);
            string gender = null;

            if (animalArg.Length == 3)
            {
                gender = animalArg[2];
            }

            Animal animal = null;

            switch (type)
            {
                case "Dog":
                    animal = new Dog(name, age, gender);
                    break;
                case "Cat":
                    animal = new Cat(name, age, gender);
                    break;
                case "Frog":
                    animal = new Frog(name, age, gender);
                    break;
                case "Tomacat":
                    animal = new Tomcat(name, age);
                    break;
                case "Kitten":
                    animal = new Kitten(name, age);
                    break;
                default:
                    throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
