using System;
namespace Animals
{
    public class Kitten : Cat
    {
        private const string gender = "female";

        public Kitten(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string Gender
        {
            get { return gender; }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}

