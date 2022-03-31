using System;
namespace Military_Elite.Models
{
    public class Repair
    {
        public Repair(string name, string hr)
        {
            this.Name = name;
            this.HoursWorked = hr;
        }

        public string Name { get; private set; }

        public string HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}
