using System;

namespace Animals.Models
{
    public class Kitten : Cat
    {
        private const string GENDER_FEMALE = "Female";

        public Kitten(string name, int age) : base(name, age, GENDER_FEMALE)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
