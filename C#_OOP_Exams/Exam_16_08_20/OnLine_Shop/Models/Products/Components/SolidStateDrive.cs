using System;
namespace OnLine_Shop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private double multiplier = 1.20;

        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
          : base(id, manufacturer, model, price, overallPerformance, generation)
        {
            
        }
        public override double OverallPerformace => base.OverallPerformace * multiplier;
    }
}
