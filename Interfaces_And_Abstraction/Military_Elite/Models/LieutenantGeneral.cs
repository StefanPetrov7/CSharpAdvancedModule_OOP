using System;
using System.Linq;

using System.Collections.Generic;

using Military_Elite.Contracts;
using System.Text;

namespace Military_Elite.Models
{
    public class LieutenantGeneral : Soldier, ILieutenantGeneral, IPrivate
    {
        private int[] privateIds;

        public LieutenantGeneral(int iD, string firstName, string lastName, decimal salary, params int[] privateIds)
            : base(iD, firstName, lastName)
        {
            this.privateIds = privateIds;
            this.Salary = salary;
            this.Privates = new HashSet<Private>();
        }

        public decimal Salary { get; private set; }

        public HashSet<Private> Privates { get; set; }

        public void AddPrivates(HashSet<Private> privatesList)
        {
            for (int i = 0; i < privateIds.Length; i++)
            {
                Privates.Add(privatesList.Where(x => x.ID == privateIds[i]).FirstOrDefault());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"Privates:");
            sb.AppendLine($"{string.Join(Environment.NewLine, Privates)}");
            return sb.ToString().TrimEnd();
        }
    }
}

