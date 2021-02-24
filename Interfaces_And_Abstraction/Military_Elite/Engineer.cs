using System.Collections.Generic;
using System.Text;

using Military_Elite.Contracts;
using Military_Elite.Models;

namespace Military_Elite
{
    public class Engineer : SpecialisedSoldier, IPrivate, IEngineer
    {
        private Dictionary<string, int> repairs;

        public Engineer(int iD, string firstName, string lastName, decimal salary, string corps, string[] repairsInput)
            : base(iD, firstName, lastName, salary, corps)
        {
            this.repairs = new Dictionary<string, int>();
            this.Repairs = AddRepairs(repairsInput);
        }

        public Dictionary<string, int> Repairs { get; private set; }

        private Dictionary<string, int> AddRepairs(string[] repairsInput)
        {
            if (repairsInput == null) return this.repairs;

            for (int i = 0; i < repairsInput.Length; i += 2)
            {
                this.repairs[repairsInput[i]] = int.Parse(repairsInput[i + 1]);
            }
            return this.repairs;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  Part Name: {repair.Key} Hours Worked: {repair.Value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
