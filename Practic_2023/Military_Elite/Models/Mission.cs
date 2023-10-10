using Military_Elite.Enumerations;
namespace Military_Elite.Models
{
    public class Mission
    {
        public Mission(string name, State state)
        {
            this.Name = name;
            this.State = state;
        }

        public string Name { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"  Code Name: {this.Name} State: {this.State}";
        }
    }
}

