using System;
namespace SOLID.IO
{
	public interface IWriter
	{
		void Write(string msg);

		void WriteLine(string msg);
	}
}

