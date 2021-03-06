using System;
using Practice.Contracts;

namespace Practice.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hrWorked)
        {
            this.PartName = partName;
            this.HrWorked = hrWorked;
        }

        public string PartName { get; private set; }

        public int HrWorked { get; private set; }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.HrWorked}";
        }
    }
}
