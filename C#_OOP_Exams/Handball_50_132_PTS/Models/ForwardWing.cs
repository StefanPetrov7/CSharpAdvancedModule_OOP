using System;
namespace Handball.Models
{
	public class ForwardWing : Player
	{
        private const double initial_Raiting = 5.5;
        private const int MAX_RAITING = 10;
        private const int MIN_RAITING = 1;
        private const double INCREASE_RAITING_VALUE = 1.25;
        private const double DECREASE_RAITING_VALUE = 0.75;

        public ForwardWing(string name) : base(name, initial_Raiting)
        { }

        public override void DecreaseRating()
        {
            this.Rating -= DECREASE_RAITING_VALUE;

            if (this.Rating < MIN_RAITING)
            {
                this.Rating = MIN_RAITING;
            }
        }

        public override void IncreaseRating()
        {
            this.Rating += INCREASE_RAITING_VALUE;

            if (this.Rating > MAX_RAITING)
            {
                this.Rating = MAX_RAITING;
            }
        }
    }
}

