using Military_Elite.Contracts;
using Military_Elite.Core;
using Military_Elite.IO;

namespace Military_Elite
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            Engine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
