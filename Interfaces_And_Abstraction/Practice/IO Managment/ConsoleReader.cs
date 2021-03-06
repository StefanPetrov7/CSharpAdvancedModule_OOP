using System;
using Practice.IOManagment.Contracts;

namespace Practice.IOManagment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
