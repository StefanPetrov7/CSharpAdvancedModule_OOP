using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;

        private int age;

        private string gender;


        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                age = value;

            }
        }

        public virtual string Gender
        {
            get { return gender; }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }

                gender = value;
            }
        }

        public abstract string ProduceSound();


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{GetType().Name}");
            result.AppendLine($"{Name} {Age} {Gender}");
            result.Append(ProduceSound());
            return result.ToString();
        }
    }
}
