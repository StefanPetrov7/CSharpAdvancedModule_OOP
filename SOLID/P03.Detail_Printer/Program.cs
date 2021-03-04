using System;
using System.Collections.Generic;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> doc = new List<string> { "one", "two", "three" };
            List<IEmployee> emplyees = new List<IEmployee>();
            IEmployee Stefan = new Employee("Stefan");
            IEmployee Ivan = new Employee("Ivan");
            IEmployee Anton = new Manager("Anton",  doc);
            emplyees.Add(Stefan);
            emplyees.Add(Ivan);
            emplyees.Add(Anton);

            foreach (var person in emplyees)
            {
                Console.WriteLine(person);
            }
        }
    }
}
