using System;
using Logger_Exercise.Enums;

namespace Logger_Exercise.Appenders.Contracts
{
    public interface IAppender
    {
        public ReportLevel ReportLevel { get; set; }

        void Append(string date, ReportLevel level, string msg);
    }
}
