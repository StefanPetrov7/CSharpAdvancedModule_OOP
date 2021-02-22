using Border_Control.Contracts;
namespace Border_Control.Models
{
    public class Pet : IBirthdays
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }

    }
}
