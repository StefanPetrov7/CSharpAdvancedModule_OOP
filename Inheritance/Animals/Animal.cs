using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string ERROR_MESSAGE = "Invalid input!";

        private string name;

        private int age;

        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }
                this.age = value;
            }
        }

        public virtual string Gender
        {
            get { return this.gender; }
            private set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException(ERROR_MESSAGE);
                }

                this.gender = value;
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
