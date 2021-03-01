using System;
using Wild_Farm.Contracts;

namespace Wild_Farm.IO 
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
