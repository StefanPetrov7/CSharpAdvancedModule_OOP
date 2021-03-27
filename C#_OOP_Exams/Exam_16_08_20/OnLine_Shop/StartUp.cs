using System.IO;
using OnLine_Shop.Core;
using OnLine_Shop.IO;

namespace OnLine_Shop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt"); 
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new FileWriter(pathFile);

            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();

        }
    }
}
