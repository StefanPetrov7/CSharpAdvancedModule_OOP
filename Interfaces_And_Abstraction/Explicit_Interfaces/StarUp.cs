using Explicit_Interfaces.Contracts;
using Explicit_Interfaces.Core;
using Explicit_Interfaces.IO;

namespace Explicit_Interfaces
{
    class StarUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
