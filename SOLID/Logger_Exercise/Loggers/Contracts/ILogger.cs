using System;
namespace Logger_Exercise.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string date, string msg);

        void Warning(string date, string msg);

        void Error(string date, string msg);

        void Critical(string date, string msg);

        void Fatal(string date, string msg);

    }
}
