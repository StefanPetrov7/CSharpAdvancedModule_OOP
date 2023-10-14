using WildFarm.Contracts;
using WildFarm.Core;
using WildFarm.IO;

namespace WildFarm;
class Program
{
    static void Main(string[] args)
    {
        IWriter consoleWriter = new ConsoleWriter();
        IReader consoleReader = new ConsoleReader();
        Engine engine = new Engine(consoleReader, consoleWriter);
        engine.RunAnimals();
    }
}

