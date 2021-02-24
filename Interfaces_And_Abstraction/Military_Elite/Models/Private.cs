using System.Text;

using Military_Elite.Contracts;

namespace Military_Elite.Models
{
    public class Private : Soldier, IPrivate
    {

        public Private(int iD, string firstName, string lastName, decimal salary) : base(iD, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
