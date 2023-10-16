using System;
namespace SOLID.IO
{
	public class FileReader : IReader
	{
        private readonly string[] fileLines;
        private int pointer;

		public FileReader(string path = "../../../input.txt")
		{
            this.fileLines = File.ReadAllLines(path);
		}

        public string Read()
        {
            return this.fileLines[pointer++];
        }
    }
}

