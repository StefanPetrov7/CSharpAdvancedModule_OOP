using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        private string _name;
        private int _championshipPoints;
        private IManager _manager;


        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                _name = value;
            }
        }



        public int ChampionshipPoints
        {
            get
            {
                return this._championshipPoints;
            }
            private set
            {
                this._championshipPoints = value;
            }
        }

        public IManager TeamManager
        {
            get
            {
                return this._manager;
            }
            private set
            {
                this._manager = value;
            }
        }

        public int PresentCondition
        {
            get
            {
                if (this.TeamManager == null)
                    return 0;
                else if (this.ChampionshipPoints == 0)
                    return (int)Math.Floor(this.TeamManager.Ranking);
                else
                    return (int)Math.Floor(this.ChampionshipPoints * this.TeamManager.Ranking);
            }
        }

        public void GainPoints(int points)
        {
            this._championshipPoints += points;
        }

        public void ResetPoints()
        {
            this._championshipPoints = 0;
        }

        public void SignWith(IManager manager)
        {
            this._manager = manager;
        }

        public override string ToString()
        {
            return $"Team: {this.Name} Points: {this.ChampionshipPoints}";
        }
    }
}
