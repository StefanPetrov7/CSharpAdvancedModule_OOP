using System;
namespace Logger_Exercise.Loggers.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string content);
    }
}
