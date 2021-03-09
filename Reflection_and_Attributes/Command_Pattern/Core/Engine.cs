using System;
using CommandPattern.Contracts;
using CommandPattern.IOManagment.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        IWriter writer;
        IReader reader;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string args = reader.ReadLine();

                try
                {
                    string result = commandInterpreter.Read(args);
                    writer.WriteLine(result);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
