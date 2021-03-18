using System;

using Counter_Strike.IO.Contracts;

namespace Counter_Strike.IO
{
    public class Reader: IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
