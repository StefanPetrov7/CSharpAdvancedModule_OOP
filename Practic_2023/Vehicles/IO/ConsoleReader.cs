using Vehicles.Contracts;
namespace Vehicles.IO
{
	public class ConsoleReader : IReader
	{
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}

