using OnLine_Shop.Common.Constants;

namespace OnLine_Shop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        
        public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base( id,  manufacturer,  model,  price,  overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation { get; } // It will be set only thru the ctor.

        public override string ToString()
        {
            return base.ToString() + string.Format(SuccessMesages.ComponentToString, this.Generation);
        }
    }
}
