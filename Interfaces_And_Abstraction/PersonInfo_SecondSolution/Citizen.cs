using System;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable, IBuyer
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Food = 0;
        }

        public Citizen(string name, int age, string id, string birthdate) : this(name, age, id)
        {
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
