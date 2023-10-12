using Vehicles.Core;
using Vehicles.Contracts;
using Vehicles.IO;

namespace Vehicles;
class Program
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IEngine engine = new Engine(reader, writer);
        engine.RunVehicles();
    }
}

