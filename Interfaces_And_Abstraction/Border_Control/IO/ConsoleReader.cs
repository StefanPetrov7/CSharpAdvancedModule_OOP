using System;

using Border_Control.Contracts;

namespace Border_Control.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
