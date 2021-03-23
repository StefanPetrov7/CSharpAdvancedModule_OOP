using HAD.Contracts;
using HAD.Core;
using HAD.IO;

namespace HAD
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            IManager heroManager = new HeroManager();
            ICommandProcessor cmdProcessror = new CommandProcessor(heroManager);
            var engine = new Engine(reader, writer, cmdProcessror);
            engine.Run();
            
        }
    }
}
