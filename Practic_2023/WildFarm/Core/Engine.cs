using WildFarm.Factory;
using WildFarm.Contracts;
using WildFarm.Models;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        private IReader reader = null;
        private IWriter writer = null;
        private List<string[]> matrixInfo;
        private List<Animal> animals;

        private const string STOP_PROGRAM = "End";

        public Engine()
        {
            this.matrixInfo = new List<string[]>();
            this.animals = new List<Animal>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void RunAnimals()
        {
            string input;

            while ((input = reader.Read()) != STOP_PROGRAM)
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                this.matrixInfo.Add(info);
            }

            for (int r = 0; r < matrixInfo.Count; r += 2)
            {
                string[] animalData = this.matrixInfo[r];
                string[] foodData = this.matrixInfo[r + 1];
                string foodType = foodData[0];
                int qty = int.Parse(foodData[1]);

                try
                {
                    Animal animal = AnimalFactory.GetAnimal(animalData);
                    Food food = FoodFactory.GetFood(foodType, qty);
                    this.animals.Add(animal);
                    writer.WriteLine(animal.Sound());
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            this.animals.ForEach(x => writer.WriteLine(x.ToString()));
        }
    }
}

