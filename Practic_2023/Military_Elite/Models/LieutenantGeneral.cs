using System.Linq;
using System.Text;
using Military_Elite.Contracts;
namespace Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral, IPrivate
    {
        private string[] ids;
        private ICollection<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, params string[] ids)
            : base(id, firstName, lastName, salary)
        {
            this.ids = ids;
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<Private> Privates => (IReadOnlyCollection<Private>)this.privates;

        public void GetPrivates(ICollection<ISoldier> privates) 
        {
            foreach (var priv in privates)
            {
                if (this.ids.Contains(priv.Id))
                {
                    this.privates.Add(priv as Private);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine(base.ToString());
            text.AppendLine("Privates:");

            if (this.Privates.Count > 0)
            {
                foreach (var @private in this.Privates.OrderByDescending(x=>x.Salary))
                {
                    text.AppendLine($"  {@private.ToString()}");
                }
            }

            return text.ToString().TrimEnd();
        }
    }
}

