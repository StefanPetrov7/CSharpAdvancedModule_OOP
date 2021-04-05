using System;
using System.Linq;
using System.Collections.Generic;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System.Text;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IPeripheral> peripherals;
        private ICollection<IComponent> components;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.peripherals = new List<IPeripheral>();
            this.components = new List<IComponent>();
        }

        public override double OverallPerformance => base.OverallPerformance + ComponentPerformance();

        public override decimal Price => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        private double ComponentPerformance()
        {
            double componentPerformance = 0;

            if (this.components.Count > 0)
            {
                componentPerformance = this.components.Average(x => x.OverallPerformance);
            }

            return componentPerformance;
        }

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
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
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
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
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {

            double peripheralsAverage = this.Peripherals.Count > 0 ? this.Peripherals.Average(x => x.OverallPerformance) : 0;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var componenet in this.components)
            {
                sb.AppendLine($"  {componenet}");
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({peripheralsAverage:f2}):");
            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return base.ToString() + $"\n{sb.ToString().TrimEnd()}";

        }
    }
}
