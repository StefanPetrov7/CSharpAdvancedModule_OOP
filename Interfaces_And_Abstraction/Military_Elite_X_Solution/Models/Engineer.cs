using System;
using System.Collections.Generic;
using System.Text;
using Military_Elite.Contracts;

namespace Military_Elite.Models
{
    public class Engineer : SpecialisedSoldier, ISpecialisedSoldier, IEngineer
    {
        private ICollection<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string strCorps, params string[] repairs)
            : base(id, firstName, lastName, salary, strCorps)
        {
            GetRepairs(repairs);
        }

        public IReadOnlyCollection<Repair> Repairs => (IReadOnlyCollection<Repair>)this.repairs;

        private void GetRepairs(string[] repairsArr)
        {
            this.repairs = new HashSet<Repair>();

            for (int i = 0; i < repairsArr.Length; i += 2)
            {
                this.repairs.Add(new Repair(repairsArr[i], repairsArr[i + 1]));
            }
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine(base.ToString());
            print.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                print.AppendLine($" {repair}");
            }

            return print.ToString().TrimEnd();
        }
    }
}
