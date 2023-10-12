using Vehicles.Contracts;
using Vehicles.Models;
namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void RunVehicles()
        {
            double[] carData = reader.Read().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToArray();
            double[] truckData = reader.Read().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToArray();
            double[] busData = reader.Read().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToArray();
            int n = int.Parse(reader.Read());
            Vehicle car = new Car(carData[0], carData[1], carData[2]);
            Vehicle truck = new Truck(truckData[0], truckData[1], truckData[2]);
            Vehicle bus = new Bus(busData[0], busData[1], busData[2]);
            List<Vehicle> vehicles = new List<Vehicle>
            {
                car,
                truck,
                bus
            };

            for (int i = 0; i < n; i++)
            {
                string[] cmd = reader.Read().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = cmd[0];
                string type = cmd[1];
                double units = double.Parse(cmd[2]);

                try
                {
                    if (command.StartsWith("Drive"))
                    {
                        ((Bus)bus).IsEmpty = command.EndsWith("Empty") ? true : false;
                        writer.WriteLine(vehicles.FirstOrDefault(x => x.GetType().Name == type).Drive(units));
                    }
                    else if (command == "Refuel")
                    {
                        vehicles.FirstOrDefault(x => x.GetType().Name == type).Refuel(units);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            vehicles.ForEach(x => writer.WriteLine(x.ToString()));
        }
    }
}

