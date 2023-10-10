using Explicit_Interfaces.Contracts;
using Explicit_Interfaces.Models;

namespace Explicit_Interfaces.Core
{
    public class Engine
    {
        private ICollection<Citizen> persons;

        public Engine()
        {
            this.persons = new List<Citizen>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);
                this.persons.Add(new Citizen(name, country, age));
            }

            foreach (var citizen in this.persons)
            {
                IResident resident = citizen;
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}

