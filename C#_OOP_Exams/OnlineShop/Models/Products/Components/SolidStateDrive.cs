namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private double multipier = 1.20;

        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance, generation)
        { }

        public override double OverallPerformance => base.OverallPerformance * multipier;
    }
}
