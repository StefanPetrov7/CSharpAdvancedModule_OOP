using System;

using Military_Elite.Contracts;

namespace Military_Elite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
