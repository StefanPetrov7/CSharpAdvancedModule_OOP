using System;
namespace OnLine_Shop.Models.Products.Computers
{
    public class DescktopComputer : Computer
    {
        private const int overallPerfomance = 15;

        public DescktopComputer(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, overallPerfomance)
        { }
    }
}
