using System;
using System.IO;
using Handball.IO.Contracts;

namespace Handball.IO
{
	public class FileWriter : IWriter
	{
		private string path;

		public FileWriter()
		{
            this.path = Path.Combine("..", "..", "..", "result.txt");
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