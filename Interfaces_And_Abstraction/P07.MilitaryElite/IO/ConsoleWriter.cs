using System;

using P07.MilitaryElite.Contracts;

namespace P07.MilitaryElite.IO
{
    public class ConsoleWriter: IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void Writeline(string text)
        {
            Console.WriteLine(text);
        }
    }
}
