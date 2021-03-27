using System.Collections.Generic;
using OnLine_Shop.Models.Products.Components;
using OnLine_Shop.Models.Products.Peripherals;

namespace OnLine_Shop.Models.Products.Computers
{
    public interface IComputer
    {
        public int Id { get; }

        decimal Price { get; }

        double OverallPerformace { get; }

        public IReadOnlyCollection<IComponent> Comoponents { get; }

        public IReadOnlyCollection<IPeripheral> Pheriperals { get; }

        public void AddComponent(IComponent component);

        public void AddPeripheral(IPeripheral peripheral);

        public IComponent RemoveComponent(string componentType);

        public IPeripheral RemovePeripheral(string peripheralType);

    }
}
