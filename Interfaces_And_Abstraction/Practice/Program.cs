using System;
using Practice.Contracts;
using Practice.Core;
using Practice.IOManagment;
using Practice.IOManagment.Contracts;

namespace Practice
{
    class Program
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
