using System;
using System.IO;
using Military_Elite.Core;
using Military_Elite.IO;
using Military_Elite.IO.Contracts;

namespace Military_Elite
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter consoleWriter = new ConsoleWriter();
            IReader consoleReader = new ConsoleReader();

            IWriter fileWriter = new FileWriter();

            Engine engine = new Engine(consoleReader, fileWriter);
            engine.Run();
        }
    }
}
