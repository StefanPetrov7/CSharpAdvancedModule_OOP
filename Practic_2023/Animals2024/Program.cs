using Polymorphism;
using Polymorphism.Contracts;
using Polymorphism.Models;
using System.Runtime.CompilerServices;

public class Program
{

    // JUDGE ONLY 80 PTS RUN TIME ERROR

    public static void Main()
    {
        List<IAnimal> animals = new List<IAnimal>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(" ");
            animals.Add(CreateAnimal(tokens));
            tokens = Console.ReadLine().Split(" ");
            Food food = CreateFood(tokens);
            FeedAnimal(animals[animals.Count - 1], food);
        }

        animals.ForEach(x => Console.WriteLine(x.ToString()));
    }

    public static Food CreateFood(string[] tokens)
    {
        string type = tokens[0];

        Food food = type switch
        {
            "Fruit" => new Fruit(int.Parse(tokens[1])),
            "Meat" => new Meat(int.Parse(tokens[1])),
            "Seeds" => new Seeds(int.Parse(tokens[1])),
            "Vegetable" => new Vegetable(int.Parse(tokens[1])),
            _ => throw new InvalidOperationException("Not valid food type")
        };

        return food;
    }

    public static void FeedAnimal(IAnimal animal, Food food)
    {
        if (animal.EatFood(food) == false)
        {
            Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }

    public static IAnimal CreateAnimal(string[] tokens)
    {
        string type = tokens[0];

        IAnimal animal = type switch
        {
            "Cat" => new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]),
            "Dog" => new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]),
            "Hen" => new Hen(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3])),
            "Mouse" => new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]),
            "Owl" => new Owl(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3])),
            "Tiger" => new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]),
            _ => throw new InvalidOperationException("Not valid animal type")
        };

        Console.WriteLine(animal.ProduceSound());
        return animal;
    }
}