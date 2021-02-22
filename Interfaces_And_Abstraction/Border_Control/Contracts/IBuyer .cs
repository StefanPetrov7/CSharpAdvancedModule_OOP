namespace Border_Control.Contracts
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Food { get; }
        public void BuyFood();
    }
}
