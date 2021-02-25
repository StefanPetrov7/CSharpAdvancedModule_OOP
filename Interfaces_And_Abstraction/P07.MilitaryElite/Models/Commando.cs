using System.Collections.Generic;
using System.Text;
using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.Models
{
    public class Commando: SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int iD, string firstName, string lastName, decimal salary, string corps)
            : base( iD,  firstName,  lastName,  salary,  corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine(mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
