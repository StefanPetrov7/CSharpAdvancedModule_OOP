using System.Text;
using EasterRaces.IO.Contracts;

namespace EasterRaces.IO
{
    public class SBWriter : IWriter
    {
        private StringBuilder sb;

        public SBWriter()
        {
            sb = new StringBuilder();
        }

        public void Write(string message)
        {
            this.sb.Append(message);
        }

        public void WriteLine(string message)
        {
            this.sb.AppendLine(message);
        }

        public override string ToString()
        {
            return this.sb.ToString();
        }
    }
}
