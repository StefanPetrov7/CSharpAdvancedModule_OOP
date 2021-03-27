using System;
using OnLine_Shop.IO;

namespace OnLine_Shop.Core
{
    public class Engine : IEngine
    {
        private string Separator = " ";
        private ICommandInterpreter commandInterpreter;
        private IController controller;
        private IReader reader;
        private IWriter writer;


        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter, IController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string[] data = this.reader.CustomReadLine().Split(Separator);
                string msg;

                try
                {
                    msg = this.commandInterpreter.ExecuteCommands(data, this.controller);
                }
                catch (ArgumentException ex)
                {
                    msg = ex.Message;
                }
                catch (InvalidOperationException ex)
                {
                    msg = ex.Message;
                }

                this.writer.CustomWriteLine(msg);
            }
        }
    }
}
