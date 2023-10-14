using System;
using WildFarm.Contracts;

namespace WildFarm.IO
{
	public class ConsoleReader : IReader
	{
		public string Read() => Console.ReadLine();
	}
}

