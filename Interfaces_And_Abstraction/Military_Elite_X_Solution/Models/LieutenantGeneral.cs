using System;
using System.Collections.Generic;
using System.Text;
using Military_Elite.Contracts;

namespace Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new HashSet<Private>();
        }
        public HashSet<Private> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine(base.ToString());
            print.AppendLine($"Privates:");

            foreach (var soldier in this.Privates)
            {
                print.AppendLine($" {soldier}");
            }

            return print.ToString().TrimEnd();
        }
    }
}
