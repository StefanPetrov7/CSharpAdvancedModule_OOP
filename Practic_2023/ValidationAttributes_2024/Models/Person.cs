using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age; 
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(minValue: 12, maxValue: 90)]
        public int Age { get; set; }
    }
}
