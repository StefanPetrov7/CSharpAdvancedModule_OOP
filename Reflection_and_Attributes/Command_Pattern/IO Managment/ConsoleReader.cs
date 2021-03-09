using System;
using CommandPattern.IOManagment.Contracts;

namespace CommandPattern.IOManagment
{
    public class ConsoleReader: IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
