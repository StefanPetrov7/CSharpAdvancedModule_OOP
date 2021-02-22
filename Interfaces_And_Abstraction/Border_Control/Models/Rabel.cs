using Border_Control.Contracts;

namespace Border_Control.Models
{
    public class Rabel : IBuyer
    {
        public Rabel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }

        public void BuyFood() => this.Food += 5;
    }
}
