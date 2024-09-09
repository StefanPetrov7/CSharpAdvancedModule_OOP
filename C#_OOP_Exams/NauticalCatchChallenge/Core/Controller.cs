using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fish;

        public Controller()
        {
            this.divers = new DiverRepository();
            this.fish = new FishRepository();
        }


        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = this.divers.GetModel(diverName);

            if (diver == null)
            {
                return String.Format(OutputMessages.DiverNotFound, this.divers.GetType().Name, diverName);
            }

            IFish curFish = this.fish.GetModel(fishName);

            if (curFish == null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues == true)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }


            if (diver.OxygenLevel < curFish.TimeToCatch)
            {
                diver.Miss(curFish.TimeToCatch);
                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == curFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(curFish);
                    return String.Format(OutputMessages.DiverHitsFish, diverName, curFish.Points, curFish.Name);
                }
                else
                {
                    diver.Miss(curFish.TimeToCatch);
                    return String.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                diver.Hit(curFish);
                return String.Format(OutputMessages.DiverHitsFish, diverName, curFish.Points, curFish.Name);
            }


        }

        public string CompetitionStatistics()
        {
            StringBuilder statistic = new StringBuilder();
            statistic.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in this.divers.Models.Where(x => x.HasHealthIssues == false)
                .OrderByDescending(x => x.CompetitionPoints)
                .ThenByDescending(x => x.Catch.Count)
                .ThenBy(x => x.Name))
            {
                statistic.AppendLine(diver.ToString());
            }

            return statistic.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != typeof(ScubaDiver).Name && diverType != typeof(FreeDiver).Name)
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return String.Format(OutputMessages.DiverNameDuplication, diverName, this.divers.GetType().Name);
            }

            IDiver diver;

            if (diverType == typeof(FreeDiver).Name)
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                diver = new ScubaDiver(diverName);
            }

            this.divers.AddModel(diver);

            return String.Format(OutputMessages.DiverRegistered, diverName, this.divers.GetType().Name);

        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = this.divers.GetModel(diverName);

            StringBuilder report = new StringBuilder();

            report.AppendLine(diver.ToString());
            report.AppendLine("Catch Report:");

            foreach (var fishNAme in diver.Catch) 
            {
                IFish caughtFish = this.fish.GetModel(fishNAme);
                report.AppendLine(caughtFish.ToString());
            }

            return report.ToString().TrimEnd();
        }

        public string HealthRecovery()
        {
            int count = 0;

            foreach (var diver in divers.Models.Where(x => x.HasHealthIssues == true))
            {
                count++;
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            };

            return String.Format(OutputMessages.DiversRecovered, count);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != typeof(PredatoryFish).Name && fishType != typeof(ReefFish).Name && fishType != typeof(DeepSeaFish).Name)
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (this.fish.GetModel(fishName) != null)
            {
                return String.Format(OutputMessages.FishNameDuplication, fishName, this.fish.GetType().Name);
            }

            IFish fish;

            if (fishType == typeof(ReefFish).Name)
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == typeof(PredatoryFish).Name)
            {
                fish = new PredatoryFish(fishName, points);
            }
            else
            {
                fish = new DeepSeaFish(fishName, points);
            }

            this.fish.AddModel(fish);

            return String.Format(OutputMessages.FishCreated, fishName);

        }
    }
}
