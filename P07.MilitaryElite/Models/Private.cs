using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int iD, string firstName, string lastName, decimal salary) : base(iD, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:f2}";
        }

    }
}
