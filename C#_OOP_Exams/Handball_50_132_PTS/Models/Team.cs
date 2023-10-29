using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private readonly IDictionary<string, IPlayer> players;

        public Team(string name)
        {
            this.Name = name;
            this.PointsEarned = 0;
            this.players = new Dictionary<string, IPlayer>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                this.name = value;
            }
        }

        public int PointsEarned { get; private set; }

        public double OverallRating => this.Players.Count > 0 ? this.Players.Average(x => x.Rating) : 0;

        public IReadOnlyCollection<IPlayer> Players => this.players.Values.ToList().AsReadOnly();

        public void Draw()
        {
            this.PointsEarned += 1;
            this.players.Values.FirstOrDefault(x => x.GetType().Name == "Goalkeeper").IncreaseRating();
        }

        public void Lose()
        {
            this.players.Values.ToList().ForEach(x => x.DecreaseRating());
        }

        public void SignContract(IPlayer player)
        {
            this.players[player.Name] = player;
        }

        public void Win()
        {
            this.PointsEarned += 3;
            this.players.Values.ToList().ForEach(x => x.IncreaseRating());
        }

        public override string ToString()
        {
            string players = this.players.Values.Count > 0 ? string.Join(", ", this.players.Values.Select(x => x.Name)) : "none";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");

            if (players == "none")
            {
                sb.AppendLine($"--Overall rating: 0");
            }
            else
            {
                sb.AppendLine($"--Overall rating: {this.OverallRating:f1}");

            }

            sb.AppendLine($"--Players: {players}");
            return sb.ToString().TrimEnd();
        }
    }
}

