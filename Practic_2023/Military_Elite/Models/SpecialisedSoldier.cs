using System.Text;
using Military_Elite.Contracts;
using Military_Elite.Enumerations;
using Military_Elite.Exeptions;
namespace Military_Elite.Models
{
    public abstract class SpecialisedSoldier : Private, IPrivate, ISpecialisedSoldier
    {

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorps(corps);
        }

        public Enum Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;

            if (Enum.TryParse<Corps>(corpsStr, out corps))
            {
                return corps;
            }

            throw new InvalidCorpsExeption();
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine(base.ToString());
            text.AppendLine($"Corps: {this.Corps}");
            return text.ToString().TrimEnd();
        }
    }
}

