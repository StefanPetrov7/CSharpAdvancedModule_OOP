using System.Collections.Generic;
using System.Linq;
using System.Text;

using Military_Elite.Contracts;

namespace Military_Elite.Models
{
    public class LieutenantGeneral : Soldier, ILieutenantGeneral, IPrivate
    {

        public LieutenantGeneral(int iD, string firstName, string lastName, decimal salary)
            : base(iD, firstName, lastName)
        {
            this.Salary = salary;
            this.Privates = new HashSet<Private>();
        }

        public decimal Salary { get; private set; }

        public HashSet<Private> Privates { get; private set; }

        public void AddPrivates(HashSet<Private> privatesList, string[] privateIds)
        {
            for (int i = 0; i < privateIds.Length; i++)
            {
                this.Privates.Add(privatesList.FirstOrDefault(x => x.ID == int.Parse(privateIds[i])));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"Privates:");
            foreach (var priv in this.Privates)
            {
                sb.AppendLine($"  {priv}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

