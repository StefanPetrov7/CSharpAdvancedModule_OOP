using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Core;
using P07.MilitaryElite.IO;

namespace P07.MilitaryElite
{
    public class StartUp
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
