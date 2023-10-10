using Military_Elite.Contracts;
using Military_Elite.Exeptions;
using Military_Elite.Enumerations;
using System.Text;

namespace Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ISpecialisedSoldier, ICommando
    {
        private ICollection<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, params string[] missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = GetMissions(missions); 
        }

        public IReadOnlyCollection<Mission> Missions => (IReadOnlyCollection<Mission>)this.missions;

        private ICollection<Mission> GetMissions(string[] missions)
        {
            List<Mission> result = new List<Mission>();

            for (int i = 0; i < missions.Length; i += 2)
            {
                try
                {
                    State curState;

                    if (Enum.TryParse<State>(missions[i + 1], out curState))
                    {
                        result.Add(new Mission(missions[i], curState));
                    }
                    else
                    {
                        throw new InvalidMissionState();
                    }

                }
                catch (InvalidMissionState)
                {
                   
                }

            }

            return result;  

        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine(base.ToString());
            text.AppendLine("Missions:");

            if (this.Missions.Count > 0)
            {
                foreach (var mission in this.Missions)
                {
                    text.AppendLine(mission.ToString());
                }
            }
            return text.ToString().TrimEnd();
        }
    }
}

