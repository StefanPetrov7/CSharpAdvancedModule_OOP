using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value.ToLower() != "male" && value.ToLower() != "female" && value.ToLower() == null)
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"{this.GetType().Name}");
            text.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            return text.ToString().TrimEnd();
        }
    }
}