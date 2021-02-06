using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    AddAnimal(animals, input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static void AddAnimal(List<Animal> animals, string input)
        {
            string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = info[0];
            int age = int.Parse(info[1]);
            string gender = info[2];

            switch (input)
            {
                case "Cat":
                    try
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "Dog":
                    try
                    {
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "Frog":
                    try
                    {
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "Kitten":
                    try
                    {
                        Kitten kitten = new Kitten(name, age, gender);
                        animals.Add(kitten);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "Tomcat":
                    try
                    {
                        Tomcat tomcat = new Tomcat(name, age, gender);
                        animals.Add(tomcat);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        }
    }
}
