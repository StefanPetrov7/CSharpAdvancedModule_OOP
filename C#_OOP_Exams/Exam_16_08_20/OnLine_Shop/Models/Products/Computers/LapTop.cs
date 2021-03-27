using System;
namespace OnLine_Shop.Models.Products.Computers
{
    public class LapTop : Computer
    {
        private const int overallPerfomance = 10;

        public LapTop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, overallPerfomance)
        { }
    }
}
