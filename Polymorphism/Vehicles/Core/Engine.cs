using System;
using System.Collections.Generic;
using System.Linq;

using Vehicles.Factory;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;
        private ViechleFactory viechleFactory;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.viechleFactory = new ViechleFactory();
        }

        public void Run()
        {
            string[] carInfo = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            string[] truckInfo = reader.ReadLine()
           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

            string[] busInfo = reader.ReadLine()
          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
          .ToArray();

            int n = int.Parse(reader.ReadLine());

            Viechle car = viechleFactory
                .ProduceViechle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Viechle truck = viechleFactory
                .ProduceViechle(truckInfo[0], double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Viechle bus = viechleFactory
                .ProduceViechle(busInfo[0], double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            List<Viechle> viechles = new List<Viechle> { car, truck, bus };

            for (int i = 0; i < n; i++)
            {
                string[] args = reader.ReadLine().Split();
                string viechleType = args[1];
                double info = double.Parse(args[2]);
                try
                {
                    if (args[0].StartsWith("Drive"))
                    {
                        ((Bus)bus).IsEmpty = args[0].EndsWith("Empty") ? true : false;

                        foreach (var viechle in viechles.Where(v => v.GetType().Name.ToString() == viechleType))
                        {
                            writer.WriteLine(viechle.Drive(info));
                        }
                    }
                    else if (args[0] == "Refuel")
                    {
                        foreach (var viechle in viechles.Where(v => v.GetType().Name.ToString() == viechleType))
                        {
                            viechle.Refuel(info);
                        }
                    }

                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

            }

            writer.WriteLine(string.Join(Environment.NewLine, viechles));
        }
    }
}
