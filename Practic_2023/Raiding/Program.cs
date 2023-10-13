using Raiding.Core;
using Raiding.Contracts;
using Raiding.IO;

namespace Raiding;
public class Program
{
    static void Main(string[] args)
    {
        IWriter consoleWriter = new ConsoleWriter();
        IReader consoleReader = new ConsoleReader();
        Engine engine = new Engine(consoleReader, consoleWriter);
        engine.RunHero();
    }
}

