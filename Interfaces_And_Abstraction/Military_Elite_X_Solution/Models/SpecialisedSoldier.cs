using System;
using Military_Elite.Contracts;
using Military_Elite.Enumerations;
using Military_Elite.Validators;

namespace Military_Elite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string strCorps)
            : base(id, firstName, lastName, salary)
        {
            this.Corp = EnumValidator.ValidateCorps(strCorps);
        }

        public Corps Corp { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {this.Corp}";
        }
    }
}
