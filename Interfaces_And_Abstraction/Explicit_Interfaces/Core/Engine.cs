using System.Linq;

using Explicit_Interfaces.Contracts;
using Explicit_Interfaces.Models;

namespace Explicit_Interfaces.Core
{
    public class Engine : IEngine
    {
        private const string END_INPUT = "End";

        IWriter writer;
        IReader reader;

        public Engine(IReader reader, IWriter writer)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadeLine()) != END_INPUT)
            {
                string[] args = input.Split(' ').ToArray();
                Citizen citizen = new Citizen(args[0], args[1], int.Parse(args[2]));
                writer.WriteLine(((IPerson)citizen).GetName()); // Expilicit call same method with different implementations in different interfaces. 
                writer.WriteLine(((IResident)citizen).GetName()); // Expilicit call same method with different implementations in different interfaces. 
            }
        }
    }
}
