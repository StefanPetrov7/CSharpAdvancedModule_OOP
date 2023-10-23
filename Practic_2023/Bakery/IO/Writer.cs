namespace Bakery.IO
{
    using Bakery.IO.Contracts;
    using System;
    using System.IO;

    public class Writer : IWriter
    {
        private string path;

        public Writer()
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
