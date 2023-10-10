using System.Text;
using Military_Elite.Contracts;
using Military_Elite.Enumerations;
namespace Military_Elite.Models
{
    public class Engineer : SpecialisedSoldier, IPrivate, ISpecialisedSoldier, IEngineer
    {
        private ICollection<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, params string[] repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = GetRepairs(repairs);
        }

        public IReadOnlyCollection<Repair> Repairs => (IReadOnlyCollection<Repair>)this.repairs;

        private ICollection<Repair> GetRepairs(string[] repairs)
        {
            List<Repair> result = new List<Repair>();

            for (int i = 0; i < repairs.Length; i += 2)
            {
                result.Add(new Repair(repairs[i], int.Parse(repairs[i + 1])));
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine(base.ToString());
            text.AppendLine("Repairs:");

            if (this.Repairs.Count > 0)
            {
                foreach (var repair in this.Repairs)
                {
                    text.AppendLine(repair.ToString());
                }
            }

            return text.ToString().TrimEnd();
        }
    }
}

