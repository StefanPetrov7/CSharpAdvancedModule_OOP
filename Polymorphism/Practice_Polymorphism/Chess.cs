namespace Practice_Polymorphism
{
    public class Chess : TwoPlayerGame
    {
        private bool isWhitePlaying; // Encapsulation => games are vissible inly in this class.

        public Chess(Player pone, Player ptwo) : base(pone, ptwo)
        {

        }

        public override string GetDiscription() // Abstract implementation in the iherited classes.
        {
            return $"{this.playerOne} is playing {this.playerTwo}";
        }

        public string NoGoodChessPolymorphs()
        {
            return $"No Good Chess";
        }

        public Player GetMovingPlayer()
        {
            if (isWhitePlaying)
            {
                return playerOne;
            }
            else return playerTwo;
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
