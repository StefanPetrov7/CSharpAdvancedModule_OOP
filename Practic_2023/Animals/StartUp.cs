using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine())!= "Beast!")
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                try
                {
                    switch (input)
                    {
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            Console.WriteLine(cat.ProduceSound());
                            break;
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            Console.WriteLine(dog.ProduceSound());
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            Console.WriteLine(frog.ProduceSound());
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(kitten);
                            Console.WriteLine(kitten.ProduceSound());
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat);
                            Console.WriteLine(tomcat.ProduceSound());
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
