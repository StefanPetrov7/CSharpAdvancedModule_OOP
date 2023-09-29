using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new HashSet<Player>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConst.INVALID_NAME);
                }
                this.name = value;
            }
        }

        private IReadOnlyCollection<Player> Players => (IReadOnlyCollection<Player>)this.players;

        public int Rating => this.Players.Count == 0 ? 0 : (int)Math.Round(this.Players.Average(x => x.OveralSkillLEvel));

        public void Add(Player player)
        {
            this.players.Add(player);
        }

        public void Remove(string playerName)
        {
            Player player = this.Players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException(string.Format(GlobalConst.NO_SUCH_PLAYER, playerName, this.Name));
            }

            this.players.Remove(player);  // check if it works for obj check with goingPlayer!!!!!
        }

        public override string ToString() => $"{this.Name} - {this.Rating}";

    }
}

