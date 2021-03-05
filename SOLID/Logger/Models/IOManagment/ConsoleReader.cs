using System;
using ExLogger.Models.IOManagment.Contracts;

namespace ExLogger.Models.IOManagment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
