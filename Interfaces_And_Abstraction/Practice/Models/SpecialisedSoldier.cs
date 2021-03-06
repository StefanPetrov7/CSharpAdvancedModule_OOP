using System;
using Practice.Contracts;
using Practice.Enumerations;
using Practice.Exceptions;

namespace Practice.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corpsStr)
            : base( id,  firstName,  lastName,  salary)
        {
            this.Corps = TryParseCorps(corpsStr);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;
            bool isParse = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!isParse)
            {
                throw new InvalideCorps();
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
