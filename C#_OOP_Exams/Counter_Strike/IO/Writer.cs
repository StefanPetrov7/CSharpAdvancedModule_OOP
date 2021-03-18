using System;

using Counter_Strike.IO.Contracts;

namespace Counter_Strike.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
