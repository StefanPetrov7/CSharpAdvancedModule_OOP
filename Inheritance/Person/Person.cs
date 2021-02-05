using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual int Age  // We use virtual because more verifications will be done in inherited classes.
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Name: {0}, Age: {1}", this.name, this.age));
            return output.ToString();
        }
    }
}
