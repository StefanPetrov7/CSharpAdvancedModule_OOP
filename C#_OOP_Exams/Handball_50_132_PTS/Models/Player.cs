using System;
using System.Text;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;

        public Player(string name, double raiting)
        {
            this.Name = name;
            this.Rating = raiting;
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

        public double Rating { get; private protected set; }

        public string Team { get; private set; }

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();

        public void JoinTeam(string name) => this.Team = name;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {this.Rating}");
            return sb.ToString().TrimEnd();
        }
    }
}

