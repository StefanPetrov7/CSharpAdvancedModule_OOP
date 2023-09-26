using System;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string MALE = "male";

        public Tomcat(string name, int age) : base(name, age, MALE)
        { }

        public override string ProduceSound()
        {
            return "MEOW";
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"{this.GetType().Name}");
            text.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            text.AppendLine(this.ProduceSound());
            return text.ToString().TrimEnd();
        }
    }
}

