namespace Practice_Polymorphism
{
    public class Tennis : TwoPlayerGame
    {
        public Tennis(Player pone, Player ptwo) : base(pone, ptwo)
        {
        }

        public override string GetDiscription()
        {
            return string.Format("PLayer {0} broke Player {1}", this.playerOne, this.playerTwo);
        }

        public string IsNoGoodPolymorphsm()
        {
            return "No good Tennis";
        }
    }
}
