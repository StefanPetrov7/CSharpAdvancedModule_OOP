using System;
using System.IO;
using Bakery.IO.Contracts;

namespace Bakery.IO
{
    public class FileWriter : IWriter
    {
        private string path;

        public FileWriter()
        {
            this.path = Path.Combine("..", "..", "..", "output.txt");
            File.WriteAllText(this.path, string.Empty);
        }

        public void Write(string message)
        {
            File.AppendAllText(this.path, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(this.path, message + Environment.NewLine);
        }
    }
}
