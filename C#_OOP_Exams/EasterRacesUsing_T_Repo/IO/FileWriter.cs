using System;
using System.IO;
using EasterRaces.IO.Contracts;

namespace EasterRaces.IO
{
    public class FileWriter : IWriter
    {
        private string filePath;

        public FileWriter()
        {
            this.filePath = Path.Combine("..", "..", "..", "result.txt");
        }

        public void Write(string message)
        {
            File.AppendAllText(this.filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(this.filePath, message + Environment.NewLine);
        }
    }
}
