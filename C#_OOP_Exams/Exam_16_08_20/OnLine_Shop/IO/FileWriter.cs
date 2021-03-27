using System;
using System.IO;

namespace OnLine_Shop.IO
{
    public class FileWriter : IWriter
    {
        private readonly string filePath;


        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void CustomWriteLine(string text)
        {
            File.AppendAllText(this.filePath, text + Environment.NewLine);
        }

        public void CustomWrite(string text)
        {
            File.AppendAllText(this.filePath, text);
        }
    }
}
