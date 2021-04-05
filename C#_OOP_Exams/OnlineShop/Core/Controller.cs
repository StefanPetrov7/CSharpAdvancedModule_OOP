using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;


namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computerRepo;
        private ICollection<IComponent> componentRepo;
        private ICollection<IPeripheral> peripheralRepo;

        public Controller()
        {
            this.computerRepo = new List<IComputer>();
            this.componentRepo = new List<IComponent>();
            this.peripheralRepo = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);

            if (this.componentRepo.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent componnet = componentType switch
            {
                nameof(CentralProcessingUnit) => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                nameof(Motherboard) => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(PowerSupply) => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                nameof(RandomAccessMemory) => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                nameof(VideoCard) => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                nameof(SolidStateDrive) => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            this.computerRepo.FirstOrDefault(x => x.Id == computerId).AddComponent(componnet);
            this.componentRepo.Add(componnet);
            return string.Format(SuccessMessages.AddedComponent,
                componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computerRepo.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = computerType switch
            {
                nameof(Laptop) => new Laptop(id, manufacturer, model, price),
                nameof(DesktopComputer) => new DesktopComputer(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            this.computerRepo.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);

            if (this.peripheralRepo.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = peripheralType switch
            {
                nameof(Headset) => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Keyboard) => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Monitor) => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                nameof(Mouse) => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            this.computerRepo.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);
            this.peripheralRepo.Add(peripheral);
            return string.Format(SuccessMessages.AddedPeripheral,
                peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computerRepo.Where(x => x.Price <= budget).OrderByDescending(X => X.OverallPerformance).FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computerRepo.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExists(id);
            IComputer computer = this.computerRepo.FirstOrDefault(x => x.Id == id);
            this.computerRepo.Remove(computer);
            return computer.ToString();
        }
            

        public string GetComputerData(int id)
        {
            CheckIfComputerExists(id);

            return this.computerRepo.FirstOrDefault(x => x.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);
            IComponent componenet = this.computerRepo.FirstOrDefault(x => x.Id == computerId).RemoveComponent(componentType);
            return string.Format(SuccessMessages.RemovedComponent,
               componentType, componenet.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);
            IPeripheral peripheral = this.computerRepo.FirstOrDefault(x => x.Id == computerId).RemovePeripheral(peripheralType);
            return string.Format(SuccessMessages.RemovedPeripheral,
               peripheralType, peripheral.Id);
        }

        private void CheckIfComputerExists(int compiterId)
        {
            if (!this.computerRepo.Any(x => x.Id == compiterId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
