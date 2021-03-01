using System;
using System.Collections.Generic;
using System.Linq;


using Wild_Farm.Contracts;
using Wild_Farm.Factory;
using Wild_Farm.Models;

namespace Wild_Farm.Core
{
    public class Engine : IEngine
    {
        private const string END_INPUT = "End";
        IWriter writer;
        IReader reader;
        ICollection<Animal> animals;
        AnimalFactory animalFactory = new AnimalFactory();
        FoodFactory foodFactory = new FoodFactory();

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != END_INPUT)
            {
                string[] argsAnimal = input.Split(" ");
                string[] argsFood = reader.ReadLine().Split(" ");
                Food food = foodFactory.GetFood(argsFood);
                Animal animal = animalFactory.GetAnimal(argsAnimal);
                writer.WriteLine(animal.ProduceSound());
                animal.Eat(food);
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
