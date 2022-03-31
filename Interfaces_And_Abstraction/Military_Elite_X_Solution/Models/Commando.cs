using System;
using System.Collections.Generic;
using Military_Elite.Contracts;
using System.Linq;
using Military_Elite.Enumerations;
using System.Text;

namespace Military_Elite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string strCorps, params string[] missions)
             : base(id, firstName, lastName, salary, strCorps)
        {
            GetMissions(missions);
        }

        public IReadOnlyCollection<Mission> Missions => (IReadOnlyCollection<Mission>)this.missions;

        private void GetMissions(string[] missionsArr)
        {
            this.missions = new HashSet<Mission>();

            for (int i = 0; i < missionsArr.Length; i += 2)
            {
                try
                {
                    this.missions.Add(new Mission(missionsArr[i], missionsArr[i + 1]));
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        public void CompleteMission()
        {
            foreach (var mission in this.Missions)
            {
                mission.MissionProgress = Progress.Finished;
            }
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            print.AppendLine(base.ToString());
            print.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                print.AppendLine($" {mission}");
            }

            return print.ToString().TrimEnd();
        }
    }
}
