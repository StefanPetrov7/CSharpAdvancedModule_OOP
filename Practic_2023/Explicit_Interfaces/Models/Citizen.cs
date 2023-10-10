using Explicit_Interfaces.Contracts;
namespace Explicit_Interfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        public string GetName()
        {
            return this.Name;
        }

        string IResident.GetName() //  Expilicit call same method with different implementations in different interfaces. 
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}

