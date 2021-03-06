using System;
using System.Collections.Generic;
using System.Text;
using Practice.Contracts;

namespace Practice.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corpsStr)
            :base( id,  firstName,  lastName,  salary,  corpsStr)
        {
            this.repairs = new HashSet<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine(repair.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
