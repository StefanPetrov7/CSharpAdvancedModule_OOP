using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Practice.Contracts;

namespace Practice.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new HashSet<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => (IReadOnlyCollection<IPrivate>)this.privates;

        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Privates:");
            foreach (var priv in this.Privates.OrderByDescending(x=>x.Salary))
            {
                sb.AppendLine($"  {priv}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
