using System.Collections.Generic;
using System.Text;
using Military_Elite.Common;
using Military_Elite.Contracts;


namespace Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ISpecialisedSoldier, ICommando, IPrivate
    {
        private Dictionary<string, string> missions;
        private string[] missionsInput;

        public Commando(int iD, string firstName, string lastName, decimal salary, string corps, params string[] missions)
            : base(iD, firstName, lastName, salary, corps)
        {
            this.missionsInput = missions;
        }

        public Dictionary<string, string> Missions
        {
            get { return this.missions; }
            private set
            {
                for (int i = 0; i < missionsInput.Length; i += 2)
                {
                    value[missionsInput[i]] = missionsInput[i + 1];
                }
                this.missions = value;
            }
        }

        public void CompleteMission() => this.Missions[missionsInput[0]] = GlobalConstants.MISSION_FINISHED;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"{this.Corps}");
            sb.AppendLine($"Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"Code Name: {mission.Key} State: {mission.Value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
