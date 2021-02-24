using System;

using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int iD, string firstName, string lastName, int code)
            : base(iD, firstName, lastName)
        {
            this.CodeNumber = code;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Code Number: { this.CodeNumber}";
        }
    }
}
