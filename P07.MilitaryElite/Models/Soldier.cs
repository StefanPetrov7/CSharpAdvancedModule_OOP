using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int iD, string firstName, string lastName) // We use protected in order to be Inherited.
        {
            this.Id = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
