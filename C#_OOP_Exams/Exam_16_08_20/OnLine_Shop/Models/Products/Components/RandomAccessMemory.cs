namespace OnLine_Shop.Models.Products.Components
{
    public class RandomAccessMemory : Component
    {
        private double multiplier = 1.20;

        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
          : base(id, manufacturer, model, price, overallPerformance, generation)
        { }

        public override double OverallPerformace => base.OverallPerformace * multiplier;
    }
}
