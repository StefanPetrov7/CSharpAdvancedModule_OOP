using System;
namespace WildFarm.Exceptios
{
	public class InvalidAnimal : Exception
	{
		public InvalidAnimal() : base()
		{ }

		public InvalidAnimal(string message) : base(message)
		{ }
	}
}

