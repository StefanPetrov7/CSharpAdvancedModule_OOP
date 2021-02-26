namespace Practice_Polymorphism
{
    public abstract class TwoPlayerGame : Game
    {
        protected Player playerOne;
        protected Player playerTwo;

        public TwoPlayerGame (Player pone, Player ptwo)
        {
            this.playerOne = pone;
            this.playerTwo = ptwo;
        }
    }
}
