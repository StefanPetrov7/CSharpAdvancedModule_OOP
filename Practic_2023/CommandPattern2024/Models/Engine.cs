using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Models
{
    public class Engine : IEngine
    {
        private ICommandInterpreter _interpreter;

        public Engine(ICommandInterpreter command)
        {
            this._interpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string tokens = Console.ReadLine();
                    string result = this._interpreter.Read(tokens);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    ConsoleColor initialColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = initialColor;
                }
            }
        }
    }
}
