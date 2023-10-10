using Military_Elite.Contracts;
namespace Military_Elite.Models
{
    public class Spy : Soldier, ISoldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nCode Number: {this.CodeNumber}";
        }
    }
}

