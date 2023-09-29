using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
	public class Player
	{
        private const int MIN_STATS = 0;
        private const int MAX_STATS = 100;
        private const double STATS_COUNT = 5;

        private string name;
		private int endurance;
		private int sprint;
		private int dribble;
        private int passing;
        private int shooting;

		public Player(string name, int endurance, int sprint, int dribble,int passing, int shooting)
		{
			this.Name = name;
			this.Endurance = endurance;
			this.Sprint = sprint;
			this.Dribble = dribble;
            this.Passing = passing;
			this.Shooting = shooting;
		}

		public string Name
		{
			get => this.name;
			private set
			{
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConst.INVALID_NAME);
                }

                this.name = value;
            }
		}

		public int Endurance
		{
			get => this.endurance;
			private set
			{
                StatsValidating(value, nameof(Endurance));
                this.endurance = value;
            }
		}

		public int Sprint
        {
            get => this.sprint;
            private set
            {
                StatsValidating(value, nameof(Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                StatsValidating(value, nameof(Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                StatsValidating(value, nameof(Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                StatsValidating(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        public int OveralSkillLEvel =>(int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Shooting + this.Passing) / STATS_COUNT);

        private void StatsValidating(int value, string param)
        {
            if (value < MIN_STATS || value > MAX_STATS)
            {
                throw new ArgumentException(string.Format(GlobalConst.INVALID_STATS, param, MIN_STATS, MAX_STATS));
            }
        }
    }
}

