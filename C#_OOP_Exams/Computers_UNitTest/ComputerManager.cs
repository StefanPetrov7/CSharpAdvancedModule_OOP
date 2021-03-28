using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers_UNitTest
{
    public class ComputerManager
    {
        private const string CanNotBeNullMessage = "Can not be null";
        private readonly List<Computer> computers;

        public ComputerManager()
        {
            this.computers = new List<Computer>();
        }

        public IReadOnlyCollection<Computer> Computers => this.computers.AsReadOnly();

        public int Count => this.computers.Count;

        public void AddComuter(Computer computer)
        {
            this.ValidateNllValue(computer, nameof(computer), CanNotBeNullMessage);

            if (this.computers.Any(c => c.Manufacturer == computer.Manufacturer && c.Model == computer.Model))
            {
                throw new ArgumentException("This computer already exists");
            }

            this.computers.Add(computer);
        }

        public ICollection<Computer> GetComputerByManufacturer(string manufacturer)
        {
            this.ValidateNllValue(manufacturer, nameof(manufacturer), CanNotBeNullMessage);
            ICollection<Computer> computers = this.Computers.Where(c => c.Manufacturer == manufacturer).ToList();
            return computers;
        }

        public Computer RemoveComputer(string manufacturer, string model)
        {
            Computer computer = this.GetComputer(manufacturer, model);
            this.computers.Remove(computer);
            return computer;
        }

        public Computer GetComputer(string manufacturer, string model)
        {
            this.ValidateNllValue(manufacturer, nameof(manufacturer), CanNotBeNullMessage);
            this.ValidateNllValue(model, nameof(model), CanNotBeNullMessage);

            Computer computer = this.computers.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (computer == null)
            {
                throw new ArgumentException("There is no computer with thismanufacturer and model");
            }

            return computer;
        }

        private void ValidateNllValue(object variable, string variableName, string extentionMessage)
        {
            if (variable == null)
            {
                throw new ArgumentException(variableName, extentionMessage);
            }
        }
    }
}
