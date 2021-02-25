using System.Collections.Generic;
using System.Text;
using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        // We use IPrivate to increase abstr. level. This is how all interfaces under IPrivate can be add to that collection.

        private ICollection<ISoldier> privates;

        public LieutenantGeneral(int iD, string firstName, string lastName, decimal salary)
            : base(iD, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        // (IReadOnlyCollection<IPrivate>)this.privates; => manual cast.

        public IReadOnlyCollection<ISoldier> Privates
            => (IReadOnlyCollection<ISoldier>)this.privates;

        public void AddPrivate(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Privates:");
            foreach (var priv in this.Privates)
            {
                sb.AppendLine($"  {priv}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
