using System;
using System.Text;

using Military_Elite.Models;
using Military_Elite.Contracts;
using System.Collections.Generic;

namespace Military_Elite
{
    public class Engineer : SpecialisedSoldier, IPrivate, IEngineer
    {
        private Dictionary<string, int> repairs;
        private string[] dataRepairs;

        public Engineer(int iD, string firstName, string lastName, decimal salary, string corps, params string[] repairs)
            : base(iD, firstName, lastName, salary, corps)
        {
            this.dataRepairs = repairs;
        }

        public Dictionary<string, int> Repairs
        {
            get { return this.repairs; }
            private set
            {
                for (int i = 0; i < dataRepairs.Length; i += 2)
                {
                    value[dataRepairs[i]] = int.Parse(dataRepairs[i]);
                }

                this.repairs = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"{this.Corps}");
            sb.AppendLine($"Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"Part Name: {repair.Key} Hours Worked: {repair.Value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
