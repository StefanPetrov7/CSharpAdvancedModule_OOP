using System;
namespace WarCroft.Entities.Inventory.Models
{
    public class Satchel : Bag, IBag
    {
        private int defaultCapacity = 20;

        public Satchel() : base()
        {
            this.Capacity = defaultCapacity;
        }

    }
}
