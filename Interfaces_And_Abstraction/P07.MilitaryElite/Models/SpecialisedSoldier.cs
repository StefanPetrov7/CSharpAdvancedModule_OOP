using System;
using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Enumerations;
using P07.MilitaryElite.Exceptions;

namespace P07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int iD, string firstName, string lastName, decimal salary, string corps)
            : base(iD, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);  // Using our TryParseCorps method to parse the input.
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;  // Enumeration Corps corp is empty and will be parsed if possible/
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalideCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}"; 
        }
    }
}
