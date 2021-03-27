using System;
using System.Collections.Generic;
using System.Linq;
using OnLine_Shop.Common.Constants;
using OnLine_Shop.Models.Products.Components;
using OnLine_Shop.Models.Products.Computers;
using OnLine_Shop.Models.Products.Peripherals;

namespace OnLine_Shop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int componentId, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            DoesComputerExist(computerId);

            if (this.components.Any(x => x.Id == componentId))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, componentId));
            }

            IComponent component;

            //object[] ctorParams = new object[] { id, manufacturer, model, price, overallPerformance, generation };  // Reflection => test it.
            //Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == componentType);
            //IComponent reflectionType = (IComponent)Activator.CreateInstance(type, ctorParams);

            if (componentType == typeof(VideoCard).Name)
            {
                component = new VideoCard(componentId, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == typeof(Motherboard).Name)
            {
                component = new Motherboard(componentId, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == typeof(SolidStateDrive).Name)
            {
                component = new SolidStateDrive(componentId, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == typeof(PowerSuply).Name)
            {
                component = new PowerSuply(componentId, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == typeof(RandomAccessMemory).Name)
            {
                component = new RandomAccessMemory(componentId, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == typeof(CentralProcessingUnit).Name)
            {
                component = new CentralProcessingUnit(componentId, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            this.computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            this.components.Add(component);
            return string.Format(SuccessMesages.AddedComponent, componentType, componentId, computerId);
        }

        public string AddComputer(string computerType, int computerId, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ComputerWithIdExists));
            }

            IComputer computer;

            if (computerType == typeof(DescktopComputer).Name)
            {
                computer = new DescktopComputer(computerId, manufacturer, model, price);
            }
            else if (computerType == typeof(LapTop).Name)
            {
                computer = new LapTop(computerId, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(computer);

            return string.Format(SuccessMesages.AddedComputer, computerId);
        }

        public string AddPeripheral(int computerId, int peripheralId, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            DoesComputerExist(computerId);

            if (this.peripherals.Any(x => x.Id == peripheralId))
            {
                throw new ArgumentException(ExceptionMessages.PeripheralWithIdExists);
            }

            //object[] ctorPeripherals = new object[] { peripheralId, manufacturer, model, price, overallPerformance, connectionType };  // => Reflection.
            //Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.GetType().Name == peripheralType);
            //IPeripheral peripheral = (IPeripheral)Activator.CreateInstance(type, ctorPeripherals);

            IPeripheral peripheral;

            if (peripheralType == typeof(Mouse).Name)
            {
                peripheral = new Mouse(peripheralId, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == typeof(Monitor).Name)
            {
                peripheral = new Keyboard(peripheralId, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == typeof(Keyboard).Name)
            {
                peripheral = new Monitor(peripheralId, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == typeof(Headset).Name)
            {
                peripheral = new Headset(peripheralId, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            this.peripherals.Add(peripheral);
            this.computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);
            return string.Format(SuccessMesages.AddedPeripheral, peripheralType, peripheralId, computerId);

        }

        public string BuyBestComputer(decimal budget)
        {
            IComputer computer = this.computers.Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformace)
                .FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CantBuyComputer, budget));
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int computerId)
        {
            DoesComputerExist(computerId);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int computerId)
        {
            DoesComputerExist(computerId);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            DoesComputerExist(computerId);
            IComponent component = this.computers.FirstOrDefault(x => x.Id == computerId).RemoveComponent(componentType);
            this.components.Remove(component);
            return string.Format(SuccessMesages.RemovalComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            DoesComputerExist(computerId);
            IPeripheral peripheral = this.computers.FirstOrDefault(x => x.Id == computerId).RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);
            return string.Format(SuccessMesages.RemovalPeripheral, peripheralType, peripheral.Id);
        }

        private void DoesComputerExist(int computerId)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NoExistingComputerId);
            }
        }
    }
}
