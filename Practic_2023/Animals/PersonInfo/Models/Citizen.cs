using PersonInfo.Contracts;
namespace PersonInfo.Models
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string bd)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = bd;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

    }
}



