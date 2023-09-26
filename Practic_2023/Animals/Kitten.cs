using System;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string FEMALE = "female";

        public Kitten(string name, int age) : base(name, age, FEMALE)
        { }

        public override string ProduceSound()
        {
           return "Meow";
        }
    }
}