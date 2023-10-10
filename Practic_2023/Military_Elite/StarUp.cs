using Military_Elite.Contracts;
using Military_Elite.Core;
using Military_Elite.IO;

namespace Military_Elite;
class Program
{
    static void Main(string[] args)
    {
        // 80 PTS sorting of the privates should be removed

        IReader consolReader = new ConsoleReader();
        IWriter consoleWriter = new ConsloleWriter();
        IEngine engine = new Engine(consolReader, consoleWriter);
        engine.Run();
    }
}

