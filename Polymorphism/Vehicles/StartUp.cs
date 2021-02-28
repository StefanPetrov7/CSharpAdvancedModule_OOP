using System;
using Vehicles.Contracts;
using Vehicles.Core;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
