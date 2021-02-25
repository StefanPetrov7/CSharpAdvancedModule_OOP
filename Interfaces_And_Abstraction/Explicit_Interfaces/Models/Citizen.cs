using Explicit_Interfaces.Contracts;

namespace Explicit_Interfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        string IPerson.GetName()  // Expilicit call same method with different implementations in different interfaces. 
        {
            return this.Name;
        }

        string IResident.GetName() // Expilicit call same method with different implementations in different interfaces. 
        {
            return "Mr/Ms/Mrs " + this.Name;
        }
    }
}
