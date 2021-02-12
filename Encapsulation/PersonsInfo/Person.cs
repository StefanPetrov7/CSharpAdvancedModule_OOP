using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        private decimal salary;

        public Person(string first, string last, int age, decimal salary)
        {
            FirstName = first;
            LastName = last;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value < 460M)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age > 30)
            {
                Salary *= (100 + percentage) / 100;
            }
            else
            {
                Salary *= (100 + (percentage / 2)) / 100;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";

        }
    }
}
