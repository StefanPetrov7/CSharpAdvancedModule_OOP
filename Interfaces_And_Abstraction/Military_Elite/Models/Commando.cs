using System.Collections.Generic;
using System.Text;
using System.Linq;

using Military_Elite.Common;
using Military_Elite.Contracts;


namespace Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ISpecialisedSoldier, ICommando, IPrivate
    {
        private Dictionary<string, string> missions;

        public Commando(int iD, string firstName, string lastName, decimal salary, string corps, string[] missionsInput)
            : base(iD, firstName, lastName, salary, corps)
        {
            this.missions = new Dictionary<string, string>();
            this.Missions = AddMissions(missionsInput);
        }

        public Dictionary<string, string> Missions { get; private set; }

        private Dictionary<string, string> AddMissions(string[] missions)
        {
            if (missions == null) return this.missions;

            for (int i = 0; i < missions.Length; i += 2)
            {
                this.missions[missions[i]] = missions[i + 1];
            }
            return this.missions;
        }

        public void CompleteMission(string missionName) => this.Missions[missionName] = GlobalConstants.MISSION_FINISHED;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Missions:");
            foreach (var mission in this.Missions.Where(status => status.Value == GlobalConstants.MISSION_IN_PROGGRES))
            {
                sb.AppendLine($"  Code Name: {mission.Key} State: {mission.Value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
