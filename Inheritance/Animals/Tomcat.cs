using System;
namespace Animals
{
    public class Tomcat : Cat
    {
        private const string gender = "male";

        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string Gender
        {
            get { return gender; }
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
