using Wild_Farm.Contracts;
using Wild_Farm.Core;
using Wild_Farm.IO;

namespace Wild_Farm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
