using System;
namespace OnLine_Shop.IO
{
    public class ConsoleReader : IReader
    {
        public string CustomReadLine()
        {
            return Console.ReadLine();
        }
    }
}
