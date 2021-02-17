using System;

using Football_Team_Generator.Common;

namespace Football_Team_Generator.Models
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
        private int skillLevel;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.SkillLevel = skillLevel;
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

        private int Endurance
        {
            get { return this.endurance; }
            set
            {
                StatsValidating(value, nameof(Endurance));
                this.endurance = value;
            }
        }

        private int Sprint
        {
            get { return this.sprint; }
            set
            {
                StatsValidating(value, nameof(Sprint));
                this.sprint = value;
            }
        }

        private int Dribble
        {
            get { return this.dribble; }
            set
            {
                StatsValidating(value, nameof(Dribble));
                this.dribble = value;
            }
        }

        private int Passing
        {
            get { return this.passing; }
            set
            {
                StatsValidating(value, nameof(Passing));
                this.passing = value;
            }
        }

        private int Shooting
        {
            get { return this.shooting; }
            set
            {
                StatsValidating(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        public int SkillLevel
        {
            get { return this.skillLevel; }
            private set
            {
                this.skillLevel = GetOveralSkillLevel();
            }
        }

        private void StatsValidating(int value, string param)
        {
            if (value < MIN_STATS || value > MAX_STATS)
            {
                throw new ArgumentException(string.Format(GlobalConstants.INVALID_STATS, param, MIN_STATS, MAX_STATS));
            }
        }

        private int GetOveralSkillLevel() => (int)Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / STATS_COUNT);

    }
}
