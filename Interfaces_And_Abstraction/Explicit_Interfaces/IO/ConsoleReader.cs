using System;
using Explicit_Interfaces.Contracts;

namespace Explicit_Interfaces.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadeLine()
        {
            return Console.ReadLine();
        }
    }
}
