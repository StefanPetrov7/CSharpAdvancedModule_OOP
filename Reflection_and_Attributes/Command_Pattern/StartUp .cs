using CommandPattern.Contracts;
using CommandPattern.Core;
using CommandPattern.IOManagment;
using CommandPattern.IOManagment.Contracts;

namespace CommandPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command, reader, writer);
            engine.Run();
        }
    }
}
