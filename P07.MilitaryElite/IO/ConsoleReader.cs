using System;

using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
