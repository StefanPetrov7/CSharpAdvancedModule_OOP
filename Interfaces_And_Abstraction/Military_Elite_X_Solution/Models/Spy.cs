using System;
using Military_Elite.Contracts;

namespace Military_Elite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int code) : base(id, firstName, lastName)
        {
            this.CodeNumber = code;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCode Number: {this.CodeNumber}";
        }
    }
}
