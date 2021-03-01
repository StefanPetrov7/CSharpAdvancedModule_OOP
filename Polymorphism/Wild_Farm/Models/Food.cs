using System;
namespace Wild_Farm.Models
{
    public abstract class Food
    {
        public Food(int qty)
        {
            this.Qty = qty;
        }

        public int Qty { get; private set; }
    }
}
