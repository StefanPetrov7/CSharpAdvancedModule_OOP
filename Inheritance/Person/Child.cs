using System;

namespace Person
{
    public class Child : Person
    {

        public Child(string name, int age) : base(name, age)
        {
        }

        public override int Age  // Override base behavior to verify if teh age in correct.
        {
            get { return base.Age; }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Age must be less than 16");
                }

                base.Age = value;
            }
        }
    }
}
