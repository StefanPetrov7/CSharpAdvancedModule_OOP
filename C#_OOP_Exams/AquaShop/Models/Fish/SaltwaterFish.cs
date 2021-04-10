    using System;
namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private int initialSize = 5;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            base.Size = initialSize;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
