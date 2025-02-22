using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;


namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private string _name;
        private double _ranking;
        protected const double MIN_RANKING = 0;
        protected const double MAX_RANKING = 100;

        protected Manager(string name, double ranking)
        {
            this.Name = name;
            this.Ranking = ranking;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                _name = value;
            }
        }

        public double Ranking
        {
            get
            {
                return _ranking;
            }
            protected set
            {
                _ranking = value;
            }
        }

        public virtual void RankingUpdate(double number)  
        {
            this.Ranking += number;

            if (this.Ranking > MAX_RANKING)
                this.Ranking = MAX_RANKING;
            else if (this.Ranking < MIN_RANKING)
                this.Ranking = MIN_RANKING;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";
        }

    }
}
