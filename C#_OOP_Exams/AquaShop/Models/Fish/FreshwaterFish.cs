using System;
namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int initialSize = 3;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            base.Size = initialSize;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
