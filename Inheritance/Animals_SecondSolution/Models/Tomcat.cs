using System;

namespace Animals.Models
{
    public class Tomcat: Cat
    {
        private const string GENDER_MALE = "Male";

        public Tomcat(string name, int age): base(name, age, GENDER_MALE)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
