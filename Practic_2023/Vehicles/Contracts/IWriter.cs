using System;
namespace Vehicles.Contracts
{
	public interface IWriter
	{
		void Write(string message);

		void WriteLine(string message);
	}
}

