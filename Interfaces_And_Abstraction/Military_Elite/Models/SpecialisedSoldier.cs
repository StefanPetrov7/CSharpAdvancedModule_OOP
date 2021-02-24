using Military_Elite.Common;
using Military_Elite.Contracts;
using Military_Elite.Exeptions;

namespace Military_Elite.Models
{
    public class SpecialisedSoldier : Soldier, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int iD, string firstName, string lastName, decimal salary, string corps)
            : base(iD, firstName, lastName)
        {
            this.Salary = salary;
            this.corps = corps;
        }

        public decimal Salary { get; private set; }

        public string Corps
        {
            get { return this.corps; }
            private set
            {
                if (value != GlobalConstants.AIR_FORCE || value != GlobalConstants.MARINES)
                {
                    throw new InvalidCorpsException();
                }

                this.corps = value;
            }
        }
    }
}
