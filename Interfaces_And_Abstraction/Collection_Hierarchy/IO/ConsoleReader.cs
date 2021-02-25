using System;

using Collection_Hierarchy.Contracts;

namespace Collection_Hierarchy.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
