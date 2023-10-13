using Raiding.Contracts;
namespace Raiding.IO
{
	public class ConsoleReader : IReader
	{
        public string Read() => Console.ReadLine();
     
    }
}

