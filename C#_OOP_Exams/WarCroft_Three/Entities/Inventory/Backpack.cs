namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int backPackCapacity = 100;

        public Backpack(): base(backPackCapacity)
        { }
    }
}
