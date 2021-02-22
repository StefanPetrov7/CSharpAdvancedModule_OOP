using Border_Control.Contracts;

namespace Border_Control.Models
{
    public class Human : IIdNumerable, IBirthdays , IBuyer
    {

        public Human(string name, int age, long iD)
        {
            this.Name = name;
            this.Age = age;
            this.ID = iD;
        }

        public Human(string name, int age, long iD, string birthday) : this(name, age, iD)
        {
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public long ID { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; }

        public void BuyFood() => this.Food += 10;

    }
}
