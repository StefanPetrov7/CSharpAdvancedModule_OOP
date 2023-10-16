namespace SOLID.Loggers
{
	public interface ILogFile
	{

		int Size { get; }

		void Write(string content);

	}
}

