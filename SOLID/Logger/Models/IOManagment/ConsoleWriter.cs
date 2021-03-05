using System;
using ExLogger.Models.IOManagment.Contracts;

namespace ExLogger.Models.IOManagment
{
    public class ConsoleWriter : IWriter
    {

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
