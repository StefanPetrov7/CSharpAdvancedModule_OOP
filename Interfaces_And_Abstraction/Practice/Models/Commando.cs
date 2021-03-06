using System;
using System.Collections.Generic;
using System.Text;
using Practice.Contracts;
using Practice.Enumerations;

namespace Practice.Models
{
    public class Commando: SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corpsStr)
            : base( id,  firstName,  lastName,  salary,  corpsStr)
        {
            this.missions = new HashSet<IMission>();
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
