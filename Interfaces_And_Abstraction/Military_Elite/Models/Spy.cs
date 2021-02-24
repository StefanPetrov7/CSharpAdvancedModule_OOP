using System.Text;

using Military_Elite.Contracts;

namespace Military_Elite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int iD, string firstName, string lastName, int codeNumber) : base(iD, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
