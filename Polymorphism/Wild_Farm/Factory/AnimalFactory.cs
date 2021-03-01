using System;
using Wild_Farm.Models;
using Wild_Farm.Common;
using Wild_Farm.Contracts;

namespace Wild_Farm.Factory
{
    public class AnimalFactory
    {
        public Animal GetAnimal(string[] args)
        {
            string type = args[0];
            Animal animal = null;

            if (type == typeof(Cat).Name)
            {
                animal = new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
            }
            else if (type == typeof(Tiger).Name)
            {
                animal = new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
            }
            else if (type == typeof(Mouse).Name)
            {
                animal = new Mouse(args[1], double.Parse(args[2]), args[3]);
            }
            else if (type == typeof(Dog).Name)
            {
                animal = new Dog(args[1], double.Parse(args[2]), args[3]);
            }
            else if (type == typeof(Hen).Name)
            {
                animal = new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
            }
            else if (type == typeof(Owl).Name)
            {
                animal = new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
            }

            return animal;

        }
    }
}
