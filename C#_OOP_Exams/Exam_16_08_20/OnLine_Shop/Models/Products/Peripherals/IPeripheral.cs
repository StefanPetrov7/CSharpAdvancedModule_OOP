using System;
namespace OnLine_Shop.Models.Products.Peripherals
{
    public interface IPeripheral
    {
        int Id { get; }

        public decimal Price { get; }

        public double OverallPerformace { get; }

        string ConnectionType { get; }
    }
}
