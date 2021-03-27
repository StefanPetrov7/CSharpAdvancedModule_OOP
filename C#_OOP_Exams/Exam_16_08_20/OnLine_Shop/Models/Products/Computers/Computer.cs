using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnLine_Shop.Common.Constants;
using OnLine_Shop.Models.Products.Components;
using OnLine_Shop.Models.Products.Peripherals;

namespace OnLine_Shop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformace
        {
            get => CalculateOveralPerformace();
        }

        public override decimal Price
        {
            get => CalculateTotalPrice();  // Updating GET with the new data combinet with the new data, we use only getter.
        }

        private decimal CalculateTotalPrice()
        {
            decimal result = this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price) + this.Price; // TODO this.Price to be chnaged for base.Price if recursion happenned
            return result;
        }

        private double CalculateOveralPerformace()
        {
            if (this.components.Count == 0)
            {
                return base.OverallPerformace;
            }

            double result = base.OverallPerformace + this.Comoponents.Average(x => x.OverallPerformace);
            return result;
        }

        public IReadOnlyCollection<IComponent> Comoponents => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Pheriperals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType() == component.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NoExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NoExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({this.Comoponents.Count}):");
            foreach (var componenet in this.Comoponents)
            {
                sb.AppendLine($"  {componenet}");
            }

            sb.AppendLine($" Peripherals ({this.Pheriperals.Count}); Average Overall Performance ({this.Pheriperals.Average(x => x.OverallPerformace)})");
            foreach (var peripheral in this.Pheriperals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return base.ToString() + $"\n{sb.ToString().TrimEnd()}";
        }
    }
}
