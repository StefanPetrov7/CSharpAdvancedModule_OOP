using System;
using System.IO;
using Military_Elite.IO.Contracts;

namespace Military_Elite.IO
{
    public class FileWriter : IWriter
    {
        private readonly string filePath;

        public FileWriter()
        {
            this.filePath = Path.Combine("..", "..", "..", "output.txt");
            File.Create(this.filePath).Close();
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(this.filePath, text + Environment.NewLine);
        }

        public void Write(string text)
        {
            File.AppendAllText(this.filePath, text);
        }
    }
}
