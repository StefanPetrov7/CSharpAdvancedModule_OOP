using System;
using System.Text;

namespace Animals.Models
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        private const string GENDER_MALE = "male";
        private const string GENDER_FEMALE = "female";
        private const string INVALID_INPUT = "Invalid input!";

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(INVALID_INPUT);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(INVALID_INPUT);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;

            private set
            {
                if (value.ToLower() != GENDER_FEMALE && value.ToLower() != GENDER_MALE)
                {
                    throw new ArgumentException(INVALID_INPUT);
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();
   
        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine($"{this.GetType().Name}");
            print.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            print.AppendLine($"{this.ProduceSound()}");
            return print.ToString().TrimEnd();
        }
    }
}
