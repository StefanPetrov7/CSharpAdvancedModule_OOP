using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string? name;
        private int oxygenLevel;
        private ICollection<string> catchCollection;
        private double competitionPoints;
        private bool hasHealthIssues;
        public Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this.catchCollection = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DiversNameNull));
                }

                this.name = value;
            }
        }

        public int OxygenLevel
        {
            get
            {
                return this.oxygenLevel;
            }
            protected set
            {
                if (value <= 0)
                {
                    this.HasHealthIssues = true;
                    this.oxygenLevel = 0;
                }
                else
                {
                    this.oxygenLevel = value;
                }
            }
        }

        public IReadOnlyCollection<string> Catch => (IReadOnlyCollection<string>)this.catchCollection;

        public double CompetitionPoints => this.competitionPoints;

        public bool HasHealthIssues
        {
            get
            {
                return this.hasHealthIssues;
            }
            set
            {
                this.hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this.catchCollection.Add(fish.Name);
            this.competitionPoints = Math.Round(this.competitionPoints + fish.Points, 1);
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            this.HasHealthIssues = !this.HasHealthIssues;
        }

        public override string ToString() => $"Diver [ Name: {this.Name}, Oxygen left: {this.OxygenLevel}, Fish caught: {this.Catch.Count}, Points earned: {this.CompetitionPoints} ]";

    }
}
