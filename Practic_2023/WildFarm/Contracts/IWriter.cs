using System;
namespace WildFarm.Contracts
{
	public interface IWriter
	{
		void Write(string message);

		void WriteLine(string message);
	}
}

