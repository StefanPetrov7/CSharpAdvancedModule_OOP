using SOLID.Core;
using SOLID.IO;

namespace SOLID;
class Program
{
    static void Main(string[] args)
    {
        IReader consoleReader = new FileReader();
        IWriter consoleWriter = new ConsoleWriter();
        IEngine engine = new Engine(new AppenderFactory(), new LayoutFactory(), consoleReader, consoleWriter);
        engine.Run();
    }
}