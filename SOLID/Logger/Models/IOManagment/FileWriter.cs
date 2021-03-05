using System;
using System.IO;
using ExLogger.Models.IOManagment.Contracts;

namespace ExLogger.Models.IOManagment
{
    public class FileWriter : IWriter
    {

        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; }

        public void Write(string text)
        {
            File.WriteAllText(this.FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(this.FilePath, text + Environment.NewLine);
        }
    }
}
