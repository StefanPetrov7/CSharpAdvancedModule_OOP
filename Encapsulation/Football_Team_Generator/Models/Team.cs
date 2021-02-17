using System;
using System.Collections.Generic;
using System.Linq;

using Football_Team_Generator.Common;

namespace Football_Team_Generator.Models
{
    public class Team
    {

        private string name;
        private readonly ICollection<Player> players;

        public Team()
        {
            this.players = new HashSet<Player>();
        }

        public Team(string name) : this()
        {
            this.Name = name;
        }
            
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_NAME);
                }
                this.name = value;
            }
        }

        public int Rating => Players.Count > 0 ? (int)Math.Round(Players.Average(p => p.SkillLevel)) : 0;

        public IReadOnlyCollection<Player> Players
        {
            get => (IReadOnlyCollection<Player>)this.players;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(GlobalConstants.NO_SUCH_PLAYER, name, this.Name));
            }

            players.Remove(playerToRemove);
        }

        public override string ToString() => $"{this.Name} - {this.Rating}";

    }
}
