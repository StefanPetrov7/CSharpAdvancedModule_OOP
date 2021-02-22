using Border_Control.Contracts;
using Border_Control.Core;
using Border_Control.IO;

namespace Border_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(writer, reader);
            //engine.Run();

            EngineFoodShortage engineFood = new EngineFoodShortage (writer, reader);
            engineFood.Run();
        }
    }
}
