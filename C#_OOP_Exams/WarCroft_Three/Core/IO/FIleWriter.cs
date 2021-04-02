using System.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core.IO
{
    public class FIleWriter : IWriter
    {
        private string path = Path.Combine("..", "..", "..", "output.txt");

        public void WriteLine(string message)
        {
            File.AppendAllText(this.path, message);
            File.AppendAllText(this.path, "\n");
        }
    }
}
