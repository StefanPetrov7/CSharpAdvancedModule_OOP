using System;
using System.IO;
using System.Linq;
using Logger_Exercise.Loggers.Contracts;

namespace Logger_Exercise.Loggers
{
    public class LogFile : ILogFile  // Write the output into txt file, gives the ASCII sum of the chars in that file.   
    {
        private string path = Path.Combine("..", "..", "..", "output.txt");

        public LogFile()
        { }

        public int Size => CalculateSize();

        public void Write(string content)
        {
            File.AppendAllText(this.path, content);
        }

        private int CalculateSize()
        {
            return File.ReadAllText(path).Where(x => Char.IsLetter(x)).Sum(x => x);
        }
    }
}
